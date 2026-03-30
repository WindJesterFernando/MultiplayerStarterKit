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

    Stack<AbstractGameState> gameStateStack;

    TitleState titleState;
    LoginState loginState;
    GamePlayState gamePlayState;

    void Start()
    {
        gameStateStack = new Stack<AbstractGameState>();

        titleScreenStartButton.GetComponent<Button>().onClick.AddListener(FunctionForOurButton);

        titleState = new TitleState(titleScreen);
        loginState = new LoginState(loginScreen);


        PushGameStateOnStack(titleState);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopGameStateOffStack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PopGameStateUntilStateIs(titleState);
        }

        gameStateStack.Peek().Update();
    }

    public void FunctionForOurButton()
    {
        PushGameStateOnStack(loginState);
    }
    public void FunctionForOurButton2()
    {
        //PushGameStateOnStack(gamePlayState);
    }
    public void FunctionForOurButton3()
    {
        //PushGameStateOnStack(GameState.FourState);
    }
    public void FunctionForOurButton4()
    {
        //PushGameStateOnStack(GameState.OneState);
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
