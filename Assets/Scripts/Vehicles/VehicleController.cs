using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour, IInteractable
{
    [SerializeField] private float acceleration = 1800f;
    [SerializeField] private float steering = 40f;

    public string InteractionPrompt => _driver == null ? "Presiona E para conducir" : "Vehículo en uso";

    private Rigidbody _rb;
    private GameObject _driver;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_driver == null)
        {
            return;
        }

        float throttle = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        _rb.AddForce(transform.forward * (throttle * acceleration * Time.fixedDeltaTime), ForceMode.Acceleration);
        Quaternion steerRotation = Quaternion.Euler(0f, turn * steering * Time.fixedDeltaTime, 0f);
        _rb.MoveRotation(_rb.rotation * steerRotation);
    }

    public void Interact(GameObject interactor)
    {
        if (_driver != null)
        {
            return;
        }

        _driver = interactor;
        interactor.SetActive(false);
    }

    public void ExitVehicle(Vector3 exitPosition)
    {
        if (_driver == null)
        {
            return;
        }

        _driver.transform.position = exitPosition;
        _driver.SetActive(true);
        _driver = null;
    }
}
