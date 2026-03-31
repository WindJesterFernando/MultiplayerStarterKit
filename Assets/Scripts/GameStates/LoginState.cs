using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginState : AbstractGameState
{
    GameStateManager gameStateManager;
    GameObject createAccountButton;
    GameObject infoText;
    GameObject loginScreen;

    GameObject nameInput;
    GameObject passInput;

    GameObject loginButton;

    public LoginState(GameStateManager gameStateManager, GameObject loginScreen, GameObject createAccountButton, GameObject infoText, GameObject nameInput, GameObject passInput, GameObject loginButton)
    {
        this.loginScreen = loginScreen;
        this.gameStateManager = gameStateManager;
        this.createAccountButton = createAccountButton;
        //this.infoText = infoText;

        this.nameInput = nameInput;
        this.passInput = passInput;
        this.loginButton = loginButton;

        foreach (Transform child in loginScreen.transform)
        {
            if(child.name == "InfoText")
            {
                this.infoText = child.gameObject;
            }
        }

        //loginScreen.transform.childCount


        createAccountButton.GetComponent<Button>().onClick.AddListener(CreateAccountButtonClick);
        loginButton.GetComponent<Button>().onClick.AddListener(LoginButtonClick);
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
        infoText.GetComponent<TMP_Text>().text = info;
    }

    public void LoginButtonClick()
    {
        string name = nameInput.GetComponent<TMP_InputField>().text;
        string pass = passInput.GetComponent<TMP_InputField>().text;

        string loginMsg = Utilities.Concatenate((int)ClientToServerSignal.AccountLogin, name, pass);
        NetworkClientProcessing.SendMessageToServer(loginMsg, TransportPipeline.ReliableAndInOrder);
    }
}