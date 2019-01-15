using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour {

    [SerializeField] private Transform playerCamera;
    [SerializeField] private MonoBehaviour[] playerControlScripts;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        Initialize();
    }

    private void Initialize()
    {
        if(photonView.isMine)
        {

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
}
