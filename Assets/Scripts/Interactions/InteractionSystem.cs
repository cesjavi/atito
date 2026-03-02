using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private LayerMask interactionMask = ~0;

    public IInteractable CurrentTarget { get; private set; }

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        UpdateCurrentTarget();

        if (Input.GetKeyDown(KeyCode.E) && CurrentTarget != null)
        {
            CurrentTarget.Interact(gameObject);
        }
    }

    private void UpdateCurrentTarget()
    {
        CurrentTarget = null;

        if (_camera == null)
        {
            return;
        }

        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        if (!Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactionMask))
        {
            return;
        }

        CurrentTarget = hit.collider.GetComponentInParent<IInteractable>();
    }
}
