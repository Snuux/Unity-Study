using UnityEngine;

namespace Assets.Course.PhysicsBall
{
    public class CoinsHolder : MonoBehaviour
    {
        public int Count { get; private set; }

        private void Awake()
        {
            ResetCoinsCount();
        }

        public void ResetCoinsCount()
        {
            Count = GetComponentsInChildren<Coin>().Length;
        }

        public void ResetCoins()
        {
            Coin[] coins = GetComponentsInChildren<Coin>(true);

            foreach (Coin coin in coins)
                coin.Enable();
        }
    }
}