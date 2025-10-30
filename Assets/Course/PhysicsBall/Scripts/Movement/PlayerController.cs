using System;
using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    [RequireComponent(typeof(RigidbodyMovement))]
    [RequireComponent(typeof(RigidbodyJumping))]
    public class PlayerController : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        private const string MouseXAxis = "Mouse X";
        private const KeyCode JumpKey = KeyCode.Space;

        private RigidbodyMovement _rigidbodyMovement;
        private RigidbodyJumping _rigidbodyJumping;

        [SerializeField] private float _mouseSensitivity;

        public bool IsPaused { get; set; }

        private void Awake()
        {
            _rigidbodyMovement = GetComponent<RigidbodyMovement>();
            _rigidbodyJumping = GetComponent<RigidbodyJumping>();

            IsPaused = false;
        }

        private void Update()
        {
            if (IsPaused == false)
            {
                ProcessMovement();
                ProcessJumping();
            }
        }

        private void ProcessJumping()
        {
            if (Input.GetKeyDown(JumpKey))
                _rigidbodyJumping.IsJumpPressed = true;

            if (Input.GetKeyUp(JumpKey))
                _rigidbodyJumping.IsJumpPressed = false;
        }

        private void ProcessMovement()
        {
            float xMouseInput = Input.GetAxis(MouseXAxis) * _mouseSensitivity * Time.deltaTime;
            float xKeyboardInput = Input.GetAxis(HorizontalAxis);
            float yKeyboardInput = Input.GetAxis(VerticalAxis);

            if (Math.Abs(Input.GetAxis(MouseXAxis)) < 0.02)
                xMouseInput = 0;

            _rigidbodyMovement.ControlsProcess(xMouseInput, xKeyboardInput, yKeyboardInput);
        }
    }
}
