using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour
{

    [SerializeField] GameObject button;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject button4;

    Stack<AbstractGameState> gameStateStack;

    TitleState titleState;
    MainMenuState mainMenuState;
    GamePlayState gamePlayState;

    void Start()
    {
        gameStateStack = new Stack<AbstractGameState>();

        button.GetComponent<Button>().onClick.AddListener(FunctionForOurButton);
        button2.GetComponent<Button>().onClick.AddListener(FunctionForOurButton2);
        button3.GetComponent<Button>().onClick.AddListener(FunctionForOurButton3);
        button4.GetComponent<Button>().onClick.AddListener(FunctionForOurButton4);

        titleState = new TitleState(button);
        mainMenuState = new MainMenuState(button2);
        gamePlayState = new GamePlayState(button3);

        button.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);

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
        PushGameStateOnStack(mainMenuState);
    }
    public void FunctionForOurButton2()
    {
        PushGameStateOnStack(gamePlayState);
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


//

//UI for multiple states
// A state that will hold things”
// “We need a state manager”
// “Stack: push & pop”
// How do we package states?
//"Our states are NOT actually holding anything?", "turn states into classes"
// “What does a state have?”, “what is our definition of a state?”



//we need to add a state to.......