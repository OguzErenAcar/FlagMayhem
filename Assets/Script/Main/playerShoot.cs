using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class playerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public GameObject RotatePoint;
    public GameObject bullet;
    float timeUntilFire;
    Character_Controller cc;

    public GameObject BulletTransform ;
    private void Start()
    {
        
       // BulletTransform= RotatePoint.transform.Find("BulletTransform").gameObject;
        cc = gameObject.GetComponent<Character_Controller>(); 
        ParticleSystem part = GetComponentInChildren<ParticleSystem>();

    }
    private void Update()
    {
        if (GetComponent<PhotonView>().IsMine == true)
        {
            if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
            {
                //gameObject.GetComponent<PhotonView>().RPC("Shoot", RpcTarget.All, null);
                Shoot();

                timeUntilFire = Time.time + fireRate;
            }
        }
        else{
            RotatePoint.SetActive(false);
        }



    }
    
    void Shoot()
    {
        var part = GetComponentInChildren<ParticleSystem>();
        part.Play();
        float angle = RotatePoint.transform.GetComponent<Aim>().rotZ;
        GameObject bullet = PhotonNetwork.Instantiate("Bullet", BulletTransform.transform.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        bullet.GetComponent<PhotonView>().RPC("setbullet",RpcTarget.All,this.transform.gameObject.GetComponent<PhotonView>().ViewID);
        bullet.GetComponent<PhotonView>().RPC("destroybullet",RpcTarget.All,null);
         
    } 

}
