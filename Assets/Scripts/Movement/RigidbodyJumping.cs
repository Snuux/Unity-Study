using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyJumping : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;

    private Rigidbody _rigidbody;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpGravity;

    private bool _isJumpPressed;
    private bool _isGrounded;

    public bool IsJumpPressed => _isJumpPressed;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            _isJumpPressed = true;

        DebugDrawVectors();
    }

    private void FixedUpdate()
    {
        JumpProcess();
        FallProcess();
    }

    private void JumpProcess()
    {
        if (_isJumpPressed && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumpPressed = false;
        }
    }

    private void FallProcess()
    {
        if (_isGrounded == false)
        {
            _rigidbody.AddForce(-Vector3.up * _jumpGravity, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        SetGrounded(collision, true);
    }

    void OnCollisionStay(Collision collision)
    {
        SetGrounded(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        SetGrounded(collision, false);
    }

    void SetGrounded(Collision collision, bool shouldBeGrounded)
    {
        if (collision.gameObject.GetComponent<CollisionChecker>() != null)
            _isGrounded = shouldBeGrounded;
    }

    void DebugDrawVectors()
    {
        float debugVectorsRadius = 3;

        if (_isJumpPressed || !_isGrounded)
            Debug.DrawRay(transform.position, Vector3.up * debugVectorsRadius, Color.red);
    }
}
