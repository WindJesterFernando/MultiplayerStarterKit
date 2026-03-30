using UnityEngine;

public class CreateAccountState : AbstractGameState
{
    GameObject screen;

    public CreateAccountState(GameObject screen)
    {
        this.screen = screen;
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
}