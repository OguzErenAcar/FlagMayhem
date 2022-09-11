using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Console;
    public bool isactive = false;
    public string code = "";



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Console.SetActive(!isactive);
            isactive = !isactive;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("entra basıldı ");
            Text input = Console.transform.Find("Input").GetComponent<Text>();
            code = input.text;
            Console.transform.Find("Input").GetComponent<Text>().text = "";
            Console.transform.GetComponent<InputField>().text = "";
        }
    }
}
