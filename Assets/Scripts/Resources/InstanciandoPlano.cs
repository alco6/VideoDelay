using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciandoPlano : MonoBehaviour {


    GameObject cam= null;
    Quaternion q;

    Vector3 rotationV;

    GameObject m_videoGO2;




    void Start () {
        //        steamCam = FindObjectOfType<SteamVR_Camera>().gameObject.transform;

         cam =  FindObjectOfType<Camera>().gameObject;
         m_videoGO2 = GameObject.CreatePrimitive(PrimitiveType.Plane);



        ///////////////////////////////////////////////
        ///
        /// 
        /// 
        ///
        m_videoGO2.AddComponent<Canvas>();
        m_videoGO2.layer = gameObject.layer;

        ///////////////////////////////////////////////

    }

    //Previous Version
    void rotate1() {
        m_videoGO2.transform.position = cam.transform.position + cam.transform.forward * 2;
        Quaternion rotationQ = Quaternion.LookRotation(cam.transform.forward);
        //This one rotate the cube. 

    }

    //Previous Version
    void rotateCompletelyOverlayed() {

        m_videoGO2.transform.position = cam.transform.position + cam.transform.forward * 2;
        m_videoGO2.transform.rotation = cam.transform.rotation;
    }


    //Working version for cube but not for Plane.
    void RotateandFollowCamera() {
        //m_videoGO2.transform.rotation = Quaternion.Euler(0, 0, 90);

        //Take always de object at the same distance of the camera.
        m_videoGO2.transform.position = cam.transform.position + cam.transform.forward * 2;

        // take quaternion with rotation of the camera.
        q = cam.transform.rotation;
        // Get rid of rotation  in  Z axis... it is needed to convert the quaternion to euler. 
        q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);



        //  m_videoGO2.transform.rotation = q;

    }


    // Update is called once per frame
    void Update () {

         RotateandFollowCamera();

       // m_videoGO2.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;



    }
}
