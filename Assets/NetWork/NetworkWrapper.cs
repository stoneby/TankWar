using System;
using UnityEngine;

public class NetworkWrapper : MonoBehaviour
{
    #region Network

    public int ConnectionNum;
    public int Port;
    public string IP;
    public string Password;

    #endregion

    #region MasterServer

    public string GameType;
    public string GameName;

    #endregion

    #region Events

    public event EventHandler<ConnectSucceedEvent> ConnectSucceed;
    public event EventHandler<ConnectFailEvent> ConnectFail;

    #endregion

    public NetworkConnectionError LastError { get; set; }

    public void InitializeServer()
    {
        Network.incomingPassword = Password;
        LastError = Network.InitializeServer(ConnectionNum, Port, !Network.HavePublicAddress());
        Debug.LogWarning("Status after initialize server: " + LastError);
        RegisterHost();
    }

    public void Connect()
    {
        LastError = Network.Connect(IP, Port, Password);
        Debug.LogWarning("Status after connect to server: " + LastError);
    }

    public void RegisterHost()
    {
        MasterServer.RegisterHost(GameType, GameName);
    }

    public HostData[] PollHostList()
    {
        return MasterServer.PollHostList();
    }

    public void RequestHostList()
    {
        MasterServer.RequestHostList(GameType);
    }

    public void ClearHostList()
    {
        MasterServer.ClearHostList();
    }

    void OnFailedToConnect(NetworkConnectionError error)
    {
        Debug.LogWarning("Fail to connect: " + error);
        if (ConnectFail != null)
        {
            ConnectFail(this, new ConnectFailEvent{Error = error});
        }
    }

    void OnConnectedToServer()
    {
        if (ConnectSucceed != null)
        {
            ConnectSucceed(this, new ConnectSucceedEvent());
        }
    }
}
