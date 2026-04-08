using UnityEngine;
using UnityEngine.UI;

public class DoctorMinigame : MonoBehaviour
{
    [Header("UI")]
    public GameObject minigameUI;
    public Text symptomText;
    public Button[] treatmentButtons;

    [Header("Game Settings")]
    public float timeLimit = 10f;

    private string correctTreatment;
    private float timer;
    private bool isPlaying = false;

    // Called by YOUR interaction system
    public void StartGame()
    {
        minigameUI.SetActive(true);
        isPlaying = true;
        timer = timeLimit;

        GenerateCase();
    }

    void Update()
    {
        if (!isPlaying) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            EndGame(false); // failed
        }
    }

    void GenerateCase()
    {
        // SIMPLE EXAMPLE (expand later)
        int caseIndex = Random.Range(0, 2);

        if (caseIndex == 0)
        {
            symptomText.text = "Fever, cough, fatigue";
            correctTreatment = "Antibiotics";
        }
        else
        {
            symptomText.text = "Chest pain, shortness of breath";
            correctTreatment = "Oxygen";
        }
    }

    // Hook this to UI buttons
    public void SelectTreatment(string chosenTreatment)
    {
        if (!isPlaying) return;

        if (chosenTreatment == correctTreatment)
        {
            EndGame(true);
        }
        else
        {
            EndGame(false);
        }
    }

    void EndGame(bool success)
    {
        isPlaying = false;
        minigameUI.SetActive(false);

        if (success)
        {
            Debug.Log("Correct treatment!");

            //HospitalStatsManager.Instance.ChangeRecovery(+15);
            //HospitalStatsManager.Instance.ChangeReputation(+5);
        }
        else
        {
            Debug.Log("Wrong treatment!");

            //HospitalStatsManager.Instance.ChangeRecovery(-10);
            //HospitalStatsManager.Instance.ChangeSanitation(-5); // infection risk
        }
    }
}