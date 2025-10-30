using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    [RequireComponent(typeof(RigidbodyMovement))]
    [RequireComponent(typeof(RigidbodyJumping))]
    public class GroundParticles : MonoBehaviour
    {
        private RigidbodyMovement _playerMovement;
        private RigidbodyJumping _playerJumping;

        [SerializeField] private ParticleSystem _particleSystem;

        [SerializeField] private float _minSpeedToPlayParticleSystem;

        private void Awake()
        {
            _playerMovement = GetComponent<RigidbodyMovement>();
            _playerJumping = GetComponent<RigidbodyJumping>();
        }

        private void Update()
        {
            //_particleSystem.transform.Rotate(_playerMovement.MoveDirection, Space.World);

            if (_playerJumping.IsGrounded == false || _playerMovement.Speed < _minSpeedToPlayParticleSystem)
            {
                if (_particleSystem.isPlaying == true)
                    _particleSystem.Stop();
            }
            else if (_playerJumping.IsGrounded == true || _playerMovement.Speed > _minSpeedToPlayParticleSystem)
            {
                if (_particleSystem.isPlaying == false)
                    _particleSystem.Play();
            }

        }
    }
}