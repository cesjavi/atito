using System;
using UnityEngine;

[Serializable]
public class MissionData
{
    public string missionId;
    public string title;
    [TextArea] public string description;
    public MissionState state;
    public int reward;
}

public enum MissionState
{
    NotStarted,
    InProgress,
    Completed,
    Failed
}
