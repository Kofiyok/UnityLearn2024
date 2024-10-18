using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _turnSpeed;

    private Rigidbody _tankBody;
    private float _movementInput;
    private float _turnInput;

    private void Start()
    {
        _tankBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _turnInput = Input.GetAxisRaw("Horizontal");
        _movementInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        MoveTank();
        RotateTank();
    }

    private void MoveTank()
    {
        Vector3 movement = _movementInput * _speed * transform.forward;
        _tankBody.AddForce(movement, ForceMode.Acceleration);
    }

    private void RotateTank()
    {
        float angle = _turnInput * _turnSpeed * Time.fixedDeltaTime;
        Quaternion turn = Quaternion.Euler(0, angle, 0);
        _tankBody.MoveRotation(_tankBody.rotation * turn);
    }
}
