using UnityEngine;

public class SavedVariables : MonoBehaviour
{

    public static SavedVariables Instance { get; private set; }

    public int funds;
    public int morale;
    public int infectionRate;
    public int comfort;

    private void Awake()
    {
        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
