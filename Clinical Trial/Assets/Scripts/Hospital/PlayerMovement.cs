using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimplePlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float minPitch = -80f;
    [SerializeField] float maxPitch = 80f;
    [SerializeField] bool lockCursor = true;

    [SerializeField] Transform cameraTransform;
    [SerializeField] Vector3 cameraWorldOffset = new Vector3(0f, 1.6f, 0f);

    CharacterController _controller;
    float _pitch;
    bool _cursorLocked;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (lockCursor)
            SetCursorLocked(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetCursorLocked(false);
        if (Input.GetMouseButtonDown(0) && !_cursorLocked)
            SetCursorLocked(true);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mouseX, 0f);
        _pitch = Mathf.Clamp(_pitch - mouseY, minPitch, maxPitch);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 input = new Vector3(h, 0f, v);

        Vector3 moveDir = Vector3.zero;
        if (input.sqrMagnitude > 0.01f)
        {
            input.Normalize();
            moveDir = transform.right * input.x + transform.forward * input.z;
        }

        Vector3 delta = moveDir * moveSpeed * Time.deltaTime;
        delta.y = 0f;
        _controller.Move(delta);
    }

    void LateUpdate()
    {
        if (cameraTransform == null)
            return;

        if (cameraTransform.parent == transform)
        {
            cameraTransform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
            return;
        }

        cameraTransform.position = transform.position + cameraWorldOffset;
        cameraTransform.rotation = Quaternion.Euler(_pitch, transform.eulerAngles.y, 0f);
    }

    void SetCursorLocked(bool locked)
    {
        _cursorLocked = locked;
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}
