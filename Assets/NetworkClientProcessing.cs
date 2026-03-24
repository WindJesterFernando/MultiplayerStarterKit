using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class NetworkClientProcessing
{

    #region Send and Receive Data Functions
    static public void ReceivedMessageFromServer(string msg, TransportPipeline pipeline)
    {
        Debug.Log("Network msg received =  " + msg + Utilities.Delineator + " from pipeline = " + pipeline);

        string[] csv = msg.Split(Utilities.Delineator);
        ServerToClientSignal signal = (ServerToClientSignal)int.Parse(csv[0]);


        if (signal == ServerToClientSignal.AccountLoginUserNameError)
        {
            gameLogic.SetLoginInfoText("Error! User name not found");
        }
        else if (signal == ServerToClientSignal.AccountLoginPasswordError)
        {
            gameLogic.SetLoginInfoText("Error! Password is incorrect");
        }
        else if (signal == ServerToClientSignal.AccountCreationUserNameError)
        {
            gameLogic.SetLoginInfoText("Error! Account name already in use.");
        }
        else if (signal == ServerToClientSignal.AccountLoginSuccess)
        {
            gameLogic.SetLoginInfoText("Login Successful");
        }
        else if (signal == ServerToClientSignal.AccountCreationSuccess)
        {
            gameLogic.GoBackToLoginScreen();
            gameLogic.SetLoginInfoText("Account Successfully Created!");
        }
    }

    static public void SendMessageToServer(string msg, TransportPipeline pipeline)
    {
        networkClient.SendMessageToServer(msg, pipeline);
    }

    #endregion

    #region Connection Related Functions and Events
    static public void ConnectionEvent()
    {
        Debug.Log("Network Connection Event!");
    }
    static public void DisconnectionEvent()
    {
        Debug.Log("Network Disconnection Event!");
    }
    static public bool IsConnectedToServer()
    {
        return networkClient.IsConnected();
    }
    static public void ConnectToServer()
    {
        networkClient.Connect();
    }
    static public void DisconnectFromServer()
    {
        networkClient.Disconnect();
    }

    #endregion

    #region Setup
    static NetworkClient networkClient;
    static GameLogic gameLogic;

    static public void SetNetworkedClient(NetworkClient NetworkClient)
    {
        networkClient = NetworkClient;
    }
    static public NetworkClient GetNetworkedClient()
    {
        return networkClient;
    }
    static public void SetGameLogic(GameLogic GameLogic)
    {
        gameLogic = GameLogic;
    }

    #endregion

}


