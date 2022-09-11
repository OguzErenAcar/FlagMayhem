using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DatabeseScript : MonoBehaviour
{
    [SerializeField]
    private GameObject authenticationPrefab;

    [SerializeField]
    private GameObject Canvals;

    private int postcode =0;
    readonly string login_posturl = "http://localhost:8080/auth/Login";
    readonly string signin_posturl = "http://localhost:8080/auth/sign-in";


    // Start is called before the first frame update
    void Start()
    {
        print("databese script ");

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoginPostRequest(string email, string password)
    {

        
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
 
        UnityWebRequest www = UnityWebRequest.Post(login_posturl,form);
        var response = UnityWebRequest.Result.Success;

        yield return www.SendWebRequest();


        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {

            print(www.error);
        }
    }

    IEnumerator SigninPostRequest(string email, string password)
    {
        WWWForm form = new WWWForm();
        print("sign in de ");
        form.AddField("email", email);
        form.AddField("password", password);
        print(signin_posturl);

        UnityWebRequest www = UnityWebRequest.Post(signin_posturl, form);

        // User myUser = new User(); 
        // myUser.myField = "myData"; 
        // JsonUtility.ToJson(myUser)
        //www.SetRequestHeader("Accept", "application/json");


        yield return www.SendWebRequest();


        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        { 
            print(www.error); 
        } 

    }

    public void loginbutton()
    { 
        Authentication(2);


    }

    public void signinbutton()
    { 
        Authentication(1);
    }

    private void Authentication(int number)
    {
        postcode = number;
        GameObject cloneprefab = Instantiate(authenticationPrefab, new Vector3(Canvals.transform.position.x, Canvals.transform.position.y, Canvals.transform.position.z), Quaternion.identity);

        cloneprefab.transform.eulerAngles = new Vector3(cloneprefab.transform.eulerAngles.x, cloneprefab.transform.eulerAngles.y, cloneprefab.transform.eulerAngles.z - 90f);
        cloneprefab.transform.parent = Canvals.transform;

        Text  input1 = GameObject.Find("Input1").GetComponent<Text>();
        Text  input2 = GameObject.Find("Input2").GetComponent<Text>();

        Button connection_button = cloneprefab.transform.GetChild(0).GetComponent<Button>();
        Button exit_button = cloneprefab.transform.GetChild(1).GetComponent<Button>();
  
        connection_button.onClick.AddListener(delegate
        { 
            switch(number) 
            {
            case 1: 
                print(input1.text);
                print(input2.text);  
                StartCoroutine(SigninPostRequest(input1.text,input2.text)); 

                break;
            case 2: 
 
                 print(input1.text);
                 print(input2.text); 
                 StartCoroutine(LoginPostRequest(input1.text,input2.text)); 
                break;
            
            }
            

        });

        exit_button.onClick.AddListener(delegate
        {
            Destroy(cloneprefab); 
        });
    }


  

}
