using UnityEngine;
using UnityEngine.UI;

public class NurseMinigame : MonoBehaviour
{
    [Header("UI")]
    public GameObject minigameUI;
    public RectTransform needle;
    public RectTransform targetZone;

    [Header("Settings")]
    public float needleSpeed = 300f;
    public float targetMoveSpeed = 100f;

    private bool movingRight = true;
    private bool isPlaying = false;

    public void StartGame()
    {
        minigameUI.SetActive(true);
        isPlaying = true;

        // Randomize target position
        SetRandomTargetPosition();
    }

    void Update()
    {
        if (!isPlaying) return;

        MoveNeedle();
        MoveTarget();

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckHit();
        }
    }

    void MoveNeedle()
    {
        float move = needleSpeed * Time.deltaTime;

        if (movingRight)
            needle.anchoredPosition += Vector2.right * move;
        else
            needle.anchoredPosition += Vector2.left * move;

        // Bounce logic
        if (needle.anchoredPosition.x > 300f)
            movingRight = false;
        else if (needle.anchoredPosition.x < -300f)
            movingRight = true;
    }

    void MoveTarget()
    {
        // Optional: moving vein (hard mode)
        float move = Mathf.Sin(Time.time) * targetMoveSpeed * Time.deltaTime;
        targetZone.anchoredPosition += Vector2.right * move;
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-200f, 200f);
        targetZone.anchoredPosition = new Vector2(randomX, targetZone.anchoredPosition.y);
    }

    void CheckHit()
    {
        float distance = Mathf.Abs(needle.anchoredPosition.x - targetZone.anchoredPosition.x);

        if (distance < 20f)
        {
            EndGame("Perfect");
        }
        else if (distance < 50f)
        {
            EndGame("Good");
        }
        else
        {
            EndGame("Miss");
        }
    }

    void EndGame(string result)
    {
        isPlaying = false;
        minigameUI.SetActive(false);

        switch (result)
        {
            case "Perfect":
                //HospitalStatsManager.Instance.ChangeRecovery(+15);
                //HospitalStatsManager.Instance.ChangeReputation(+10);
                break;

            case "Good":
                //HospitalStatsManager.Instance.ChangeRecovery(+8);
                break;

            case "Miss":
                //HospitalStatsManager.Instance.ChangeRecovery(-5);
                //HospitalStatsManager.Instance.ChangeSanitation(-5); // infection risk
                break;
        }

        Debug.Log("Result: " + result);
    }
}