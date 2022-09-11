using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagbase : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabflag;


    void Start()
    {
        Instantiate(prefabflag, this.transform);
    }
    public void CreateFlag()
    {
        Instantiate(prefabflag, this.transform);
    }



}
