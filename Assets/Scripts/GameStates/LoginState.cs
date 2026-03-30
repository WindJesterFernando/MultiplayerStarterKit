using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginState : AbstractGameState
{
    GameStateManager gameStateManager;
    GameObject createAccountButton;
    GameObject infoText;
    GameObject loginScreen;

    public LoginState(GameStateManager gameStateManager, GameObject loginScreen, GameObject createAccountButton, GameObject infoText)
    {
        this.loginScreen = loginScreen;
        this.gameStateManager = gameStateManager;
        this.createAccountButton = createAccountButton;
        this.infoText = infoText;

        createAccountButton.GetComponent<Button>().onClick.AddListener(CreateAccountButtonClick);
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
}