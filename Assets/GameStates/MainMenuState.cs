using UnityEngine;

public class MainMenuState : AbstractGameState
{
    GameObject button, button2, button3, button4;

    public MainMenuState(GameObject button, GameObject button2, GameObject button3, GameObject button4)
    {
        this.button = button;
        this.button2 = button2;
        this.button3 = button3;
        this.button4 = button4;
    }

    public override void LoadGameState()
    {
        Debug.Log("MainMenuState Loaded");
        button.SetActive(false);
        button2.SetActive(true);
        button3.SetActive(false);
        button4.SetActive(false);
    }
}