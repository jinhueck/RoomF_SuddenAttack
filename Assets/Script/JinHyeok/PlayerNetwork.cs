using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour
{

    [SerializeField] private Transform playerCamera;
    [SerializeField] private MonoBehaviour[] playerControlScripts;

    private PhotonView photonView;

    public int playerHealth = 100;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        Initialize();
    }

    private void Initialize()
    {
        if(photonView.isMine)
        {
            //Do stuff here
        }
        //Handle functionality for non-local character
        else
        {
            //Disable it's camera
            playerCamera.gameObject.SetActive(false);

            //Disable it's control scripts
            foreach(MonoBehaviour m in playerControlScripts)
            {
                m.enabled = false;
            }
        }
    }

    private void Update()
    {
        if(!photonView.isMine)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            playerHealth -= 5;
        }
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //Send data
        if(stream.isWriting)
        {
            stream.SendNext(playerHealth);
        }
        //Receiving data
        else if(stream.isReading)
        {
            playerHealth = (int)stream.ReceiveNext();
        }
    }

    [PunRPC]
    public void ApplyDamage(int damage)
    {
        playerHealth -= damage;

        if(playerHealth <= 0)
        {
            Debug.Log("other player is Died");
        }
    }
}
