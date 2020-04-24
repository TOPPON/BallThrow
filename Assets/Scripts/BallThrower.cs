using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BallThrower : MonoBehaviourPunCallbacks,IPunObservable
{
    private Vector3 velocity;
    private bool Throwflag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(1))
        {
            Throwflag = true;
            velocity = Input.acceleration;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Throwflag = true;
            velocity = new Vector3(0,5,3);
        }
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(Throwflag);
            stream.SendNext(velocity);
            if (Throwflag)
            {
                Throwflag = false;
            }
        }
        else
        {
        }
    }
}
