using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class CameraFollower : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _cameraRotationOffset;

    [SerializeField] private float _stepSpeed;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();    
    }

    private void LateUpdate()
    {
        Vector3 newCameraPosition = _playerMovement.ForwardDirection.normalized * _cameraRotationOffset.z
            + transform.position + new Vector3(0, _cameraRotationOffset.y, 0);
        _camera.position = Vector3.Slerp(_camera.position, newCameraPosition, _stepSpeed * Time.deltaTime);

        Vector3 directionCameraPlayer = (transform.position - _camera.position).normalized;
        Quaternion angleCameraPlayer = Quaternion.LookRotation(directionCameraPlayer, Vector3.up);
        _camera.rotation = angleCameraPlayer; //Quaternion.RotateTowards(_camera.rotation, q, _stepSpeed * Time.deltaTime);

        //Debug.DrawRay(_camera.position, _camera.rotation.eulerAngles.normalized * 5, Color.cyan);
        //Debug.DrawRay(_camera.position, directionFromCameraToHero * 7, Color.green);
    }
}
