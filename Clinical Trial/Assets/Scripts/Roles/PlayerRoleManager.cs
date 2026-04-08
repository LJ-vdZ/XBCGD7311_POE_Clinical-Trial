using UnityEngine;
using System;

public class PlayerRoleManager : MonoBehaviour
{
    public RoleType CurrentRole { get; private set; }

    public static Action<RoleType> OnRoleChanged;

    private void Start()
    {
        SwitchRole(RoleType.Manager); // Start as manager
    }

    public void SwitchRole(RoleType newRole)
    {
        CurrentRole = newRole;

        Debug.Log("Switched to: " + CurrentRole);

        OnRoleChanged?.Invoke(CurrentRole);
    }
}