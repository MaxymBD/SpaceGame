using UnityEngine;

public class BalanceManagement : MonoBehaviour
{
    public DataStorage dataStorage;
    public static int coinBalance;

    private void Start()
    {
        coinBalance = dataStorage.coinBalance;
    }

    private void Update()
    {
        if (ObjectHandler.BalanceText != null)
        {
            ObjectHandler.BalanceText.text = $"Coins: {coinBalance}";
            dataStorage.coinBalance = coinBalance;
        }
    }

    public void CoinBalanceSubtraction(int coinsToSubtract)
    {
        coinBalance -= coinsToSubtract;
    }

    public void CoinAdding()
    {
        dataStorage.coinBalance += DragAndDrop_.earnedCoins;
    }
}
