using UnityEngine;
using UnityEngine.UI;

public class TitleState : AbstractGameState
{
    GameObject titleScreen;
    Button startButton;

    public TitleState(GameObject titleScreen)
    {
        this.titleScreen = titleScreen;

        foreach (Transform child in titleScreen.transform)
        {
            if(child.name == "StartButton")
                startButton = child.gameObject.GetComponent<Button>();
        }

        startButton.onClick.AddListener(TitleScreenStartClick);
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
        //Debug.Log("Title State Updating");
    }

    public void TitleScreenStartClick()
    {
        GameStateManager.PushGameStateOnStack(GameStateManager.loginState);
    }

}