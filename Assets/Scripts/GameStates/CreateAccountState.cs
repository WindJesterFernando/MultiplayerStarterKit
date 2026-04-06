using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CreateAccountState : AbstractGameState
{
    GameObject createAccountScreen;
    TMP_Text infoText;
    TMP_InputField nameInput;
    TMP_InputField passInput;
    TMP_InputField passVerificationInput;
    Button createAccountButton;
    Button backToLoginButton;

    public CreateAccountState(GameObject createAccountScreen)
    {
        this.createAccountScreen = createAccountScreen;

        foreach (Transform child in createAccountScreen.transform)
        {
            if (child.name == "InfoText")
                infoText = child.gameObject.GetComponent<TMP_Text>();
            else if (child.name == "NameInput")
                nameInput = child.gameObject.GetComponent<TMP_InputField>();
            else if (child.name == "PassInput")
                passInput = child.gameObject.GetComponent<TMP_InputField>();
            else if (child.name == "PassVerificationInput")
                passVerificationInput = child.gameObject.GetComponent<TMP_InputField>();
            else if (child.name == "CreateAccountButton")
                createAccountButton = child.gameObject.GetComponent<Button>();
            else if (child.name == "BackToLoginButton")
                backToLoginButton = child.gameObject.GetComponent<Button>();
        }
        createAccountButton.onClick.AddListener(CreateAccountButtonClick);
        backToLoginButton.onClick.AddListener(BackToLoginState);

    }

    public override void LoadGameState()
    {
        Debug.Log("CreateAccountState Loaded");
        createAccountScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        Debug.Log("CreateAccountState Unloaded");
        createAccountScreen.SetActive(false);
    }

    public override void Pause()
    {
        Debug.Log("CreateAccountState Paused");
        createAccountScreen.SetActive(false);
    }

    public override void Resume()
    {
        Debug.Log("CreateAccountState Resumed");
        createAccountScreen.SetActive(true);
    }

    public override void Update()
    {
        Debug.Log("CreateAccountState Updating");
    }

    public void CreateAccountButtonClick()
    {
        string name = nameInput.text;
        string pass = passInput.text;
        string passVerification = passVerificationInput.text;

        if (pass != passVerification)
        {
            infoText.text = "passwords do not match";
            return;
        }

        string createAccountMsg = Utilities.Concatenate((int)ClientToServerSignal.AccountCreate, name, pass);
        NetworkClientProcessing.SendMessageToServer(createAccountMsg, TransportPipeline.ReliableAndInOrder);
    }

    public void BackToLoginState()
    {
        GameStateManager.PopGameStateUntilStateIs(GameStateManager.loginState);
    }

    public void SetInfoText(string info)
    {
        infoText.text = info;
    }

}