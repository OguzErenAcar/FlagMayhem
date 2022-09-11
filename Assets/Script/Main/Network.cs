
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.Networking;

public class Network : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    readonly string login_posturl = "http://localhost:8080/auth/Login";
    readonly string signin_posturl = "http://localhost:8080/auth/sign-in";

    //odalara istek at 
    [SerializeField]
    private int Player_count;

    void Start()
    {
        Debug.Log("startta");   
    }


    
    void Update()
    {

    }




}
