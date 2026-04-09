using UnityEngine;

public class TrashItem : MonoBehaviour, IJanitorInteractable
{
    public TrashType type;

    public void Interact(JanitorController janitor)
    {
        if (janitor != null)
        {
            janitor.PickUpTrash(this);

            Debug.Log("Trash picked up: " + type);   
        }
    }
}
