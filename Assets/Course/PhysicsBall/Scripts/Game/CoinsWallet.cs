using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    public class CoinsWallet : MonoBehaviour
    {
        public int Count { get; private set; }

        public void AddCoin(Coin coin)
        {
            Count++;

            coin.Disable();
        }

        public void ResetCoinsCount()
        {
            Count = 0;
        }
    }
}
