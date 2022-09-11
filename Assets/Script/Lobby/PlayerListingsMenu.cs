using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;


    [SerializeField]
    private PlayerListing _playerlisting;


    public List<PlayerListing> _listings = new List<PlayerListing>();
    public List<Player> _listingsLast = new List<Player>();
    private RoomsCanvases _roomsCanvases;

    [SerializeField]
    private Button button;


    private Player lastPlayer;

    void Awake()
    {

        // print("asdadaf");
        // PhotonNetwork.AutomaticallySyncScene = true;
        // GetCurrentRoomPlayers();
    }




    public void FirstInitialize(RoomsCanvases canvases)
    {
        print("fi");
        _roomsCanvases = canvases;
    }


    // public override void OnLeftRoom()
    // {   print("destroy child");
    //     _content.DestroyChildren();
    // }
    public void GetCurrentRoomPlayers()
    {

        if (!PhotonNetwork.IsConnected)
        {

            return;
        }
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.PlayerList == null)
        {
            return;
        }

        //listeye yeni gelenin indexi 0 oluyor 
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);

            _listingsLast.Add(playerInfo.Value);
        }

        setroomMasterClient();
    }

    private void AddPlayerListing(Player player)
    {

        PlayerListing listing = Instantiate(_playerlisting, _content);

        if (listing != null)
        {
            listing.SetPlayerInfo(player);

            _listings.Add(listing);

            print("oyuncu " + player.NickName + " " + _listings.Count);

        }

    }
    private void setroomMasterClient()
    {

        
        // print("local  " + PhotonNetwork.LocalPlayer.NickName + " " + PlayerProperties.sira_);
            print("sıra "+  PlayerProperties.sira_);
        GameObject StartGameButton = transform.Find("StartGame").gameObject;
       
        if (PlayerProperties.sira_!=0)
        {
            StartGameButton.SetActive(false);
        }
        else
        {
            PhotonNetwork.CurrentRoom.SetMasterClient(PhotonNetwork.LocalPlayer);
            StartGameButton.SetActive(true);
        }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);

        //   setroomid();

    }
    //baska biri odadan çıkınca 
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        foreach (Player pl in _listingsLast)
        {
            if (pl == otherPlayer)
                PlayerProperties.sira_ -= 1;
        }

        int index = _listings.FindIndex(x => x.Player == otherPlayer);

        //çıkann indexi listede olmuor sebeb
        if (index != -1)
        {   //sıkıntı burda 
            print(otherPlayer.NickName + " ind " + index);
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);

        }
        setroomMasterClient();


    }


    public void OnClickStart()
    {
        if (PlayerProperties.sira_==0)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(2);
        }


    }


}
