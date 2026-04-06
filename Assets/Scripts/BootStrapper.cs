using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject loginScreen;
    public GameObject createAccountScreen;
    public GameObject lobbyScreen;

    void Start()
    {
        GameStateManager.Initialize(this);
    }

    void Update()
    {
        GameStateManager.Update();
    }
}
