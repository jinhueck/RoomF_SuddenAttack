using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : Photon.MonoBehaviour {

    [SerializeField] private Text connectText;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject lobbyCamera;

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }
	
    public virtual void OnJoinedLobby()
    {
        Debug.Log("We have now joined the lobby");

        //Join a room if it exist, or create one
        PhotonNetwork.JoinOrCreateRoom("LobbyRoom", null, null);
    }

    public virtual void OnJoinedRoom()
    {
        //Spawn in the player
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);
        //Deactivate the lobby Camera
        lobbyCamera.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        connectText.text = PhotonNetwork.connectionStateDetailed.ToString();

    }
}
