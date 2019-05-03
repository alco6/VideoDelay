using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Display.displays.Length; i++)
            //Activate display at that size
            Display.displays[i].Activate(1024, 768, 60);

    }


}
