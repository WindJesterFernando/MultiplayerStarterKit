using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginState : AbstractGameState
{
    GameStateManager gameStateManager;
    GameObject loginScreen;

    TMP_Text infoText;
    TMP_InputField nameInput;
    TMP_InputField passInput;
    Button loginButton;
    Button createAccountButton;

    public LoginState(GameStateManager gameStateManager, GameObject loginScreen)
    {
        this.loginScreen = loginScreen;
        this.gameStateManager = gameStateManager;

        foreach (Transform child in loginScreen.transform)
        {
            if(child.name == "InfoText")
                infoText = child.gameObject.GetComponent<TMP_Text>();
            else if(child.name == "NameInput")
                nameInput = child.gameObject.GetComponent<TMP_InputField>();
            else if(child.name == "PassInput")
                passInput = child.gameObject.GetComponent<TMP_InputField>();
            else if(child.name == "LoginButton")
                loginButton = child.gameObject.GetComponent<Button>();
            else if(child.name == "CreateAccountButton")
                createAccountButton = child.gameObject.GetComponent<Button>();
        }

        createAccountButton.onClick.AddListener(CreateAccountButtonClick);
        loginButton.onClick.AddListener(LoginButtonClick);
    }

    public override void LoadGameState()
    {
        Debug.Log("LoginState Loaded");
        loginScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        Debug.Log("LoginState Unloaded");
        loginScreen.SetActive(false);
    }

    public override void Pause()
    {
        Debug.Log("LoginState Paused");
        loginScreen.SetActive(false);
    }

    public override void Resume()
    {
        Debug.Log("LoginState Resumed");
        loginScreen.SetActive(true);
    }

    public override void Update()
    {
        Debug.Log("LoginState Updating");
    }

    public void CreateAccountButtonClick()
    {
        gameStateManager.PushGameStateOnStack(gameStateManager.createAccountState);
    }

    public void SetInfoText(string info)
    {
        infoText.text = info;
    }

    public void LoginButtonClick()
    {
        string name = nameInput.text;
        string pass = passInput.text;

        string loginMsg = Utilities.Concatenate((int)ClientToServerSignal.AccountLogin, name, pass);
        NetworkClientProcessing.SendMessageToServer(loginMsg, TransportPipeline.ReliableAndInOrder);
    }
}