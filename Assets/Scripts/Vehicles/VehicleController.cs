using UnityEngine;

public class VehicleController : MonoBehaviour, IInteractable
{
    [SerializeField] private string rivalName = "B-Boy Byte";
    [SerializeField] private MissionManager missionManager;
    [SerializeField] private int duelIndex;

    public string InteractionPrompt => $"Presiona F para retar a {rivalName}";

    public void Interact(GameObject interactor)
    {
        if (missionManager == null)
        {
            return;
        }

        missionManager.StartMission(duelIndex);
    }
}
