using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    private const string MouseXAxis = "Mouse X";

    private Rigidbody _rigidbody;

    private float _xKeyboardInput;
    private float _yKeyboardInput;
    private float _xMouseInput;

    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _mouseSensitivity;

    private Vector3 _defaultPosition;
    private Quaternion _defaultRotation;

    private Vector3 _forwardDirection;
    private Vector3 _moveDirection;
    public Vector3 ForwardDirection => _forwardDirection;
    public Vector3 MoveDirection => _moveDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _forwardDirection = Vector3.forward;
        _defaultPosition = transform.position;
        _defaultRotation = transform.rotation;
    }

    private void Update()
    {
        _xKeyboardInput = Input.GetAxis(HorizontalAxis);
        _yKeyboardInput = Input.GetAxis(VerticalAxis);
        _xMouseInput = Input.GetAxis(MouseXAxis) * _mouseSensitivity * Time.deltaTime;

        _forwardDirection = Quaternion.Euler(0, _xMouseInput, 0) * _forwardDirection;
        Vector3 _inputRawDirection = new Vector3(_xKeyboardInput, 0, _yKeyboardInput);
        _moveDirection = Quaternion.LookRotation(_forwardDirection.normalized) * _inputRawDirection.normalized;

        DebugDrawVectors();
    }

    private void FixedUpdate()
    {
        MoveProcess();
        LimitMaxSpeed();
    }

    private void MoveProcess()
    {
        _rigidbody.AddForce(_moveDirection.normalized * _speed, ForceMode.Force);
    }

    private void LimitMaxSpeed()
    {
        if (_rigidbody.velocity.magnitude > _maxSpeed)
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
    }

    private void DebugDrawVectors()
    {
        Debug.DrawRay(transform.position, _forwardDirection * 3, Color.green);
        Debug.DrawRay(transform.position, _moveDirection * 3, Color.cyan);
    }

    public float Speed()
    {
        return _rigidbody.velocity.magnitude;
    }

    public void ResetPosition()
    {
        _rigidbody.isKinematic = true;
        _xKeyboardInput = 0;
        _yKeyboardInput = 0;
        _xMouseInput = 0;

        //_forwardDirection = _defaultTransform.forward;
        transform.position = _defaultPosition;
        transform.rotation = _defaultRotation;

        //_rigidbody.MovePosition(_defaultTransform.position);
        //_rigidbody.MoveRotation(_defaultTransform.rotation);

        _rigidbody.isKinematic = false;
    }
}
