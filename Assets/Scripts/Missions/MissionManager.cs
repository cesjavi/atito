using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<MissionData> duels = new();
    [SerializeField] private PlayerController player;

    public MissionData CurrentMission { get; private set; }
    public int CurrentStylePoints { get; private set; }

    private int _currentIndex;

    private void OnEnable()
    {
        if (player != null)
        {
            player.ComboPerformed += OnComboPerformed;
        }
    }

    private void OnDisable()
    {
        if (player != null)
        {
            player.ComboPerformed -= OnComboPerformed;
        }
    }

    private void Start()
    {
        if (duels.Count == 0)
        {
            return;
        }

        StartMission(0);
    }

    public void StartMission(int index)
    {
        if (index < 0 || index >= duels.Count)
        {
            return;
        }

        _currentIndex = index;
        CurrentMission = duels[_currentIndex];
        CurrentMission.state = DuelState.InProgress;
        CurrentStylePoints = 0;
    }

    private void OnComboPerformed(string comboName)
    {
        if (CurrentMission == null || CurrentMission.state != DuelState.InProgress)
        {
            return;
        }

        int comboValue = comboName switch
        {
            "Headspin" => 40,
            "Windmill" => 30,
            _ => 20
        };

        CurrentStylePoints += comboValue;

        if (CurrentStylePoints >= CurrentMission.requiredStylePoints)
        {
            CompleteCurrentMission();
        }
    }

    public void CompleteCurrentMission()
    {
        if (CurrentMission == null || CurrentMission.state != DuelState.InProgress)
        {
            return;
        }

        CurrentMission.state = DuelState.Won;
        GameManager.Instance?.AddHype(CurrentMission.hypeReward);
        GameManager.Instance?.RegisterVictory();

        int next = _currentIndex + 1;
        if (next < duels.Count)
        {
            StartMission(next);
        }
    }

    public void FailCurrentMission()
    {
        if (CurrentMission == null)
        {
            return;
        }

        CurrentMission.state = DuelState.Lost;
    }
}
