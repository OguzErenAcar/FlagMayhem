using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class QuitGameRequest : MonoBehaviour
{

 


    void OnApplicationQuit()
    {

        if (PlayerProperties.OnLogin_)
        {

            StartCoroutine(SetOnloginPostRequest());

        }

    }
 
    public IEnumerator SetOnloginPostRequest()
    {

        WWWForm form = new WWWForm();

        form.AddField("id", PlayerProperties.id_);
        UnityWebRequest www = UnityWebRequest.Post(APImanager.setOnlogin_posturl, form);
        www.SetRequestHeader("Authorization", "Bearer " + PlayerProperties.token_);


        var operation = www.SendWebRequest();
        print("onsetonlogin");
        yield return operation;

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"response: {www.downloadHandler.text}");
            try
            {
                Data stuff = JsonConvert.DeserializeObject<Data>($"{www.downloadHandler.text}");
                print("response :" + $"{www.downloadHandler.text}");
                if (stuff.OnLogin == false)
                {
                    print("onlogin false succes");
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
        else
            Debug.Log("response failed__");

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            print(www.error);
        }

    }


}










