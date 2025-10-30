using UnityEngine;
namespace Assets.Course.PhysicsBall
{
    public class RigidbodyMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        [SerializeField] private float _speed;
        [SerializeField] private float _maxSpeed;

        private Vector3 _defaultPosition;
        private Quaternion _defaultRotation;

        private Vector3 _forwardDirection;
        private Vector3 _moveDirection;

        public Vector3 ForwardDirection => _forwardDirection;
        public Vector3 MoveDirection => _moveDirection;
        public float Speed => _rigidbody.velocity.magnitude;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _forwardDirection = Vector3.forward;
            _defaultPosition = transform.position;
            _defaultRotation = transform.rotation;
        }

        private void Update()
        {
            DebugDrawVectors();
        }

        private void FixedUpdate()
        {
            MoveProcess();
            LimitMaxSpeed();
        }

        public void ControlsProcess(float xMouseInput, float xKeyboardInput, float yKeyboardInput)
        {
            _forwardDirection = Quaternion.Euler(0, xMouseInput, 0) * _forwardDirection;
            Vector3 _inputRawDirection = new Vector3(xKeyboardInput, 0, yKeyboardInput);
            _moveDirection = Quaternion.LookRotation(_forwardDirection.normalized) * _inputRawDirection.normalized;
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

        public void ResetPosition()
        {
            transform.position = _defaultPosition;
            transform.rotation = _defaultRotation;

            _rigidbody.isKinematic = false;
        }

        public void Stop()
        {
            _rigidbody.isKinematic = true;
        }
    }
}