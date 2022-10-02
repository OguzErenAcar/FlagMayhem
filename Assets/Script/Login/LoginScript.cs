using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject Canvals;
 
    private Text infobar;



    public void loginbutton()
    {
        GameObject cloneprefab = Instantiate(prefab, new Vector3(Canvals.transform.position.x, Canvals.transform.position.y, Canvals.transform.position.z), Quaternion.identity);
        infobar = cloneprefab.transform.Find("info").GetComponent<Text>();


        cloneprefab.transform.eulerAngles = new Vector3(cloneprefab.transform.eulerAngles.x, cloneprefab.transform.eulerAngles.y, cloneprefab.transform.eulerAngles.z - 90f);
        cloneprefab.transform.parent = Canvals.transform;
        Text email = GameObject.Find("Input1").GetComponent<Text>();
        Text password = GameObject.Find("Input2").GetComponent<Text>();

        Button connection_button = cloneprefab.transform.GetChild(0).GetComponent<Button>();
        Button exit_button = cloneprefab.transform.GetChild(1).GetComponent<Button>();

        connection_button.onClick.AddListener(delegate
        {
            print("conection button ");
            StartCoroutine(LoginPostRequest(email.text, password.text));

            //cevap a göre sahne yükle 
            //SceneManager.LoadScene(1);
        });
        exit_button.onClick.AddListener(delegate
      {
          Destroy(cloneprefab);
      });



    }

     IEnumerator LoginPostRequest(string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post(APImanager.login_posturl, form);

        var operation = www.SendWebRequest();
        yield return operation;

        if (www.result == UnityWebRequest.Result.Success)
        {
            print("login den donen");
            Debug.Log($"response: {www.downloadHandler.text}");
           
            Data stuff = JsonConvert.DeserializeObject<Data>($"{www.downloadHandler.text}");

            infobar.text=stuff.message;
            PlayerProperties.token_ = stuff.token;
            PlayerProperties.id_= stuff.id;
            print("token ve id kayıt ");
            print("token:"+PlayerProperties.token_ );
            print("id:"+PlayerProperties.id_);

        }
        else
            Debug.Log("response failed");


        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {

            print(www.error);
        }
        print("login post bitis");
        StartCoroutine(GetInfo());
    }
    IEnumerator GetInfo()
    {
        print("getinfoda");
        //authentication ile at 
        WWWForm form = new WWWForm(); 
        form.AddField("id", PlayerProperties.id_);
        UnityWebRequest www = UnityWebRequest.Post(APImanager.info_geturl, form);
        www.SetRequestHeader("Authorization", "Bearer " + PlayerProperties.token_);
        //Authorization
        var operation = www.SendWebRequest();
        yield return operation;

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"response: {www.downloadHandler.text}");
            try
            {
                Data stuff = JsonConvert.DeserializeObject<Data>($"{www.downloadHandler.text}");
                print("response :"+$"{www.downloadHandler.text}");
                if (stuff.OnLogin == true)
                {
                    PlayerProperties.id_ = stuff.id;
                    PlayerProperties.OnLogin_ = true;
                    PlayerProperties.nickname_ = stuff.NickName;
                    SceneManager.LoadScene(1);
                    print("login succes");
                }
                else
                {
                    print("login failed");
                }
            }
            catch (System.Exception)
            {
                Debug.Log("response failed");
                throw;
            }

        }

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {

            print(www.error);
        }
    }

   


}
