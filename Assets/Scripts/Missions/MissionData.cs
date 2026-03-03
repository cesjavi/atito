using System;
using UnityEngine;

[Serializable]
public class MissionData
{
    public string duelId;
    public string title;
    [TextArea] public string rivalStyle;
    public DuelState state;
    public int requiredStylePoints;
    public int hypeReward;
}

public enum DuelState
{
    NotStarted,
    InProgress,
    Won,
    Lost
}
