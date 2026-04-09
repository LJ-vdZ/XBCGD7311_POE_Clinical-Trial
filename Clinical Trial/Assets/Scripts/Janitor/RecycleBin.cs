using UnityEngine;

public class RecycleBin : MonoBehaviour, IJanitorInteractable
{
    public void Interact(JanitorController janitor)
    {
        janitor.DisposeTrash(TrashType.Recycle);
    }
}
