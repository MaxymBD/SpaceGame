using TMPro;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public static GameObject HiHandler;
    public static GameObject DescriptionHandler;
    public static GameObject NotificationHandler;
    public static GameObject MenuHandler;
    public static TMP_Text BalanceText;
    public static bool HiActivated;

    private void Start()
    {
        HiHandler = GameObject.Find("Hi").gameObject;
        DescriptionHandler = GameObject.Find("DescriptionHandler").gameObject;
        NotificationHandler = GameObject.Find("Notification").gameObject;
        MenuHandler = GameObject.Find("Menu").gameObject;
        BalanceText = GameObject.Find("Balance").GetComponent<TMP_Text>();

        MenuHandler.SetActive(false);

        if(HiActivated == false)
        {
            HiActivated = true;
        }
        else
        {
            HiHandler.SetActive(false);
        }
    }
}
