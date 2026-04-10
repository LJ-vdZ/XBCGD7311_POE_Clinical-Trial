using UnityEngine;
using TMPro;

public class InteractPrompt : MonoBehaviour
{
    [Header("3D Prompt")]
    public TextMeshPro promptText;

    [Header("Trigger Settings")]
    [Range(1f, 8f)]
    public float triggerRadius = 4.5f;     // Increased default

    private SphereCollider triggerCollider;

    void Awake()
    {
        // Auto-create or fix the trigger
        triggerCollider = GetComponent<SphereCollider>();
        if (triggerCollider == null)
        {
            triggerCollider = gameObject.AddComponent<SphereCollider>();
        }

        triggerCollider.isTrigger = true;
        triggerCollider.radius = triggerRadius;

        if (promptText != null)
            promptText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (promptText != null)
                promptText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (promptText != null)
                promptText.gameObject.SetActive(false);
        }
    }

    // Makes the text face the PLAYER (not the camera)
    void LateUpdate()
    {
        promptText.transform.LookAt(Camera.main.transform);
        promptText.transform.Rotate(0, 180, 0);
    }
}
