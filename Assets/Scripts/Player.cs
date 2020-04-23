using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Player : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                PhotonNetwork.Instantiate("Prefabs/NetBullet", this.gameObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            }
        }
    }
}
