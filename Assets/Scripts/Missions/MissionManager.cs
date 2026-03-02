using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<MissionData> missions = new();

    public MissionData CurrentMission { get; private set; }

    private int _currentIndex;

    private void Start()
    {
        if (missions.Count == 0)
        {
            return;
        }

        StartMission(0);
    }

    public void StartMission(int index)
    {
        if (index < 0 || index >= missions.Count)
        {
            return;
        }

        _currentIndex = index;
        CurrentMission = missions[_currentIndex];
        CurrentMission.state = MissionState.InProgress;
    }

    public void CompleteCurrentMission()
    {
        if (CurrentMission == null || CurrentMission.state != MissionState.InProgress)
        {
            return;
        }

        CurrentMission.state = MissionState.Completed;
        GameManager.Instance?.AddMoney(CurrentMission.reward);

        int next = _currentIndex + 1;
        if (next < missions.Count)
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

        CurrentMission.state = MissionState.Failed;
    }
}
