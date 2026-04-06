using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyState : AbstractGameState
{
    GameObject lobbyScreen;

    public LobbyState(GameObject lobbyScreen)
    {
        this.lobbyScreen = lobbyScreen;

        // foreach (Transform child in loginScreen.transform)
        // {
        //     if(child.name == "InfoText")
        //         infoText = child.gameObject.GetComponent<TMP_Text>();
        //     else if(child.name == "NameInput")
        //         nameInput = child.gameObject.GetComponent<TMP_InputField>();
        //     else if(child.name == "PassInput")
        //         passInput = child.gameObject.GetComponent<TMP_InputField>();
        //     else if(child.name == "LoginButton")
        //         loginButton = child.gameObject.GetComponent<Button>();
        //     else if(child.name == "CreateAccountButton")
        //         createAccountButton = child.gameObject.GetComponent<Button>();
        // }

        // createAccountButton.onClick.AddListener(CreateAccountButtonClick);
        // loginButton.onClick.AddListener(LoginButtonClick);
    }

    public override void LoadGameState()
    {
        Debug.Log("LobbyState Loaded");
        lobbyScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        Debug.Log("LobbyState Unloaded");
        lobbyScreen.SetActive(false);
    }

    public override void Pause()
    {
        Debug.Log("LobbyState Paused");
        lobbyScreen.SetActive(false);
    }

    public override void Resume()
    {
        Debug.Log("LobbyState Resumed");
        lobbyScreen.SetActive(true);
    }

    public override void Update()
    {
        Debug.Log("LobbyState Updating");
    }
}