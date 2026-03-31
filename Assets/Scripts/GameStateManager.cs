using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour
{

    [SerializeField] GameObject titleScreenStartButton;
    [SerializeField] GameObject titleScreen;

    [SerializeField] GameObject loginScreen;

    [SerializeField] GameObject createAccountScreen;
    [SerializeField] GameObject createAccountButton;

    [SerializeField] GameObject createAccountBackButton;

    [SerializeField] GameObject createNameInput;
    [SerializeField] GameObject createPassInput;
    [SerializeField] GameObject createPassVerificationInput;

    [SerializeField] GameObject loginInstructionText;
    
    [SerializeField] GameObject nameInput;
    [SerializeField] GameObject passInput;
    [SerializeField] GameObject loginButton;


    Stack<AbstractGameState> gameStateStack;

    public TitleState titleState;
    public LoginState loginState;
    public CreateAccountState createAccountState;

    void Start()
    {
        NetworkClientProcessing.SetGameStateManager(this);

        gameStateStack = new Stack<AbstractGameState>();

        titleState = new TitleState(this, titleScreen, titleScreenStartButton);

        loginState = new LoginState(this, loginScreen);//, createAccountButton, loginInstructionText, nameInput, passInput, loginButton);

        createAccountState = new CreateAccountState(this, createAccountScreen);//, createAccountButton, 
            //createAccountBackButton, createNameInput, createPassInput, createPassVerificationInput);

        PushGameStateOnStack(titleState);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     PopGameStateOffStack();
        // }

        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     PopGameStateUntilStateIs(titleState);
        // }

        gameStateStack.Peek().Update();
    }

    public void PushGameStateOnStack(AbstractGameState gameState)
    {
        if (gameStateStack.Count > 0)
            gameStateStack.Peek().Pause();

        gameStateStack.Push(gameState);
        gameState.LoadGameState();
    }

    public void PopGameStateOffStack()
    {
        if (gameStateStack.Peek() != titleState)
        {
            gameStateStack.Peek().UnloadGameState();
            gameStateStack.Pop();
            gameStateStack.Peek().Resume();
        }
    }

    public void PopGameStateUntilStateIs(AbstractGameState gameState)
    {
        while (gameStateStack.Peek() != gameState)
            PopGameStateOffStack();
    }

}
