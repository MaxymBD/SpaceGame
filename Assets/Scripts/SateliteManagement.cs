using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SateliteManagement : MonoBehaviour
{
    [SerializeField] private SateliteModule _sateliteModule;
    [SerializeField] private GameObject _buyButton;
    private BalanceManagement _balanceManagement;
    private GameObject _descriptionPanel;
    private TMP_Text _titleText;
    private TMP_Text _descriptionText;
    private Button _installButton;
    private Animator _animator;

    private void Start()
    {
        gameObject.SetActive(false);
        _animator = gameObject.GetComponent<Animator>();
        _buyButton.GetComponentInChildren<TMP_Text>().text = _sateliteModule.Name;
        _balanceManagement = GameObject.Find("GameController").GetComponent<BalanceManagement>();
    }

    public void BuySateliteModule()
    {
        _balanceManagement.CoinBalanceSubtraction(_sateliteModule.Price);

        _buyButton.SetActive(false);

        ShowSateliteModuleDescription();
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
