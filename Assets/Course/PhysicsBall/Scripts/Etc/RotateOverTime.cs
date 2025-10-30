using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationAmount;

    private void Awake()
    {
        Vector3 randomOffsetRotatonAmount = new Vector3(
            Random.Range(0, _rotationAmount.x),
            Random.Range(0, _rotationAmount.y),
            Random.Range(0, _rotationAmount.z));

        transform.Rotate(randomOffsetRotatonAmount);
    }

    void Update()
    {
        transform.Rotate(_rotationAmount *  Time.deltaTime);
    }
}
