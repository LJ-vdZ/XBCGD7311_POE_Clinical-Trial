using UnityEngine;

public class NurseBed : MonoBehaviour, IInteractable
{
    public GameObject NurseUI;
    public void Interact(RoleType role)
    {

        if (role != RoleType.Nurse)
        {
            Debug.Log("Only the Manager can use this!");
            return;
        }

        Debug.Log("Opening Manager UI...");
        NurseUI.SetActive(true);

        // Optional: lock player movement here
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
