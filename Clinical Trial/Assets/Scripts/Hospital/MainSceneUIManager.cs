using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    public GameObject JobPanel;

    public Button nurseButton;
    public Button doctorButton;
    public Button janitorButton;

    public SimplePlayerMovement playerMovement;
    public JobSpawner jobSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nurseButton.onClick.AddListener(OnNurseClicked);
        doctorButton.onClick.AddListener(OnDoctorClicked);
        janitorButton.onClick.AddListener(OnJanitorClicked);
    }
    void OnNurseClicked()
    {
        Debug.Log("Nurse button clicked");
        jobSpawner.SpawnAtRandom(LocationType.Nurse);
        playerMovement.SetControlsLocked(false);
        JobPanel.SetActive(false);
    }

    void OnDoctorClicked()
    {
        Debug.Log("Doctor button clicked");
        jobSpawner.SpawnAtRandom(LocationType.Doctor);
        playerMovement.SetControlsLocked(false);
        JobPanel.SetActive(false);
    }

    void OnJanitorClicked()
    {
        Debug.Log("Janitor button clicked");
        jobSpawner.SpawnAtRandom(LocationType.Janitor);
        playerMovement.SetControlsLocked(false);
        JobPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
