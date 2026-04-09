using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Hospital Status")]
    public float hygiene = 75f;
    public float comfort = 70f;
    public float safety = 80f;
    public int resources = 150;

    [Header("UI")]
    public TextMeshProUGUI hygieneText;
    public TextMeshProUGUI comfortText;
    public TextMeshProUGUI safetyText;
    public TextMeshProUGUI resourcesText;

    [Header("Power Outage Settings")]
    public bool isPowerOut = false;
    public bool isPuzzleActive = false;           //used by puzzle
    public float outageDecayRate = 4f;            //speed of decay for comfort, hygiene, safety, etc.
    public float timeUntilFirstOutage = 120f;
    public float outageMaxTime = 60f;

    [Header("UI Outage")]
    public TextMeshProUGUI outageTimerText;

    [Header("Lights")]
    public Light[] hospitalLights;

    private float currentOutageTime;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Invoke("StartPowerOutage", timeUntilFirstOutage);
        UpdateUI();
    }

    void Update()
    {
        if (isPowerOut && !isPuzzleActive)
        {
            currentOutageTime += Time.deltaTime;

            //balanced slow decay during outage
            ModifySafety(-1.8f * Time.deltaTime);    //safety drops fastest 
            ModifyComfort(-1.3f * Time.deltaTime);   //comfort drops medium
            ModifyHygiene(-1.0f * Time.deltaTime);   //hygiene drops slowest

            if (outageTimerText)
            {
                float timeLeft = Mathf.Max(0, outageMaxTime - currentOutageTime);
                outageTimerText.text = $"POWER OUTAGE\n{timeLeft:F0}s";
                outageTimerText.gameObject.SetActive(true);
            }

            //timer runs out, big penalty
            if (currentOutageTime >= outageMaxTime)
            {
                ModifySafety(-40f);
                ModifyComfort(-30f);
                ModifyHygiene(-25f);
                EndPowerOutage();
            }
        }
        else if (outageTimerText && !isPuzzleActive)
        {
            outageTimerText.gameObject.SetActive(false);
        }

        UpdateUI();

        //game over check if any of percentages become zero or if time runs out and power isn't back on
        if (hygiene <= 0 || comfort <= 0 || safety <= 0)
        {
            //show Game Over scene here
            Debug.Log("Game Over - Hospital shutdown");
            
        }
    }

    public void ModifyHygiene(float amount) => hygiene = Mathf.Clamp(hygiene + amount, 0, 100);
    public void ModifyComfort(float amount) => comfort = Mathf.Clamp(comfort + amount, 0, 100);
    public void ModifySafety(float amount) => safety = Mathf.Clamp(safety + amount, 0, 100);

    public bool SpendResources(int amount)
    {
        if (resources >= amount)
        {
            resources -= amount;
            return true;
        }
        return false;
    }

    private void StartPowerOutage()
    {
        isPowerOut = true;
        currentOutageTime = 0f;

        foreach (var light in hospitalLights)
            if (light != null) light.enabled = false;

        Debug.Log("POWER OUTAGE STARTED!");
    }

    public void EndPowerOutage()
    {
        isPowerOut = false;
        isPuzzleActive = false;

        foreach (var light in hospitalLights)
            if (light != null) light.enabled = true;
    }

    void UpdateUI()
    {
        if (hygieneText) hygieneText.text = $"Hygiene: {hygiene:F0}%";
        if (comfortText) comfortText.text = $"Comfort: {comfort:F0}%";
        if (safetyText) safetyText.text = $"Safety: {safety:F0}%";
        if (resourcesText) resourcesText.text = $"Resources: {resources}";
    }
}
