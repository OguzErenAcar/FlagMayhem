using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    PhotonView pw_b;
    public GameObject ordinary;
    public int incoming_id;

    public TeamManager team;
    private void Awake()
    {


    }
    private void Start()
    {
        pw_b = GetComponent<PhotonView>();
    }
    private void FixedUpdate()
    {

        rb.velocity = transform.right * bulletSpeed;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);


    }

    [PunRPC]
    public void setbullet(int ordinaryid)
    {
        this.incoming_id = ordinaryid;
        team = PhotonNetwork.GetPhotonView(incoming_id).transform.GetComponent<Character_Controller>().Team;

    }

    [PunRPC]
    public void destroybullet( )
    {
        //PhotonNetwork.GetPhotonView(ordinaryid);

        StartCoroutine(wait());
    }
    public IEnumerator wait()
    {

        //burda atıyor karşıda nasıl atama yapıcak 
        yield return new WaitForSeconds(1f);
        try
        {
            Destroy(gameObject);
        }
        catch
        {

        }
    }

}
