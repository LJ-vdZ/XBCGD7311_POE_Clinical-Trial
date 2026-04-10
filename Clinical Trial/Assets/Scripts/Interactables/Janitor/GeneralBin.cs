using UnityEngine;

public class GeneralBin : MonoBehaviour, IInteractable
{
    public void Interact(RoleType role)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var janitor = player.GetComponent<JanitorAbilities>();
  
        janitor.DisposeTrash(TrashType.General);
    }
}
