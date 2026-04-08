using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{

    //Job Panel UI
    public GameObject JobPanel;
    public Button nurseButton;
    public Button doctorButton;
    public Button janitorButton;
    public Button JobSelectorCloseButton;

    //Information Panel UI
    public Button InfoCloseButton;
    public GameObject InfoPanel;

    public SimplePlayerMovement playerMovement;
    public JobSpawner jobSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nurseButton.onClick.AddListener(OnNurseClicked);
        doctorButton.onClick.AddListener(OnDoctorClicked);
        janitorButton.onClick.AddListener(OnJanitorClicked);
        JobSelectorCloseButton.onClick.AddListener(OnJobCloseClicked);
        InfoCloseButton.onClick.AddListener(OnInfoCloseClicked);
    }

    void OnNurseClicked()
    {
        Debug.Log("Nurse button clicked");
        jobSpawner.SpawnAtRandom(LocationType.Nurse);
    }

    void OnDoctorClicked()
    {
        Debug.Log("Doctor button clicked");
        jobSpawner.SpawnAtRandom(LocationType.Doctor);

    }

    void OnJanitorClicked()
    {
        Debug.Log("Janitor button clicked");
        jobSpawner.SpawnAtRandom(LocationType.Janitor);

    }
    void OnJobCloseClicked()
    {
        Debug.Log("Close button clicked");
        playerMovement.SetControlsLocked(false);
        JobPanel.SetActive(false);
    }
    public void OnJobOpen()
    {
        Debug.Log("Open button clicked");
        playerMovement.SetControlsLocked(true);
        JobPanel.SetActive(true);
    }

    void OnInfoCloseClicked()
    {
        InfoPanel.SetActive(false);
        playerMovement.SetControlsLocked(false);
        JobPanel.SetActive(false);
    }

    void OnInfoOpenClicked()
    {
        InfoPanel.SetActive(true);
        JobPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnInfoOpenClicked();
            playerMovement.SetControlsLocked(true);
        }
    }
}
