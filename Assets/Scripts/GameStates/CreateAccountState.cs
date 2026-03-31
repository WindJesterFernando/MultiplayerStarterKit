using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateAccountState : AbstractGameState
{
    GameStateManager gameStateManager;
    GameObject screen;
    GameObject createAccountButton;
    GameObject backToLoginButton;

    GameObject createNameInput;
    GameObject createPassInput;
    GameObject createPassVerificationInput;

    public CreateAccountState(GameStateManager gameStateManager, GameObject screen, GameObject createAccountButton, GameObject backToLoginButton, GameObject createNameInput, GameObject createPassInput, GameObject createPassVerificationInput)
    {
        this.gameStateManager = gameStateManager;
        this.screen = screen;
        this.createAccountButton = createAccountButton;
        this.backToLoginButton = backToLoginButton;
        this.createNameInput = createNameInput;
        this.createPassInput = createPassInput;
        this.createPassVerificationInput = createPassVerificationInput;

        createAccountButton.GetComponent<Button>().onClick.AddListener(CreateAccountButtonClick);
        backToLoginButton.GetComponent<Button>().onClick.AddListener(BackToLoginState);

    }

    public override void LoadGameState()
    {
        Debug.Log("CreateAccountState Loaded");
        screen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        Debug.Log("CreateAccountState Unloaded");
        screen.SetActive(false);
    }

    public override void Pause()
    {
        Debug.Log("CreateAccountState Paused");
        screen.SetActive(false);
    }

    public override void Resume()
    {
        Debug.Log("CreateAccountState Resumed");
        screen.SetActive(true);
    }

    public override void Update()
    {
        Debug.Log("CreateAccountState Updating");
    }

    public void CreateAccountButtonClick()
    {
        string name = createNameInput.GetComponent<TMP_InputField>().text;
        string pass = createPassInput.GetComponent<TMP_InputField>().text;
        string passVerification = createPassVerificationInput.GetComponent<TMP_InputField>().text;

        if (pass != passVerification)
        {
            //infoText.GetComponent<TMP_Text>().text = "passwords do not match";
            return;
        }

        string createAccountMsg = Utilities.Concatenate((int)ClientToServerSignal.AccountCreate, name, pass);
        NetworkClientProcessing.SendMessageToServer(createAccountMsg, TransportPipeline.ReliableAndInOrder);
    }

    public void BackToLoginState()
    {
        gameStateManager.PopGameStateUntilStateIs(gameStateManager.loginState);
    }

}