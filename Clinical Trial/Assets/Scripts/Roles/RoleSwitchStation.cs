using UnityEngine;

public class RoleSwitchStation : MonoBehaviour, IInteractable
{
    public RoleType roleToSwitchTo;
    public PlayerRoleManager roleManager;

    public void Interact(RoleType playerRole)
    {
        roleManager.SwitchRole(roleToSwitchTo);
    }
}