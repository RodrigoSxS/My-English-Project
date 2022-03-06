using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UDP;

public class Startsandboxx : MonoBehaviour
{

    private void Awake()
    {
//# Instantiate the listener
        IInitListener listener = new InitListener();
//# Use the listener to initialize the UDP stuff
        StoreService.Initialize(listener);
    }

}
