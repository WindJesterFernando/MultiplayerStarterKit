using UnityEngine;
using UnityEngine.UI;

public class TitleState : AbstractGameState
{
    GameObject titleScreen;
    GameStateManager gameStateManager;

    public TitleState(GameStateManager gameStateManager, GameObject titleScreen, GameObject titleScreenStartButton)
    {
        this.titleScreen = titleScreen;
        this.gameStateManager = gameStateManager;

        titleScreenStartButton.GetComponent<Button>().onClick.AddListener(TitleScreenStartClick);
    }

    public override void LoadGameState()
    {
        Debug.Log("Title State Loaded");
        titleScreen.SetActive(true);
    }

    public override void UnloadGameState()
    {
        Debug.Log("Title State Unloaded");
        titleScreen.SetActive(false);
    }

    public override void Pause()
    {
        Debug.Log("Title State Paused");
        titleScreen.SetActive(false);
    }

    public override void Resume()
    {
        Debug.Log("Title State Resumed");
        titleScreen.SetActive(true);
    }

    public override void Update()
    {
        Debug.Log("Title State Updating");
    }

    public void TitleScreenStartClick()
    {
        gameStateManager.PushGameStateOnStack(gameStateManager.loginState);
    }

}