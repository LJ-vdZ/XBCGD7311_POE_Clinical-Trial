using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour  //rpg third person camera vibe
{
    public Transform target;                  //player object 
    public float distance = 6f;
    public float heightOffset = 2.2f;         //height above player center
    public float mouseSensitivity = 3f;

    private float yaw = 0f;
    private float pitch = 20f;                //start slightly tilted down

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void LateUpdate()
    {
        if (target == null) return;

        //mouse input for look
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 70f);

        //rotation from stored yaw/pitch (independent of player rotation)
        Quaternion camRotation = Quaternion.Euler(pitch, yaw, 0f);

        //camera position, always behind based on yaw/pitch, relative to player position
        Vector3 desiredPos = target.position
                           - camRotation * Vector3.forward * distance
                           + Vector3.up * heightOffset;

        //simple wall collision push (prevents clipping)
        Vector3 dir = desiredPos - target.position;
        if (Physics.Raycast(target.position, dir.normalized, out RaycastHit hit, distance))
        {
            desiredPos = target.position + dir.normalized * (hit.distance * 0.9f);
        }

        //instant position (prevents catch-up spin)
        transform.position = desiredPos;

        //look at player center
        transform.LookAt(target.position + Vector3.up * 1.8f);
    }
}
