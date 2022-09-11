using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CameraManager : MonoBehaviourPun
{ 
    public GameObject Ordinary ;
    public Vector3 ofsettVector;
 
    void Update()
    {
        if(Ordinary!=null)
        { 
            transform.position=new Vector3(Ordinary.transform.position.x,Ordinary.transform.position.y,transform.position.z);
        }
 
    }
}
