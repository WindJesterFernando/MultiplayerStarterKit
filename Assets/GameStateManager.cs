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


        titleState = new TitleState(button, button2, button3, button4);
        mainMenuState = new MainMenuState(button, button2, button3, button4);
        gamePlayState = new GamePlayState(button, button2, button3, button4);

        PushGameStateOnStack(titleState);
    }

    void Update()
    {
        if (gameStateStack.Peek() == gamePlayState)
        {
            Debug.Log("we are updating in gameplay state");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopGameStateOffStack();
        }
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

    public void PopGameStateOffStack()
    {
        if (gameStateStack.Peek() != titleState)
        {
            gameStateStack.Pop();
            gameStateStack.Peek().LoadGameState();
        }
    }

    public void PushGameStateOnStack(AbstractGameState gameState)
    {
        gameStateStack.Push(gameState);
        gameState.LoadGameState();
    }


}


//

//UI for multiple states
// A state that will hold things”
// “We need a state manager”
// “Stack: push & pop”


// “What does a state have?”, “what is our definition of a state?”
// How do we package states?
//"Our states are NOT actually holding anything?", "turn states into classes"



//we need to add a state to.......