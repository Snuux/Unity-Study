using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    public class FollowTransform : MonoBehaviour
    {
        [SerializeField] private Transform _source;
        [SerializeField] private Vector3 _offset;

        [SerializeField] private bool useTransform;
        [SerializeField] private bool useRotation;

        private void LateUpdate()
        {
            if (useTransform)
                transform.position = _source.position + _offset;

            if (useRotation)
                transform.rotation = _source.rotation;
        }
    }
}