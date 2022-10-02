using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProperties{
    private static string token = "";
    private static bool OnLogin = false;
    private static string id = "";
    private static string CurrentRoomİd = "";
    private static string nickname = "";
    private static bool in_room = false;
    private static int kill = 0;
    private static int death = 0;
    private static int score = 0;
    private static int win = 0;
    private static int lose = 0;
    private static int sira = 0;
    public static bool deneme = false;

    public static int sira_ { get { return sira; } set { sira = value; } }
    public static string token_ { get { return token; } set { token = value; } }
    public static bool OnLogin_ { get { return OnLogin; } set { OnLogin = value; } }
    public static string id_ { get { return id; } set { id = value; } }
    public static string CurrentRoomİd_ { get { return id; } set { id = value; } }
    public static string nickname_ { get { return nickname; } set { nickname = value; } }
    public static int kill_ { get { return kill; } set { kill = value; } }
    public static int death_ { get { return death; } set { death = value; } }
    public static int score_ { get { return score; } set { score = value; } }
    public static bool in_room_ { get { return in_room; } set { in_room = value; } }
    public static int win_ { get { return win; } set { win = value; } }
    public static int lose_ { get { return lose; } set { lose = value; } }


    public static void resetdataGame()
    {


        CurrentRoomİd = "";
        in_room = false; 
        kill = 0;
        death = 0;
        score = 0;
        win = 0;
        lose = 0;
        sira = 0;

    }


    public static void resetdata()
    {

        token = "";
        OnLogin = false;
        id = "";
        CurrentRoomİd = "";
        nickname = "";
        in_room = false; 
        kill = 0;
        death = 0;
        score = 0;
        win = 0;
        lose = 0;
        sira = 0;

    }




}
