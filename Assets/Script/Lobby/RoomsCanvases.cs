using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    
    //Canvas

    [SerializeField]
    private CreateRooms _createRoomsCanvas;
    public CreateRooms  CreateRoomsCanvas {get { return _createRoomsCanvas ;}}  


    [SerializeField]
    private CurrentRoom _currentRoomsCanvas;
    public CurrentRoom  CurrentRoomsCanvas {get { return _currentRoomsCanvas ;}}  


    private void Awake(){

            FirstInitialize();

    }
    private void FirstInitialize(){


        CreateRoomsCanvas.FirstInitialize(this);
        CurrentRoomsCanvas.FirstInitialize(this);

    }



}
