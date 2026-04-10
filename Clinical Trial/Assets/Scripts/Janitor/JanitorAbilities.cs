using UnityEngine;

public class JanitorAbilities : MonoBehaviour
{
    [Header("Holding")]
    public Transform attachPoint;

    public TrashItem heldTrash = null;

    // --- TRASH SYSTEM ---

    public void PickUpTrash(TrashItem trash)
    {
        if (heldTrash != null) return;

        heldTrash = trash;
        trash.transform.SetParent(attachPoint);
        trash.transform.localPosition = Vector3.zero;
        trash.transform.localRotation = Quaternion.identity;

        Debug.Log($"Picked up {trash.type}");
    }

    public void DisposeTrash(TrashType requiredType)
    {
        if (heldTrash == null) return;

        if (heldTrash.type == requiredType)
            HospitalStatsManager.Instance.ChangeSanitation(+12f);
        else
            HospitalStatsManager.Instance.ChangeSanitation(-20f);

        Destroy(heldTrash.gameObject);
        heldTrash = null;

        Debug.Log("Trash disposed");
    }

    public void DropTrash()
    {
        if (heldTrash == null) return;

        heldTrash.transform.SetParent(null);
        heldTrash.transform.position = transform.position + transform.forward * 1.5f;

        heldTrash = null;
    }
}