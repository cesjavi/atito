using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int CrowdHype { get; private set; }
    public int Victories { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddHype(int amount)
    {
        CrowdHype = Mathf.Max(0, CrowdHype + amount);
    }

    public void RegisterVictory()
    {
        Victories++;
    }
}
