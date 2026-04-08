using UnityEngine;
using System;

public class HospitalStatsManager : MonoBehaviour
{
    public static HospitalStatsManager Instance;

    // Stats
    public float sanitation = 100f;
    public float patientRecovery = 100f;
    public float infrastructure = 100f;
    public float reputation = 100f;

    // Event for UI updates
    public static Action OnStatsChanged;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Methods to modify stats
    public void ChangeSanitation(float amount)
    {
        sanitation += amount;
        sanitation = Mathf.Clamp(sanitation, 0, 100);
        OnStatsChanged?.Invoke();
    }

    public void ChangeRecovery(float amount)
    {
        patientRecovery += amount;
        patientRecovery = Mathf.Clamp(patientRecovery, 0, 100);
        OnStatsChanged?.Invoke();
    }

    public void ChangeInfrastructure(float amount)
    {
        infrastructure += amount;
        infrastructure = Mathf.Clamp(infrastructure, 0, 100);
        OnStatsChanged?.Invoke();
    }

    public void ChangeReputation(float amount)
    {
        reputation += amount;
        reputation = Mathf.Clamp(reputation, 0, 100);
        OnStatsChanged?.Invoke();
    }
}