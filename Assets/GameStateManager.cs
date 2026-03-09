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

    Stack<GameState> gameStateStack;

    void Start()
    {
        gameStateStack = new Stack<GameState>();

        button.GetComponent<Button>().onClick.AddListener(FunctionForOurButton);
        button2.GetComponent<Button>().onClick.AddListener(FunctionForOurButton2);
        button3.GetComponent<Button>().onClick.AddListener(FunctionForOurButton3);
        button4.GetComponent<Button>().onClick.AddListener(FunctionForOurButton4);

        PushGameStateOnStack(GameState.OneState);
    }

    void Update()
    {
        if (gameStateStack.Peek() == GameState.ThreeState)
        {
            Debug.Log("gwegewgerwgwer");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PopGameStateOffStack();
        }
    }

    public void FunctionForOurButton()
    {
        PushGameStateOnStack(GameState.TwoState);
    }
    public void FunctionForOurButton2()
    {
        PushGameStateOnStack(GameState.ThreeState);
    }
    public void FunctionForOurButton3()
    {
        PushGameStateOnStack(GameState.FourState);
    }
    public void FunctionForOurButton4()
    {
        //PushGameStateOnStack(GameState.OneState);
    }

    public void PopGameStateOffStack()
    {
        if(gameStateStack.Peek() != GameState.OneState)
            gameStateStack.Pop();
            
        LoadState();
    }

    public void PushGameStateOnStack(GameState gameState)
    {
        gameStateStack.Push(gameState);
        LoadState();
    }

    public void LoadState()
    {
        GameState gameState = gameStateStack.Peek();

        if (gameState == GameState.OneState)
        {
            Debug.Log("111111");
            button.SetActive(true);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
        }
        else if (gameState == GameState.TwoState)
        {
            Debug.Log("22222");
            button.SetActive(false);
            button2.SetActive(true);
            button3.SetActive(false);
            button4.SetActive(false);
        }
        else if (gameState == GameState.ThreeState)
        {
            Debug.Log("33333");
            button.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(true);
            button4.SetActive(false);
        }
        else if (gameState == GameState.FourState)
        {
            Debug.Log("44444");
            button.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(true);
        }
    }

}

public enum GameState
{
    OneState,
    TwoState,
    ThreeState,
    FourState,
}



//

//UI for multiple states
// A state that will hold things”
// “We need a state manager”


// “Stack: push & pop”


//we need to add a state to.......


// “What does a state have?”, “what is our definition of a state?”





// How do we package states?
//"Our states are NOT actually holding anything?", "turn states into classes"
