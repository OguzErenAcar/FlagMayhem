using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setİp : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] 
    private GameObject Console;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Return))
        {
            print("entra basıldı ");
            Text input =transform.Find("Input").GetComponent<Text>();
            print(input.text);
            Console.GetComponent<APImanager>().IP= input.text; 
            Console.GetComponent<APImanager>().setUrl();
            transform.Find("Input").GetComponent<Text>().text = "";
            transform.GetComponent<InputField>().text = "";
        }
    }
}
