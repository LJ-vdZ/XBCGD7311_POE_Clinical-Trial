using UnityEngine;

public class DirtPile : MonoBehaviour, IInteractable
{
    public void Interact(RoleType role)
    {
        if (role == RoleType.Janitor)
        {
            //Add your sweep animation call here later
            HospitalStatsManager.Instance.ChangeSanitation(+15);
            Destroy(gameObject, 1.5f);
            
            Debug.Log("Dirt cleaned! +Hygiene");
        }
    }
}
