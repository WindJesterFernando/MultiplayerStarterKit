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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loginButton.GetComponent<Button>().onClick.AddListener(LoginButtonClick);
        createButton.GetComponent<Button>().onClick.AddListener(CreateButtonClick);

        createAccountButton.GetComponent<Button>().onClick.AddListener(CreateAccountButtonClick);

        createAccountBackButton.GetComponent<Button>().onClick.AddListener(CreateAccountBackButtonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoginButtonClick()
    {
        string name = nameInput.GetComponent<TMP_InputField>().text;
        string pass = passInput.GetComponent<TMP_InputField>().text;

        string loginSerialization = 0 + "," + name + "," + pass;

        Debug.Log(loginSerialization);

        NetworkClientProcessing.SendMessageToServer(loginSerialization, TransportPipeline.ReliableAndInOrder);
    }

    public void CreateButtonClick()
    {
        nameInput.SetActive(false);
        passInput.SetActive(false);
        loginButton.SetActive(false);
        createButton.SetActive(false);

        createNameInput.SetActive(true);
        createPassInput.SetActive(true);
        createPassVerificationInput.SetActive(true);
        createAccountButton.SetActive(true);
        createAccountBackButton.SetActive(true);
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

        string createAccountSerialization = 1 + "," + name + "," + pass;

        Debug.Log(createAccountSerialization);

        NetworkClientProcessing.SendMessageToServer(createAccountSerialization, TransportPipeline.ReliableAndInOrder);
    }

    public void SetInfoText(string info)
    {
        infoText.GetComponent<TMP_Text>().text = info;
    }

    public void CreateAccountBackButtonClick()
    {
        nameInput.SetActive(true);
        passInput.SetActive(true);
        loginButton.SetActive(true);
        createButton.SetActive(true);

        createNameInput.SetActive(false);
        createPassInput.SetActive(false);
        createPassVerificationInput.SetActive(false);
        createAccountButton.SetActive(false);
        createAccountBackButton.SetActive(false);
    }
}
