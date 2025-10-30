using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    public class CoinInteractor : MonoBehaviour
    {
        [SerializeField] CoinsWallet _wallet;

        private void OnTriggerEnter(Collider other)
        {
            Coin coin = other.GetComponent<Coin>();

            if (coin != null)
            {
                _wallet.AddCoin(coin);
            }
        }
    }
}
