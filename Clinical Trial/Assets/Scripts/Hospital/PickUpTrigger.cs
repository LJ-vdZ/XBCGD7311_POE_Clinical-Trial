using TMPro;
using UnityEngine;

public class PickUpTrigger : MonoBehaviour
{
    public enum BubbleDetectionMode
    {
        [Tooltip("OnTriggerEnter/Exit. Player often needs a Rigidbody (Kinematic, no gravity) on the same object as CharacterController, or triggers may never fire.")]
        TriggerCollider,
        [Tooltip("Distance from this object to the player. Works without physics triggers.")]
        ProximityRadius,
    }

    [SerializeField] BubbleDetectionMode detectionMode = BubbleDetectionMode.ProximityRadius;
    [SerializeField] float proximityRadius = 4f;
    [SerializeField] bool useHorizontalDistanceOnly = true;

    [SerializeField][TextArea(2, 5)] string message = "Hello!";
    [SerializeField] Vector3 localOffset = new Vector3(0f, 2f, 0f);
    [SerializeField] Vector2 textAreaSize = new Vector2(4f, 2f);
    [SerializeField] float fontSize = 6f;
    [SerializeField] Color textColor = Color.white;
    [SerializeField] string playerTag = "Player";
    [SerializeField] bool faceMainCamera = true;

    GameObject _bubble;
    Transform _player;

    void Reset()
    {
        var c = GetComponent<Collider>();
        if (c != null)
            c.isTrigger = true;
    }

    void Awake()
    {
        var go = new GameObject("TextBubble");
        go.transform.SetParent(transform, false);
        go.transform.localPosition = localOffset;

        var tmp = go.AddComponent<TextMeshPro>();
        tmp.text = message;
        tmp.fontSize = fontSize;
        tmp.color = textColor;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.enableWordWrapping = true;
        tmp.rectTransform.sizeDelta = textAreaSize;

        _bubble = go;
        _bubble.SetActive(false);
    }

    void Start()
    {
        RefreshPlayerReference();
    }

    void OnEnable()
    {
        RefreshPlayerReference();
    }

    void Update()
    {
        if (detectionMode != BubbleDetectionMode.ProximityRadius)
            return;

        if (_player == null)
            RefreshPlayerReference();
        if (_player == null)
            return;

        float sqr = GetSqrDistanceToPlayer();
        SetBubbleVisible(sqr <= proximityRadius * proximityRadius);
    }

    float GetSqrDistanceToPlayer()
    {
        Vector3 a = transform.position;
        Vector3 b = _player.position;
        if (useHorizontalDistanceOnly)
        {
            a.y = 0f;
            b.y = 0f;
        }

        return (a - b).sqrMagnitude;
    }

    void RefreshPlayerReference()
    {
        GameObject found = GameObject.FindGameObjectWithTag(playerTag);
        _player = found != null ? found.transform : null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (detectionMode != BubbleDetectionMode.TriggerCollider)
            return;

        if (!isActiveAndEnabled || other == null)
            return;

        if (!other.CompareTag(playerTag))
            return;

        SetBubbleVisible(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (detectionMode != BubbleDetectionMode.TriggerCollider)
            return;

        if (!isActiveAndEnabled || other == null)
            return;

        if (!other.CompareTag(playerTag))
            return;

        SetBubbleVisible(false);
    }

    void LateUpdate()
    {
        if (!faceMainCamera || !BubbleIsShowing())
            return;

        Transform cam = Camera.main != null ? Camera.main.transform : null;
        if (cam == null)
            return;

        _bubble.transform.rotation = Quaternion.LookRotation(_bubble.transform.position - cam.position);
    }

    bool BubbleIsShowing()
    {
        return _bubble != null && _bubble.activeSelf;
    }

    void SetBubbleVisible(bool visible)
    {
        if (_bubble == null)
            return;

        _bubble.SetActive(visible);
    }
}
