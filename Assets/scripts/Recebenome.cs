using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recebenome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
