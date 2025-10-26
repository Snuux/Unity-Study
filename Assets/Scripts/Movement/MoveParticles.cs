using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerJumping))]
public class MoveParticles : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerJumping _playerJumping;

    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Vector3 _particleSystemOffset;

    [SerializeField] private float _minSpeedToPlayParticleSystem;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerJumping = GetComponent<PlayerJumping>();
    }

    private void Update()
    {
        _particleSystem.transform.position = _particleSystemOffset + _playerMovement.transform.position;
        _particleSystem.transform.Rotate(_playerMovement.MoveDirection, Space.World);

        if (_playerJumping.IsGrounded == false || _playerMovement.Speed() < _minSpeedToPlayParticleSystem)
        {
            if (_particleSystem.isPlaying == true)
                _particleSystem.Stop(); 
        }
        else if (_playerJumping.IsGrounded == true || _playerMovement.Speed() > _minSpeedToPlayParticleSystem)
        {
            if (_particleSystem.isPlaying == false)
                _particleSystem.Play();
        }

    }
}
