using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public BaseManager Base_;
    public Material Color;
    public List<Character_Controller> team_players;
    public int TeamScore =0;
    public bool boolWon=false;

    [SerializeField]
    public Image healthbar;

    public string TeamName;
    void Start()
    {
        Base_ = transform.GetChild(0).GetComponent<BaseManager>();
        TeamName = gameObject.name;

    }

   [PunRPC]
    public void PlayerSetBase(int ordinary_id )
    {
        Character_Controller ordinary_ =PhotonNetwork.GetPhotonView(ordinary_id).GetComponent<Character_Controller>();
        ordinary_.gameObject.SetActive(false); 
        ordinary_.health=100; 
        ordinary_.transform.position = Base_.gameObject.transform.position;
        ordinary_.gameObject.SetActive(true); 
     

    } 
}
