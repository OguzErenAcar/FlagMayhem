using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Flag : MonoBehaviour
{
    PhotonView pw;
    public Character_Controller player;

    public GameObject flagbase;

    void Awake()
    {
        flagbase = this.gameObject.transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player"&&  player==null)
        { 
            GameObject Flag = GameObject.Find("Flag");   
            this.transform.parent = collision.gameObject.transform;
            collision.gameObject.GetComponent<Character_Controller>().flag=this.gameObject.transform.GetComponent<Flag>();
            player = collision.gameObject.GetComponent<Character_Controller>();
        }

    }
}
