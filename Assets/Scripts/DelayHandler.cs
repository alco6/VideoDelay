using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayHandler : MonoBehaviour {

    public GameObject GO;

     private Video scriptobject;

    void Start()
    {

        GO = GameObject.Find("Plane");


    }



    public void PutDelay()
    {

        scriptobject = GO.GetComponent<Video>();
        scriptobject.DelaymsProp = 1000;

    }

}
