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

    public NetworkConnectionError LastError { get; set; }

    public void InitializeServer()
    {
        LastError = Network.InitializeServer(ConnectionNum, Port, !Network.HavePublicAddress());
        RegisterHost();
    }

    public void Connect()
    {
        LastError = Network.Connect(IP, Port, Password);
    }

    public void RegisterHost()
    {
        MasterServer.RegisterHost(GameType, GameName);
    }

    public HostData[] PollHostList()
    {
        return MasterServer.PollHostList();
    }
}
