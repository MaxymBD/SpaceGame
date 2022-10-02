using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SateliteManagement : MonoBehaviour
{
    [SerializeField] private SateliteModule _sateliteModule;
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _descriptionHandler;
    [SerializeField] private GameObject _notificationHandler;
    private BalanceManagement _balanceManagement;
    private TMP_Text _titleText;
    private TMP_Text _descriptionText;
    private Button _installButton;
    private Animator _animator;

    private void Start()
    {
        ObjectHandler.DescriptionHandler.SetActive(false);
        ObjectHandler.NotificationHandler.SetActive(false);
        gameObject.SetActive(false);
        _animator = gameObject.GetComponent<Animator>();
        _buyButton.GetComponentInChildren<TMP_Text>().text = _sateliteModule.Name;
        _balanceManagement = GameObject.Find("GameController").GetComponent<BalanceManagement>();
    }

    public void BuySateliteModule(int moduleIndex)
    {
        if (BalanceManagement.coinBalance - _sateliteModule.Price >= 0)
        {
            _balanceManagement.CoinBalanceSubtraction(_sateliteModule.Price);

            _buyButton.SetActive(false);
            _descriptionHandler.SetActive(true);

            ShowSateliteModuleDescription();
        }
        else
        {
            _notificationHandler.SetActive(true);
        }
    }

    public void ShowSateliteModuleDescription()
    {
        gameObject.SetActive(true);
        _animator.SetTrigger("Show");

        _titleText = GameObject.Find("Title").GetComponent<TMP_Text>();
        _descriptionText = GameObject.Find("Description").GetComponent<TMP_Text>();
        _installButton = GameObject.Find("InstallButton").GetComponent<Button>();

        _installButton.onClick.AddListener(InstallSateliteModule);

        _titleText.text = _sateliteModule.Name;
        _descriptionText.text = _sateliteModule.Description;
    }

    public void InstallSateliteModule()
    {
        _animator.SetTrigger("Rotate");
        _animator.SetTrigger("Install");
    }
}
