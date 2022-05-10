using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _roomList;
    [SerializeField] private InputField _roomToCreate;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to master room.");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined lobby.");

        UICreateRoom();
    }

    public void UICreateRoom()
    {
        string roomName = _roomToCreate.text;
        PhotonNetwork.CreateRoom(roomName);
        _roomList.text += roomName + ",";
    }
}
