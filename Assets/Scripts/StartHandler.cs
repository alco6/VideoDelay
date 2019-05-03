using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHandler : MonoBehaviour {

    public GameObject GO;

     Video scriptobject;

   void Start()
    {

        GO = GameObject.Find("Plane");
    
    }

public void Delayto0()
    {
       

        scriptobject = GO.GetComponent<Video>();
        scriptobject.DelaymsProp = 0;


    }
}


