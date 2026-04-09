using UnityEngine;

public class GeneralBin : MonoBehaviour, IJanitorInteractable
{
    public void Interact(JanitorController janitor)
    {
        janitor.DisposeTrash(TrashType.General);
    }
}
