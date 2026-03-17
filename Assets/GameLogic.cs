using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField]
    GameObject accountLoginUI;

    void Start()
    {
        NetworkClientProcessing.SetGameLogic(this);
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.A))
        //     NetworkClientProcessing.SendMessageToServer("3,Hello server's world, sincerely your network client", TransportPipeline.ReliableAndInOrder);

    }

    public void SetLoginInfoText(string info)
    {
        accountLoginUI.GetComponent<AccountLoginUI>().SetInfoText(info);
    }

}
