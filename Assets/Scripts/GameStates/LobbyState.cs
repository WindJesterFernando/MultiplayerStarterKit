using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyState : AbstractGameState
{
    GameObject lobbyScreen;

    //Button lobbyButton;

    TMP_Text accountNameDisplay;

    public LobbyState(GameObject lobbyScreen)
    {
        this.lobbyScreen = lobbyScreen;

        foreach (Transform child in lobbyScreen.transform)
        {
            if(child.name == "AccountNameDisplay")
                accountNameDisplay = child.gameObject.GetComponent<TMP_Text>();

            // if(child.name == "LobbyButton")
            //     lobbyButton = child.gameObject.GetComponent<Button>();
        }

        // createAccountButton.onClick.AddListener(CreateAccountButtonClick);
        //lobbyButton.onClick.AddListener(LobbyClick);
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

    public void SetAccountName(string name)
    {
        accountNameDisplay.text = name;
    }

    // public void LobbyClick()
    // {
    //     string msg = Utilities.Concatenate((int)ClientToServerSignal.ClientTestMsg, "msg from client");
    //     NetworkClientProcessing.SendMessageToServer(msg, TransportPipeline.ReliableAndInOrder);
    // }

    
}