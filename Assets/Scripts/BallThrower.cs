using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BallThrower : MonoBehaviourPunCallbacks,IPunObservable
{
    private Vector3 velocity;
    private bool throwflag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            if(Input.GetMouseButtonUp(1))
            {
                velocity = Input.acceleration;
                throwflag = true;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                velocity = new Vector3(0,3,5);
                throwflag = true;

            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(velocity);
            stream.SendNext(throwflag);
            if (throwflag) throwflag = false;
            Debug.Log(throwflag);
        }
        else
        {
            velocity =(Vector3)stream.ReceiveNext();
            throwflag = (bool)stream.ReceiveNext();
            if(throwflag)
            {
                Instantiate((GameObject)Resources.Load("Prefabs/Ball"),new Vector3(0,3,-5),Quaternion.identity).GetComponent<Rigidbody>().velocity = velocity ;
            }
            Debug.Log(throwflag);
        }
    }
    
}
