using UnityEngine;
using System.Collections.Generic;

static public class GameStateManager
{
    static Stack<AbstractGameState> gameStateStack;

    static public TitleState titleState;
    static public LoginState loginState;
    static public CreateAccountState createAccountState;

    static public void Initialize(BootStrapper bootStrapper)
    {
        gameStateStack = new Stack<AbstractGameState>();
        titleState = new TitleState(bootStrapper.titleScreen);
        loginState = new LoginState(bootStrapper.loginScreen);
        createAccountState = new CreateAccountState(bootStrapper.createAccountScreen);

        PushGameStateOnStack(titleState);
    }

    static public void Update()
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

    static public void PushGameStateOnStack(AbstractGameState gameState)
    {
        if (gameStateStack.Count > 0)
            gameStateStack.Peek().Pause();

        gameStateStack.Push(gameState);
        gameState.LoadGameState();
    }

    static public void PopGameStateOffStack()
    {
        if (gameStateStack.Peek() != titleState)
        {
            gameStateStack.Peek().UnloadGameState();
            gameStateStack.Pop();
            gameStateStack.Peek().Resume();
        }
    }

    static public void PopGameStateUntilStateIs(AbstractGameState gameState)
    {
        while (gameStateStack.Peek() != gameState)
            PopGameStateOffStack();
    }

}
