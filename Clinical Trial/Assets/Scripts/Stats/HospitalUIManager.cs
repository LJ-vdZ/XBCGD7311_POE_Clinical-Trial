using UnityEngine;
using UnityEngine.UI;
using TMPro; // if you're using TextMeshPro

public class HospitalUIManager : MonoBehaviour
{
    [Header("Sliders")]
    public Slider sanitationSlider;
    public Slider comfortSlider;
    public Slider moraleSlider;

    [Header("Money UI")]
    public TextMeshProUGUI moneyText; // or use Text if not using TMP

    private void OnEnable()
    {
        HospitalStatsManager.OnStatsChanged += UpdateUI;
    }

    private void OnDisable()
    {
        HospitalStatsManager.OnStatsChanged -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI(); // update once at start
    }

    void UpdateUI()
    {
        var stats = HospitalStatsManager.Instance;

        // Update sliders (0–100)
        sanitationSlider.value = stats.sanitation;
        comfortSlider.value = stats.comfort;
        moraleSlider.value = stats.morale;

        // Update money (no slider)
        moneyText.text = "R" + stats.money.ToString();
    }
}