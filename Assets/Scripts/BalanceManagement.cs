using TMPro;
using UnityEngine;

public class BalanceManagement : MonoBehaviour
{
    public int coinBalance;
    private TMP_Text _textMeshPro;

    private void Start()
    {
        _textMeshPro = GameObject.Find("Balance").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _textMeshPro.text = $"Coins: {coinBalance}";
    }

    public void CoinBalanceSubtraction(int coinsToSubtract)
    {
        coinBalance -= coinsToSubtract;
    }
}
