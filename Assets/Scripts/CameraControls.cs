using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float _sensivity;
    [SerializeField] private Transform _pivot;
    [SerializeField] private float _turretTurnSpeed;

    private float _turnInput;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _turnInput = Input.GetAxisRaw("Mouse X");
        RotateCamera();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _pivot.rotation, _turretTurnSpeed * Time.fixedDeltaTime);
        MoveCamera();
    }

    private void RotateCamera()
    {
        float angle = _turnInput * _sensivity;
        Quaternion turn = Quaternion.Euler(0, angle, 0);
        _pivot.rotation *= turn;
    }

    private void MoveCamera()
    {
        _pivot.position = Vector3.Lerp(_pivot.position, transform.position, 0.1f);
    }
    
}
