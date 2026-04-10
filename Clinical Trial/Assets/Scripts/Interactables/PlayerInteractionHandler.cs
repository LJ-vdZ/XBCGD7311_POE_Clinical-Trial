using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    private IInteractable currentTarget;
    private RoleType currentRole;

    public void SetCurrentTarget(IInteractable target, RoleType role)
    {
        currentTarget = target;
        currentRole = role;
    }

    public void ClearTarget()
    {
        currentTarget = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
        {
            currentTarget.Interact(currentRole);
        }
    }
}