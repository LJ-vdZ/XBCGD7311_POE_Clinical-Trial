using UnityEngine;

public class MedicalBin : MonoBehaviour, IJanitorInteractable
{
    public void Interact(JanitorController janitor)
    {
        janitor.DisposeTrash(TrashType.Medical);
    }
}
