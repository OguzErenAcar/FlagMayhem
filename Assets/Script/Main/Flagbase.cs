using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagbase : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabflag;

    private Vector3 FlagLocate;

    void Start()
    {
        Instantiate(prefabflag, this.transform);
        FlagLocate =prefabflag.transform.position;
    }
    public void CreateFlag()
    {
        Instantiate(prefabflag, this.transform);
    }
    public void CreateFlag(Vector3 localp)
    {
        print("create flag2");
        Instantiate(prefabflag, localp,this.transform.rotation);
    }


}
