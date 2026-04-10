using UnityEngine;

public class MedicalBin : MonoBehaviour, IInteractable
{
    public void Interact(RoleType role)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var janitor = player.GetComponent<JanitorAbilities>();

        janitor.DisposeTrash(TrashType.Medical);
    }
}
