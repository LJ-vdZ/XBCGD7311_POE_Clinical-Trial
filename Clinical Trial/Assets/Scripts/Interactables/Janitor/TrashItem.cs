using UnityEngine;

public class TrashItem : MonoBehaviour, IInteractable
{
    public TrashType type;

    public void Interact(RoleType role)
    {
        if (role == RoleType.Janitor)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            var janitor = player.GetComponent<JanitorAbilities>();

            janitor.PickUpTrash(this);

            Debug.Log("Trash picked up: " + type);   
        }
    }
}
