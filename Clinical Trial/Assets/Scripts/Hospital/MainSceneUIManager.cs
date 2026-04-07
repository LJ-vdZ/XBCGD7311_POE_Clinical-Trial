using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    public GameObject JobPanel;

    public Button nurseButton;
    public Button doctorButton;
    public Button janitorButton;

    public SimplePlayerMovement playerMovement;

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
        playerMovement.SetControlsLocked(false);
    }

    void OnDoctorClicked()
    {
        Debug.Log("Doctor button clicked");
    }

    void OnJanitorClicked()
    {
        Debug.Log("Janitor button clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
