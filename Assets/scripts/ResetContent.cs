using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetContent : MonoBehaviour
{
    // Start is called before the first frame update
    public void posicont()
    {
        gameObject.GetComponent<RectTransform>().position = new Vector3(0, 146, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
 


    
}