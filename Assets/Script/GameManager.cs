using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Pun;

public class GameManager : MonoBehaviour ,IPunInstantiateMagicCallback
{
    //  [SerializeField]
    // private GameObject Rooms ;

    //   [SerializeField] 
    // private GameObject Canvas; 


void IPunInstantiateMagicCallback.OnPhotonInstantiate(PhotonMessageInfo info)
    { 
        
        print("OnPhotonInstantiate  de");
        object[] instantiationData = info.photonView.InstantiationData;
        print(instantiationData);
    }

    void Awake()
    {
        //   Canvas = GameObject.Find("Canvas");
        // GameObject playerc = GameObject.Find("PlayerController(Clone)");

        // if (playerc==null)
        // {   
        //     print("gameman");
        //     GameObject GameOB = PhotonNetwork.Instantiate("PlayerController", Vector3.zero, Quaternion.identity);
        //     PlayerDatabase PlayerContr = GameOB.GetComponent<PlayerDatabase>();
        //     PlayerContr.TeamBlue = GameObject.Find("TeamBlue").GetComponent<TeamManager>();
        //     PlayerContr.TeamRed = GameObject.Find("TeamRed").GetComponent<TeamManager>();

        // }
    }

    void Start()
    {

        // GameObject Rooms_= Instantiate(Rooms,new Vector3(Canvas.transform.position.x, Canvas.transform.position.y, Canvas.transform.position.z),Quaternion.identity);
        // Rooms_.transform.eulerAngles = new Vector3(Rooms_.transform.eulerAngles.x, Rooms_.transform.eulerAngles.y, Rooms_.transform.eulerAngles.z - 90f);
        // Rooms_.transform.parent=Canvas.transform;
        // Rooms=Rooms_;
        // JoinButtonMethod();
    }



    private void JoinButtonMethod()
    {
        //     GameObject oda = Rooms.transform.GetChild(1).gameObject; 
        //     Button Joinbutton = oda.transform.GetChild(0).GetComponent<Button>();  
        //     Joinbutton.onClick.AddListener(delegate
        //     { 
        //         Destroy(Rooms);
        //    });

    }


    void Update()
    {

    }

}
