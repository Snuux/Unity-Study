using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private RigidbodyMovement _playerMovement;
        [SerializeField] private Vector3 _cameraRotationOffset;
        [SerializeField] private float _stepSpeed;

        private void LateUpdate()
        {
            Vector3 newCameraPosition = _playerMovement.ForwardDirection * _cameraRotationOffset.z
                + _playerMovement.transform.position + new Vector3(0, _cameraRotationOffset.y, 0);
            transform.position = Vector3.Lerp(transform.position, newCameraPosition, _stepSpeed * Time.deltaTime);

            Vector3 directionCameraPlayer = (_playerMovement.transform.position - transform.position).normalized;
            Quaternion angleCameraPlayer = Quaternion.LookRotation(directionCameraPlayer, Vector3.up);
            transform.rotation = angleCameraPlayer;
        }
    }
}