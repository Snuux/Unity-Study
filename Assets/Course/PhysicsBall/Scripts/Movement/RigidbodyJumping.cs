using UnityEngine;
namespace Assets.Course.PhysicsBall
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyJumping : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _jumpGravity;

        public bool IsJumpPressed { get; set; }
        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            DebugDrawVectors();
        }

        private void FixedUpdate()
        {
            JumpProcess();
            MoreGravity();
        }

        private void JumpProcess()
        {
            if (IsJumpPressed && IsGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                IsJumpPressed = false;
            }
        }

        private void MoreGravity()
        {
            if (IsGrounded == false)
                _rigidbody.AddForce(-Vector3.up * _jumpGravity, ForceMode.Force);
        }

        private void OnCollisionEnter(Collision collision)
        {
            SetGrounded(collision, true);
        }

        private void OnCollisionStay(Collision collision)
        {
            SetGrounded(collision, true);
        }

        private void OnCollisionExit(Collision collision)
        {
            SetGrounded(collision, false);
        }

        private void SetGrounded(Collision collision, bool shouldBeGrounded)
        {
            if (collision.gameObject.GetComponent<Ground>() != null)
                IsGrounded = shouldBeGrounded;
        }

        private void DebugDrawVectors()
        {
            float debugVectorsRadius = 3;

            if (IsJumpPressed || !IsGrounded)
                Debug.DrawRay(transform.position, Vector3.up * debugVectorsRadius, Color.red);
        }
    }
}