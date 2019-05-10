using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.Linq;

public class Video : MonoBehaviour {




    //We create a Queue with the frames (RGBA representation of the colors
    Queue<Color32[]> myQ = new Queue<Color32[]>(100);

    //Target Texture, used to render the image from the texture of the webcam
    Texture2D texture;

    // private static DateTime lastSendTime = DateTime.Now;

    //Texture of the Webcam
    private WebCamTexture mycamTexture;

    //Texture Plane
    private Texture PlaneTexture; 

    //Counter of frames for the webcam texture
    uint frcount = 0;
    //Game Object where we willplace the video.
    GameObject m_videoGO;
    //FPS
    int fps = 60;

    //time measure 
    int tick, tock = 0;


 
    // Timer 
    private Stopwatch m_delayTimer = new Stopwatch();

    //DELAY

    public int Delayms = 3000;

    //Property to change the Delay
    public int DelaymsProp
    {
        get
        {
            return Delayms;
        }
        set
        {
            Delayms = value;
            UnityEngine.Debug.Log("delay changed to" + value);
            m_delayTimer.Reset();
            m_delayTimer.Start();
            myQ.Clear();


        }
    }
    


    // Use this for initialization
    void Start () {

        //Full Screen
        Screen.SetResolution(1920, 1080, true);


        string camName ="";


        UnityEngine.Debug.Log("Start");
        //List of Cam Devices
        WebCamDevice[] devices = WebCamTexture.devices;
        UnityEngine.Debug.Log("Number of web cams connected: " + devices.Length);
 
        for (int i = 0; i < devices.Length; i++)
        {
            UnityEngine.Debug.Log(i + " " + devices[i].name);
            if (devices[i].name == "See3CAM_CU135")
            {
                UnityEngine.Debug.Log(" GOTCHAA " + devices[i].name);
                camName = devices[i].name;
                UnityEngine.Debug.Log("The webcam name is " + camName);

            }

        }
        

        //Creation of the Target object where the image will be rendered
        //m_videoGO = GameObject.CreatePrimitive(PrimitiveType.Cube);//In case needed to instantiate object directly
        m_videoGO = this.gameObject;

        //m_videoGO.transform.position = new Vector3(0, 0.5f, 0);

        //Creation of the camera texture and asign to the specific camera
        // mycamTexture = new WebCamTexture();
        mycamTexture = new WebCamTexture(1920, 1080, fps);
        //mycamTexture = new WebCamTexture(640, 480, 120);

        mycamTexture.deviceName = camName;


        //Put camera texture in the renderer of the prefab
        // Need to specify where to render the Webcam content
       // m_videoGO.GetComponent<Renderer>().material.mainTexture = mycamTexture;

        //Debug.Log("The Texture is " + m_videoGO.GetComponent<Renderer>().material.mainTexture.GetType().ToString());
        //Camera start acquiring images 
        mycamTexture.Play();

        //Creation of a new Texture2D where we will place the frames acquired.
        texture = new Texture2D(mycamTexture.width, mycamTexture.height);
        //We change the texture of the object to the new one. 
        m_videoGO.GetComponent<Renderer>().material.mainTexture = texture;
        //texture = (Texture2D)m_videoGO.GetComponent<Renderer>().material.mainTexture;
        //resize_video();

        // Timer starts
        m_delayTimer.Start();

        PlaneTexture = m_videoGO.GetComponent<Renderer>().material.mainTexture;

        PlaneTexture = texture;





    }


    void Stop() {
        m_videoGO.SetActive(false);
        mycamTexture.Stop();
    }

    private void resize_video()
    {

        var rTr = m_videoGO.GetComponent<RectTransform>();
        rTr.sizeDelta = new Vector2(mycamTexture.width, mycamTexture.height); 

        //rTr.pivot = new Vector2(c.get<float>("pivot_x"), c.get<float>("pivot_y"));
    }

    // Update is called once per frame
    void Update () {


        Time.timeScale = 2.0f;


        //    //MYVERSION

        //    //check if the video buffer has changed since the last frame
        //    if (mycamTexture.didUpdateThisFrame) { 
        //        //Enque element
        //        myQ.Enqueue(mycamTexture.GetPixels32());

        //     }


        //    // When time has passed we deque from the queue and apply the frames to the new texture.
        //    if (m_delayTimer.ElapsedMilliseconds >= Delayms)
        //    {

        //        if (myQ.Count() > 0)
        //        {
        //            texture.SetPixels32(myQ.Dequeue());
        //            texture.Apply();
        //        }

        //    }
        //}



        //if (texture == null)
        //{
        //    texture = new Texture2D(mycamTexture.width, mycamTexture.height);
        //}

        //    myQ.Enqueue(mycamTexture.GetPixels32());







        ///  if (mycamTexture.didUpdateThisFrame)
        ///  {
        //Enque element
        myQ.Enqueue(mycamTexture.GetPixels32());
                //tick = Environment.TickCount & Int32.MaxValue;

          ///  }


            if (myQ.Count > (Delayms * fps / 1000))
            {
                         //var pixels = myQ.Dequeue();
                         texture.SetPixels32(myQ.Dequeue());
                         texture.Apply();
                         //gameObject.material.mainTexture = texture;
                         // m_videoGO.GetComponent<Renderer>().material.mainTexture = texture;
                         

                        //tock = Environment.TickCount & Int32.MaxValue;
                        //UnityEngine.Debug.Log("Tick tock" + (tock - tick));

           }

       


    }









    /* //Enque element
     if (mycamTexture.updateCount != frcount)
     {
         myQ.Enqueue(mycamTexture.GetPixels32());
         frcount = mycamTexture.updateCount;
     }

     // UnityEngine.Debug.Log("  FPS " + mycamTexture.requestedFPS);
     //  UnityEngine.Debug.Log("  width " + mycamTexture.width);
     //  UnityEngine.Debug.Log("  heigh " + mycamTexture.height);
     //  UnityEngine.Debug.Log("  1.0f / Time.deltaTime " + 1.0f / Time.deltaTime);





     // When time has passed we deque from the queue and apply the frames to the new texture.
     if (m_delayTimer.ElapsedMilliseconds >= Delayms)
     {
         // UnityEngine.Debug.Log(" Timer Ellapsed Milliseconds " + m_delayTimer.ElapsedMilliseconds);
         // UnityEngine.Debug.Log(" Delay " + Delayms);
         // UnityEngine.Debug.Log(" myQ.Count " + myQ.Count());
         if (myQ.Count() > 0)
         {
             texture.SetPixels32(myQ.Dequeue());
             texture.Apply();
         }

     }
     else {
         UnityEngine.Debug.Log(" it did not enter" );

     }
     }

 */
}



