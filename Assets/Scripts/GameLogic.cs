using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField]
    GameObject accountLoginUI;

    void Start()
    {
        NetworkClientProcessing.SetGameLogic(this);
    }

    void Update()
    {

    }

    public void SetLoginInfoText(string info)
    {
        accountLoginUI.GetComponent<AccountLoginUI>().SetInfoText(info);
    }

    public void GoBackToLoginScreen()
    {
        accountLoginUI.GetComponent<AccountLoginUI>().CreateAccountBackButtonClick();
    }

}
