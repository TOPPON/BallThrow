using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BallThrower : MonoBehaviourPunCallbacks,IPunObservable
    //MonoBehaviourPunCallBacks
{
    private Vector3 velocity;
    private bool throwflag;
    // Start is called before the first frame update
    void Start()
    {
        throwflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            velocity = new Vector3(0, 2, 5);
            throwflag = true;
        }*/
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(throwflag);
            stream.SendNext(velocity);
        }
        else
        {
            throwflag = (bool)stream.ReceiveNext();
            velocity =(Vector3) stream.ReceiveNext();
            if (throwflag)
            {
                throwflag = false;
                Instantiate((GameObject)Resources.Load("Prefabs/Ball"), new Vector3(0, 3, -5), Quaternion.identity).GetComponent<Rigidbody>().velocity = velocity;
            }
        }
    }
}
