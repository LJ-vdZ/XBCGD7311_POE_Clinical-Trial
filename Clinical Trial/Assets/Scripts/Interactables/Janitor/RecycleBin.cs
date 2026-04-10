using UnityEngine;

public class RecycleBin : MonoBehaviour, IInteractable
{
    public void Interact(RoleType role)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var janitor = player.GetComponent<JanitorAbilities>();

        janitor.DisposeTrash(TrashType.Recycle);
    }
}
