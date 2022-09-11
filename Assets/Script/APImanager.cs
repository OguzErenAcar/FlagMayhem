using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class APImanager : MonoBehaviour
{


    public static string signin_posturl ;
    public static string login_posturl  ;
    public static string info_geturl ;
    public static string setOnlogin_posturl ;
    public static string saved_gameScore ;


    public string IP ;


    void Awake()
    {

        setUrl();

    }

    public void setUrl(){
        
        signin_posturl= "http://"+IP+":8080/auth/sign-in";
        login_posturl="http://"+IP+":8080/auth/Login";
        info_geturl="http://"+IP+":8080/UserArchive/user-info";
        setOnlogin_posturl= "http://"+IP+":8080/UserArchive/setOnlogin";
        saved_gameScore="http://"+IP+":8080/UserArchive/GameScores";

    }
    void Start()
    {

    }


}
