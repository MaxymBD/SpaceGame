using TMPro;
using UnityEngine;

public class SateliteManagement : MonoBehaviour
{
    [SerializeField] private SateliteModule _sateliteModule;
    [SerializeField] private GameObject _buyButton;
    private BalanceManagement _balanceManagement;

    private void Start()
    {
        gameObject.SetActive(false);
        _buyButton.GetComponentInChildren<TMP_Text>().text = _sateliteModule.Name;
        _balanceManagement = GameObject.Find("GameController").GetComponent<BalanceManagement>();
    }

    public void BuySateliteModule()
    {
        gameObject.SetActive(true);
        _balanceManagement.CoinBalanceSubtraction(_sateliteModule.Price);
        _buyButton.SetActive(false);
    }
}
