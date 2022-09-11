using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviourPunCallbacks
{


    public void startbutton()
    {
        SceneManager.LoadScene(1);
    }

    public void quitbutton()
    {
        Application.Quit();
    }

    public void return_main()
    {    
        
        
            print("burda");
        if( PlayerProperties.OnLogin_){
            StartCoroutine(transform.gameObject.GetComponent<QuitGameRequest>().SetOnloginPostRequest())  ; 

        }
        PlayerProperties.resetdata();

        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene(0);
      //  PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
    }

  


}

