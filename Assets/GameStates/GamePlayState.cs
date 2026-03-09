using UnityEngine;

public class GamePlayState : AbstractGameState
{
    GameObject button, button2, button3, button4;

    public GamePlayState(GameObject button, GameObject button2, GameObject button3, GameObject button4)
    {
        this.button = button;
        this.button2 = button2;
        this.button3 = button3;
        this.button4 = button4;
    }

    public override void LoadGameState()
    {
        Debug.Log("GamePlayState Loaded");
        button.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(true);
        button4.SetActive(false);
    }
}