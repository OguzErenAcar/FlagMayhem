using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviourPun, IPunObservable
{
    public Animator anim;
    Rigidbody2D rb;
    public float speed = 7f;
    public float jumpSpeed = 5f;
    private float direction = 0f;
    public Flag flag;
    private bool isTouchingGround;
    float groundcheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;
    public TeamManager Team;

    public int health = 100;

    public Players_Controller PlayerController;
    public ConsoleManager Console;

    [HideInInspector] public bool isFacingRight = true;

    PhotonView pw;
    public int flagscore = 0;

    public Timer timer;


    private Image bar;
    public Text Nickname;

    public GameObject head, body;

    public bool unlimitedhealth = false;

    void Awake()
    {

        print("local nick " + PlayerProperties.nickname_);

        Console = GameObject.Find("ButtonController").GetComponent<ConsoleManager>();
        pw = GetComponent<PhotonView>();
        PlayerController = GameObject.Find("PlayerController").GetComponent<Players_Controller>();
        this.gameObject.GetComponent<PhotonView>().RPC("addlist", RpcTarget.All, null);
        this.gameObject.transform.parent = PlayerController.transform;
        GameObject healthbar = this.gameObject.transform.Find("playerCanvas").gameObject.transform.Find("healthbar").gameObject;
        bar = healthbar.transform.Find("bar_").GetComponent<Image>();
        float R = UnityEngine.Random.Range(0, 226 / 255f);
        float G = UnityEngine.Random.Range(0, 226 / 255f);
        float B = UnityEngine.Random.Range(0, 226 / 255f);
        Color ColorToBeGenerate = new Color(R, G, B);
        bar.color = ColorToBeGenerate;
        // print(new Color((float)UnityEngine.Random.Range(0, 255), (float)UnityEngine.Random.Range(0, 255), (float)UnityEngine.Random.Range(0, 255)));
        Nickname = this.gameObject.transform.Find("playerCanvas").gameObject.transform.Find("NickName").gameObject.GetComponent<Text>();





    }
    void Start()
    {
        //bütün photon viewlere  odadaki bütün bilgiler gider  

        PlayerController.AddPlayerCountInScene();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        if (pw.IsMine)
        {
            rb = GetComponent<Rigidbody2D>();
            anim.SetBool("isWalking", false);
            timer.thisplayer = this.transform.gameObject;
        }

        if (pw.IsMine)
        {

            object[] obj = { pw.ViewID, PlayerProperties.nickname_ };
            transform.gameObject.GetComponent<PhotonView>().RPC("setnick", RpcTarget.All, obj);

        }

    }

    [PunRPC]
    private void setnick(object[] data)
    {
        //pw is mine olmıyacak???
        int ordinary_id = Convert.ToInt32(data[0]);
        string nick = Convert.ToString(data[1]);
        if (ordinary_id == pw.ViewID)
        {
            Nickname.text = nick;
        }


    }


    [PunRPC]
    public void addlist()
    {

        PlayerController.photonviewlist.Add(this.transform.GetComponent<PhotonView>());
    }



    [PunRPC]
    private void SetTeam()
    {

        TeamManager CurrentTeam = PlayerController.getCurrentTeam();

        this.transform.parent = CurrentTeam.transform;

        this.transform.position = CurrentTeam.Base_.transform.position;

        this.GetComponent<Character_Controller>().Team = CurrentTeam;
        print(Team.name + "den üretildi");
        CurrentTeam.team_players.Add(this.GetComponent<Character_Controller>()); 
        body.transform.GetComponent<SpriteRenderer>().color = CurrentTeam.Color.color;
        head.transform.GetComponent<SpriteRenderer>().color = CurrentTeam.Color.color; 
    }


     
    //burda değil karşıda doru çalışıyor 


 
    [PunRPC]
    public void FindKiller(int killer_id)
    {
        if (pw.IsMine)
        {


            if (this.transform.gameObject.GetComponent<PhotonView>().ViewID == killer_id)
            {
                PlayerProperties.score_ += 100;
                PlayerProperties.kill_ += 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null && bullet.team != this.Team)
        {
            health -= 34;
            if (health <= 0)
            { 
                if (flag != null)
                { 
                    Team.flagPosition= flag.transform.position;
                    Team.flagp=true;
                    flag.player = null;
                    Destroy(flag.gameObject);
                    flag = null; 

                  //  StartCoroutine(setTflag(LocateFlag));
                } 

                if (pw.IsMine)
                {

                    PlayerProperties.death_++;  
                    PhotonNetwork.GetPhotonView(bullet.incoming_id).RPC("FindKiller", RpcTarget.All, bullet.incoming_id); 
                    Team.GetComponent<PhotonView>().RPC("PlayerSetBase", RpcTarget.All, pw.ViewID);
                }
            }
            Destroy(bullet.gameObject);
        }
    }

    // Update is called once per frame

    
    



    [PunRPC]
    public void hackhealth(int id)
    {
        print("rpc");

        health = 100;



    }

    void Update()
    {
        if (Team != null)
        {

            bar.fillAmount = health / 100f;
        }

        if (pw.IsMine)
        {
            if (unlimitedhealth)
            {
                this.gameObject.GetComponent<PhotonView>().RPC("hackhealth", RpcTarget.All, pw.ViewID);
                print(PlayerProperties.nickname_ + " true");

            }

            if (Console.isactive)
            {
                if (Console.code == "health")
                {
                    print("health");
                     unlimitedhealth = true;
                    // unlimitedhealth = true;
                    Console.code = "";

                }
                if (Console.code == "health*")
                {
                    unlimitedhealth = false;

                    // unlimitedhealth = false;
                    Console.code = "";
                }
                if (Console.code == "bullet")
                {
                    transform.GetComponent<playerShoot>().fireRate = 0.1f;
                    Console.code = "";
                }
                if (Console.code == "bullet*")
                {
                    transform.GetComponent<playerShoot>().fireRate = 0.2f;
                    Console.code = "";
                }
            }
            //Moveme


        }





        isTouchingGround = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);

        Movement();

        //Animation

        if (direction < 0f || direction > 0f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (!isTouchingGround)
        {
            anim.SetBool("isWalking", false);
        }


        if (isTouchingGround)
        {
            anim.SetBool("isGrounded", true);
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }

        print("walking:" + anim.GetBool("isWalking") + " " + "grounded:" + anim.GetBool("isGrounded") + " " + "jump:" + anim.GetBool("isJump"));


    }




    private void Movement()
    {
        if (pw.IsMine)
        {


            direction = Input.GetAxisRaw("Horizontal");


            if (direction > 0f)
            {
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                //transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
                //isFacingRight = true;


            }
            else if (direction < 0f)
            {
                rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                //transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
                //isFacingRight = false;

            }

            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);

            }




            if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
            {

                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                anim.SetBool("isJump", true);
            }
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(anim.GetBool("isWalking"));
            stream.SendNext(anim.GetBool("isJump"));
            stream.SendNext(anim.GetBool("isGrounded"));
        }
        else if (stream.IsReading)
        {
            anim.SetBool("isWalking", (bool)stream.ReceiveNext());
            anim.SetBool("isJump", (bool)stream.ReceiveNext());
            anim.SetBool("isGrounded", (bool)stream.ReceiveNext());

        }
    }
}
