using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimplePlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float minPitch = -80f;
    [SerializeField] float maxPitch = 80f;

    [SerializeField] Transform cameraTransform;
    [SerializeField] Vector3 cameraWorldOffset = new Vector3(0f, 1.6f, 0f);

    CharacterController controller;
    float pitch;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        SetControlsLocked(false);
    }

    void Start()
    {
        //SetControlsLocked(true);
        //if (cameraTransform == null && Camera.main != null)
        //    cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    SetCursorLocked(false);
        //if (Input.GetMouseButtonDown(0) && !_cursorLocked)
        //    SetCursorLocked(false);
        if (Cursor.lockState != CursorLockMode.Locked)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mouseX, 0f);
        pitch = Mathf.Clamp(pitch - mouseY, minPitch, maxPitch);

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
        controller.Move(delta);
    }

    void LateUpdate()
    {
        if (cameraTransform == null)
            return;

        if (cameraTransform.parent == transform)
        {
            cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
            return;
        }

        cameraTransform.position = transform.position + cameraWorldOffset;
        cameraTransform.rotation = Quaternion.Euler(pitch, transform.eulerAngles.y, 0f);
    }

    public void SetControlsLocked(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
