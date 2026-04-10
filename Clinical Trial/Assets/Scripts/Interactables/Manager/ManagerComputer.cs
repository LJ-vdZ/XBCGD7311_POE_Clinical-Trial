using UnityEngine;

public class ManagerComputer : MonoBehaviour, IInteractable
{
    public GameObject managerUI;

    public void Interact(RoleType role)
    {
        if (role != RoleType.Manager)
        {
            Debug.Log("Only the Manager can use this!");
            return;
        }

        Debug.Log("Opening Manager UI...");
        managerUI.SetActive(true);

        // Optional: lock player movement here
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}