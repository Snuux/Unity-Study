using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    public class Coin : MonoBehaviour
    {
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }
    }
}   