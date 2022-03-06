using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    public GameObject[] Datas;


    void Awake()
    {
        Datas = GameObject.FindGameObjectsWithTag("GamegerenteF");
        if (Datas.Length >= 2)
        {
            Destroy(Datas[0]);
        }
        DontDestroyOnLoad(transform.gameObject);
    }
}
