using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWebCamQueue : MonoBehaviour
{
    //FPS
    private int fps = 30;
    private WebCamTexture webcam;
    private Texture2D output;
    private Color32[] data,data2;

    //private int Delayms=10000;

    //We create a Queue with the frames (RGBA representation of the colors
    Queue<Color32[]> myQ = new Queue<Color32[]>(120);


    // Use this for initialization
    void Start()
    {
        // WebCamTexture webcamTexture = new WebCamTexture(1920, 1080, fps);



        webcam = new WebCamTexture(1920, 1080, fps);
        webcam.deviceName = "See3CAM_CU135";
        webcam.Play();
        output = new Texture2D(webcam.width, webcam.height);
        GetComponent<Renderer>().material.mainTexture = output;
        data = new Color32[webcam.width * webcam.height];

     

    }

    // Update is called once per frame
    void Update()
    {
        //if (data != null)
        //{
            
            //Enque element
            myQ.Enqueue(webcam.GetPixels32(data));
            // You can play around with data however you want here.
            // Color32 has member variables of a, r, g, and b. You can read and write them however you want.

            //if (myQ.Count > (Delayms / 1000) * fps)
            //{
                data2 = myQ.Dequeue();
                output.SetPixels32(data2);
                output.Apply();
            //}
        //}
    }
}

