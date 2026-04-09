using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("RPG Camera Settings")]
    public Transform target;                    //drag Janitor or character here
    public float distance = 6f;
    public float heightOffset = 2.5f;
    public float mouseSensitivity = 3f;
    public float minPitch = -30f;
    public float maxPitch = 70f;

    private float yaw = 0f;
    private float pitch = 25f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //hide cursor for mouse look
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        //mouse look, free orbit
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        //Calculate camera position
        Quaternion camRotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position
                                + camRotation * new Vector3(0, heightOffset, -distance);

        //wall avoidance (prevent clipping)
        if (Physics.Raycast(target.position + Vector3.up * 1f, (desiredPosition - target.position).normalized,
            out RaycastHit hit, distance + 1f))
        {
            desiredPosition = hit.point;
        }

        transform.position = desiredPosition;
        transform.LookAt(target.position + Vector3.up * 1.8f);
    }
}
