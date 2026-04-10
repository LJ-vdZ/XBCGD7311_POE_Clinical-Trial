using UnityEngine;

public class Generator : MonoBehaviour, IInteractable
{
    public void Interact(RoleType role)
    {
        // Only Janitor can use generator
        if (role != RoleType.Janitor)
        {
            Debug.Log("Only a Janitor can fix the generator!");
            return;
        }

        // Check if power is out
        if (GameManager.Instance != null && GameManager.Instance.isPowerOut)
        {
            if (GeneratorPuzzleManager.Instance != null)
            {
                GeneratorPuzzleManager.Instance.StartPuzzle(this);
                Debug.Log("Generator puzzle started!");
            }
            else
            {
                Debug.LogError("GeneratorPuzzleManager not found in scene!");
            }
        }
        else
        {
            Debug.Log("Power is already on.");
        }
    }

    // Called when puzzle is solved
    public void CompletePuzzle()
    {
        Debug.Log("Generator puzzle completed successfully!");

        // Turn power back on
        if (GameManager.Instance != null)
        {
            GameManager.Instance.isPowerOut = false;
        }

        // Optional: reward player
        HospitalStatsManager.Instance.ChangeMorale(+10);

        // Optional: play sound / particles here
    }
}