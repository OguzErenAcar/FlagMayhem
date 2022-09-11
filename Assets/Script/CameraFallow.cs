using System;
using UnityEngine;
using Photon.Pun;
public class CameraFallow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
      
        
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject player in players)
        //{
        //    if (PhotonView.Get(player).IsMine)
        //    {
        //        this.target = player.transform;
        //        break;
        //    }
        //}
    }
    private void LateUpdate()
    {
        if (PhotonView.Get(player).IsMine)
        {
            gameObject.transform.position = player.transform.position+offset;
        }
        //this.transform.position = target.position + offset;
    }
}