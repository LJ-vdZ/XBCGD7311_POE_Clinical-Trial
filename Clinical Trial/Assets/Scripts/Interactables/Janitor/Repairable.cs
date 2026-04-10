using UnityEngine;
using System.Collections;

public class Repairable : MonoBehaviour, IInteractable
{
    [Header("Repair Settings")]
    public int resourceCost = 25;
    public float comfortGain = 18f;

    [Header("Visual Replacement (Optional)")]
    public GameObject repairedPrefab;

    [Header("Repair Feedback")]
    public float repairDelay = 1.2f;

    public void Interact(RoleType role)
    {
        // Only Janitor can repair
        if (role != RoleType.Janitor)
        {
            Debug.Log("Only a Janitor can repair this!");
            return;
        }

        // Spend money using your new system
        bool success = HospitalStatsManager.Instance.SpendMoney(resourceCost);

        if (success)
        {
            StartCoroutine(DoRepair());
        }
        else
        {
            Debug.Log("Not enough money. Ask the Manager.");
        }
    }

    private IEnumerator DoRepair()
    {
        // Optional: play animation / sound here

        yield return new WaitForSeconds(repairDelay);

        // Increase comfort stat
        HospitalStatsManager.Instance.ChangeComfort(comfortGain);

        Debug.Log("Repair completed! +" + comfortGain + " Comfort");

        ReplaceWithRepairedVersion();
    }

    private void ReplaceWithRepairedVersion()
    {
        if (repairedPrefab != null)
        {
            Instantiate(repairedPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}