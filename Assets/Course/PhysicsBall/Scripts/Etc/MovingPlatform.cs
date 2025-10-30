using UnityEngine;
namespace Assets.Course.PhysicsBall
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Transform _endPosition;
        [SerializeField] private float _speed;

        private Vector3 _startPosition;
        private Vector3 _targetPosition;

        private float _positionDelta = .1f;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _startPosition = transform.position;
            _targetPosition = _endPosition.position;

            _rigidbody = GetComponent<Rigidbody>();
        }

        public void FixedUpdate()
        {
            Vector3 direction = _targetPosition - transform.position;
            _rigidbody.MovePosition(_rigidbody.position + direction.normalized * _speed * Time.fixedDeltaTime);

            if (direction.magnitude <= _positionDelta)
                ChangeTarget();
        }

        private void ChangeTarget()
        {
            Vector3 temp = _targetPosition;
            _targetPosition = _startPosition;
            _startPosition = temp;
        }
    }
}