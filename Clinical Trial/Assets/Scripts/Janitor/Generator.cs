using UnityEngine;

public class Generator : MonoBehaviour, IJanitorInteractable
{
    public void Interact(JanitorController janitor)
    {
        if (GameManager.Instance.isPowerOut)
        {
            // Safe check before starting puzzle
            if (GeneratorPuzzleManager.Instance != null)
            {
                GeneratorPuzzleManager.Instance.StartPuzzle(this);
                Debug.Log("Generator puzzle started!");
            }
            else
            {
                Debug.LogError("GeneratorPuzzleManager.Instance is null! Make sure the script is attached to the GeneratorPuzzleUI Canvas.");
            }
        }
        else
        {
            Debug.Log("Power is already on.");
        }
    }

    //Called when puzzle is solved
    public void CompletePuzzle()
    {
        Debug.Log("Generator puzzle completed successfully!");
        
        //can add particles or sound here
    }
}
