using TMPro;
using UnityEngine;

public class BalanceManagement : MonoBehaviour
{
    public static int coinBalance = 0;
    private void Update()
    {
        if (ObjectHandler.BalanceText != null)
        {
            ObjectHandler.BalanceText.text = $"Coins: {coinBalance}";
        }
    }

    public void CoinBalanceSubtraction(int coinsToSubtract)
    {
        coinBalance -= coinsToSubtract;
    }

    public void CoinAdding()
    {
        coinBalance += DragAndDrop_.earnedCoins;
    }
}
