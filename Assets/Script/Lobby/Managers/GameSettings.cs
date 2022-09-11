using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Manager/GameSettings")]
public class GameSettings : ScriptableObject
{



    [SerializeField]
    private string _gameVersion="0.0.0";
    public string GameVersion {get { return _gameVersion;}}

    [SerializeField]
    private  string _nicName ="Punfish"; 

    public string NicName{
         

         get{
            int value = Random.Range(0,99);
            _nicName ="Player"+value.ToString();
            PlayerProperties.nickname_=_nicName;
            return _nicName ;

         }
    }

}
