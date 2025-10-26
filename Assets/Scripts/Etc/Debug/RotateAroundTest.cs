using UnityEngine;

public class RotateAroundTest : MonoBehaviour
{
    private const string MouseXAxis = "Mouse X";

    [SerializeField] Transform _rotationCenter;

    [SerializeField] float _angle;
    [SerializeField] float _step;
    [SerializeField] Vector3 _rotationAngle;

    [SerializeField] Vector3 _offset;

    private float _mouseInput;

    private void Update()
    {
        _mouseInput = Input.GetAxis(MouseXAxis) * Time.deltaTime;

        Quaternion rotationAngleFromMouse = Quaternion.Euler(0, _rotationCenter.rotation.eulerAngles.y + _mouseInput, 0);
        _rotationCenter.rotation = rotationAngleFromMouse;
        transform.position = _rotationCenter.forward * _offset.z + _rotationCenter.position + new Vector3(0, _offset.y, 0);

        Vector3 directionToRotationCenter = (_rotationCenter.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(directionToRotationCenter, Vector3.up);
    }
}
