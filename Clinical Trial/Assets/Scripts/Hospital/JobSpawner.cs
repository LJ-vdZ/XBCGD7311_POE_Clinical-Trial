using System.Collections.Generic;
using UnityEngine;

public class JobSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnPoints;

    [SerializeField] private GameObject nursePrefab;
    [SerializeField] private GameObject janitorPrefab;
    [SerializeField] private GameObject doctorPrefab;
    [SerializeField] private GameObject managerPrefab;

    private List<JobSpawnPoint> nurseList = new List<JobSpawnPoint>();

    int nurseIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++) {
            JobSpawnPoint jobSpawnPoint = spawnPoints[i].GetComponent<JobSpawnPoint>();
            if (jobSpawnPoint.locationType == LocationType.Nurse)
            {
                nurseList.Add(spawnPoints[i].GetComponent<JobSpawnPoint>());
                nurseIndex++;
            }
        }
        int randomNumber = Random.Range(0, nurseList.Count);
        int randomNum = nurseList.Count;
        Instantiate(nursePrefab, nurseList[randomNumber].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
