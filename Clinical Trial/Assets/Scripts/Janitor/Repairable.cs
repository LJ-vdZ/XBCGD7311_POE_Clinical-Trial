using UnityEngine;

public class Repairable : MonoBehaviour, IJanitorInteractable
{
    [Header("Repair Settings")]
    public int resourceCost = 25;
    public float comfortGain = 18f;

    [Header("Visual Replacement (Optional)")]
    public GameObject repairedPrefab;        //repaired object version

    [Header("Repair Feedback")]
    public float repairDelay = 1.2f;         //small delay, can add sound or dust effects during this delay

    public void Interact(JanitorController janitor)
    {
        //spend money for repairs
        if (GameManager.Instance.SpendResources(resourceCost))
        {
            StartCoroutine(DoRepair());
        }
        else
        {
            Debug.Log("Not enough money. Ask the Manager.");
        }
    }

    private System.Collections.IEnumerator DoRepair()
    {
        //can add sound or particle effects here

        yield return new WaitForSeconds(repairDelay);

        //increase comfort percentage
        GameManager.Instance.ModifyComfort(comfortGain);

        Debug.Log("Repair completed! +" + comfortGain + " Comfort");

        ReplaceWithRepairedVersion();
    }

    private void ReplaceWithRepairedVersion()
    {
        if (repairedPrefab != null)
        {
            //spawn repaired object prefab at same position and rotation
            Instantiate(repairedPrefab, transform.position, transform.rotation);
        }

        //destroy broken version
        Destroy(gameObject);
    }
}
