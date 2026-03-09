using UnityEngine;

public class GamePlayState : AbstractGameState
{
    GameObject button;

    public GamePlayState(GameObject button)
    {
        this.button = button;
    }

    public override void LoadGameState()
    {
        Debug.Log("GamePlayState Loaded");
        button.SetActive(true);
    }

    public override void UnloadGameState()
    {
        Debug.Log("GamePlayState Unloaded");
        button.SetActive(false);
    }

    public override void Pause()
    {
        Debug.Log("GamePlayState Paused");
        button.SetActive(false);
    }

    public override void Resume()
    {
        Debug.Log("GamePlayState Resumed");
        button.SetActive(true);
    }

    public override void Update()
    {
        Debug.Log("GamePlayState Updating");
    }
}