using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWebCam : MonoBehaviour {
    //FPS
    private int fps = 15;
    private WebCamTexture webcam;
    private Texture2D output;
    private Color32[] data;


    // Use this for initialization
    void Start () {
        // WebCamTexture webcamTexture = new WebCamTexture(1920, 1080, fps);

    

        webcam = new WebCamTexture(1920, 1080, fps);
        webcam.deviceName = "See3CAM_CU135";
        webcam.Play();
        output = new Texture2D(webcam.width, webcam.height);
        GetComponent<Renderer>().material.mainTexture = output;
        data = new Color32[webcam.width * webcam.height];



    }
	
	// Update is called once per frame
	void Update () {
        if (data != null)
        {
            webcam.GetPixels32(data);
            // You can play around with data however you want here.
            // Color32 has member variables of a, r, g, and b. You can read and write them however you want.
            output.SetPixels32(data);
            output.Apply();
        }
    }
}

