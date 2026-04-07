using UnityEngine;

public class MiniGameStart : MonoBehaviour
{
    public string jobType = "Nurse";
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("transtion to " + jobType + " mini-game");
            Destroy(gameObject);
        }
    }
}
