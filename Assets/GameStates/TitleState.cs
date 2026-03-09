using UnityEngine;

public class TitleState : AbstractGameState
{
    GameObject button, button2, button3, button4;

    public TitleState(GameObject button, GameObject button2, GameObject button3, GameObject button4)
    {
        this.button = button;
        this.button2 = button2;
        this.button3 = button3;
        this.button4 = button4;
    }

    public override void LoadGameState()
    {
        Debug.Log("Title State Loaded");
        button.SetActive(true);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
    }
}