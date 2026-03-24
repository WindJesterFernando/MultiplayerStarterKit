using UnityEngine;

public class TitleState : AbstractGameState
{
    GameObject button;

    public TitleState(GameObject button)
    {
        this.button = button;
    }

    public override void LoadGameState()
    {
        Debug.Log("Title State Loaded");
        button.SetActive(true);
    }

    public override void UnloadGameState()
    {
        Debug.Log("Title State Unloaded");
        button.SetActive(false);
    }

    public override void Pause()
    {
        Debug.Log("Title State Paused");
        button.SetActive(false);
    }

    public override void Resume()
    {
        Debug.Log("Title State Resumed");
        button.SetActive(true);
    }

    public override void Update()
    {
        Debug.Log("Title State Updating");
    }


}