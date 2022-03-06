using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciaCArtas : MonoBehaviour
{

    public GameObject Canva1, CanvaTips;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("invokecartas");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator invokecartas()
    {
        yield return new WaitForSeconds(8);
        Canva1.gameObject.SetActive(true);
        CanvaTips.gameObject.SetActive(false);
    }
}
