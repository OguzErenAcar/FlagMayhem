using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[CreateAssetMenu(menuName ="Singletons/MasterManager")]
public class MasterManager : ScriptableObjectSingelton<MasterManager>
{
   
[SerializeField]
private GameSettings _gameSettings;
public static GameSettings GameSettings {get { return Instance._gameSettings ;}}



}

