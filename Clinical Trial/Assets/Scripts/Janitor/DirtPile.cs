using UnityEngine;

public class DirtPile : MonoBehaviour, IJanitorInteractable
{
    public void Interact(JanitorController janitor)
    {
        if (janitor != null)
        {
            //Add your sweep animation call here later
            
            GameManager.Instance.ModifyHygiene(10f);
            
            Destroy(gameObject, 1.5f);
            
            Debug.Log("Dirt cleaned! +Hygiene");
        }
    }
}
