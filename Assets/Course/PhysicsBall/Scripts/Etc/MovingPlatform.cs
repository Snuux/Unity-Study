using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private float _positionDelta = .05f;

    private void Awake()
    {
        _startPosition = transform.position;
        _targetPosition = _endPosition.position;
    }

    public void Update()
    {
        transform.position = Vector3.Slerp(transform.position, _targetPosition, _speed * Time.deltaTime);

        if ((transform.position - _targetPosition).magnitude <= _positionDelta)
            ChangeTarget();
    }

    private void ChangeTarget()
    {
        Vector3 temp = _targetPosition;
        _targetPosition = _startPosition;
        _startPosition = temp;
    }

    /* ? ??????? ??????? ????? rigidbody ??? ?? ?????????? ???????? ??????...
     * private void OnCollisionStay(Collision collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            Rigidbody playerRigidbody = playerMovement.GetComponent<Rigidbody>();

            Vector3 newYVectorPlayer = playerRigidbody.position;
            newYVectorPlayer.y += transform.position.y;

            playerRigidbody.MovePosition(newYVectorPlayer);
        }
    }*/
}
