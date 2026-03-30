using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountLoginUI : MonoBehaviour
{
    [SerializeField]
    GameObject nameInput, passInput, loginButton, createButton;

    [SerializeField]
    GameObject infoText;


    [SerializeField]
    GameObject createNameInput, createPassInput, createPassVerificationInput, createAccountButton, createAccountBackButton;


    [SerializeField]
    GameObject gameStateManager;

    void Start()
    {
        loginButton.GetComponent<Button>().onClick.AddListener(LoginButtonClick);
        //createButton.GetComponent<Button>().onClick.AddListener(CreateButtonClick);

        createAccountButton.GetComponent<Button>().onClick.AddListener(CreateAccountButtonClick);

        //createAccountBackButton.GetComponent<Button>().onClick.AddListener(CreateAccountBackButtonClick);
    }

    void Update()
    {

    }

    public void LoginButtonClick()
    {
        string name = nameInput.GetComponent<TMP_InputField>().text;
        string pass = passInput.GetComponent<TMP_InputField>().text;

        string loginMsg = Utilities.Concatenate((int)ClientToServerSignal.AccountLogin, name, pass);
        NetworkClientProcessing.SendMessageToServer(loginMsg, TransportPipeline.ReliableAndInOrder);
    }


    public void CreateAccountButtonClick()
    {
        string name = createNameInput.GetComponent<TMP_InputField>().text;
        string pass = createPassInput.GetComponent<TMP_InputField>().text;
        string passVerification = createPassVerificationInput.GetComponent<TMP_InputField>().text;

        if (pass != passVerification)
        {
            infoText.GetComponent<TMP_Text>().text = "passwords do not match";
            return;
        }

        string createAccountMsg = Utilities.Concatenate((int)ClientToServerSignal.AccountCreate, name, pass);
        NetworkClientProcessing.SendMessageToServer(createAccountMsg, TransportPipeline.ReliableAndInOrder);
    }

    // public void SetInfoText(string info)
    // {
    //     infoText.GetComponent<TMP_Text>().text = info;
    // }

    // public void CreateAccountBackButtonClick()
    // {
    //     gameStateManager.GetComponent<GameStateManager>().PopGameStateOffStack();
    //     // nameInput.SetActive(true);
    //     // passInput.SetActive(true);
    //     // loginButton.SetActive(true);
    //     // createButton.SetActive(true);

    //     // createNameInput.SetActive(false);
    //     // createPassInput.SetActive(false);
    //     // createPassVerificationInput.SetActive(false);
    //     // createAccountButton.SetActive(false);
    //     // createAccountBackButton.SetActive(false);
    // }
}
