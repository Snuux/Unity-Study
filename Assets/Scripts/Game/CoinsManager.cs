using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    private Coin[] coinList;

    public int Count => coinList.Length;

    private void Awake()
    {
        coinList = GetComponentsInChildren<Coin>();
    }

    public int CountDisabled()
    {
        int count = 0;

        foreach (Coin coin in coinList)
            if (coin.gameObject.activeSelf == false)
                count++;

        return count;
    }

    public void ResetCoins()
    {
        foreach (Coin coin in coinList)
            coin.gameObject.SetActive(true);
    }

    public bool IsAllCoinsPicked() => Count == CountDisabled();
}
