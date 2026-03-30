using UnityEngine;

public class LoginState : AbstractGameState
{
    GameObject button;

    public LoginState(GameObject button)
    {
        this.button = button;
    }

    public override void LoadGameState()
    {
        Debug.Log("MainMenuState Loaded");
        button.SetActive(true);
    }

    public override void UnloadGameState()
    {
        Debug.Log("MainMenuState Unloaded");
        button.SetActive(false);
    }

    public override void Pause()
    {
        Debug.Log("MainMenuState Paused");
        button.SetActive(false);
    }

    public override void Resume()
    {
        Debug.Log("MainMenuState Resumed");
        button.SetActive(true);
    }

    public override void Update()
    {
        Debug.Log("MainMenuState Updating");
    }
}