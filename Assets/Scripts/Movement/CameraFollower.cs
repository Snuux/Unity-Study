using UnityEngine;

[RequireComponent(typeof(RigidbodyMovement))]
public class CameraFollower : MonoBehaviour
{
    private RigidbodyMovement _playerMovement;

    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _cameraRotationOffset;

    [SerializeField] private float _stepSpeed;

    private void Awake()
    {
        _playerMovement = GetComponent<RigidbodyMovement>();    
    }

    private void LateUpdate()
    {
        Vector3 newCameraPosition = _playerMovement.ForwardDirection * _cameraRotationOffset.z
            + transform.position + new Vector3(0, _cameraRotationOffset.y, 0);
        _camera.position = newCameraPosition;
        //Vector3.Lerp(_camera.position, newCameraPosition, _stepSpeed * Time.deltaTime);

        Vector3 directionCameraPlayer = (transform.position - _camera.position).normalized;
        Quaternion angleCameraPlayer = Quaternion.LookRotation(directionCameraPlayer, Vector3.up);
        _camera.rotation = angleCameraPlayer; //Quaternion.RotateTowards(_camera.rotation, angleCameraPlayer, _stepSpeed * Time.deltaTime);
        //_camera.rotation = Quaternion.Lerp(_camera.rotation, angleCameraPlayer, _stepSpeed * Time.deltaTime);

        //Debug.DrawRay(_camera.position, _camera.rotation.eulerAngles.normalized * 5, Color.cyan);
        //Debug.DrawRay(_camera.position, directionFromCameraToHero * 7, Color.green);
    }
}
