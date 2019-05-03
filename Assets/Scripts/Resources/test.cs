using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {


    GameObject cam= null;
    Quaternion q;

    Vector3 rotationV;
   


    // Use this for initialization
    void Start () {
        //        steamCam = FindObjectOfType<SteamVR_Camera>().gameObject.transform;

        cam =  FindObjectOfType<Camera>().gameObject;
         


    }


    void rotate1() {
        this.transform.position = cam.transform.position + cam.transform.forward * 2;
        Quaternion rotationQ = Quaternion.LookRotation(cam.transform.forward);
        //This one rotate the cube. 

    }


    void rotateCompletelyOverlayed() {

        this.transform.position = cam.transform.position + cam.transform.forward * 2;
        this.transform.rotation = cam.transform.rotation;
    }



    // Update is called once per frame
    void Update () {


        //Take always de object at the same distance of the camera.
        this.transform.position = cam.transform.position + cam.transform.forward * 2;
        // take quaternion with rotation of the camera.
         q = cam.transform.rotation;
        // Get rid of rotation  in  Z axis... it is needed to convert the quaternion to euler. 
        q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
        transform.rotation = q;
        
        

        //change vector3 Euler angle to Quaternion, you can use the Quaternion.Euler(x,y,z)
        // this.transform.rotation= Quaternion.Euler(rotationQ.eulerAngles.y, rotationQ.eulerAngles.y, rotationQ.eulerAngles.z);

        //this.transform.rotation = Quaternion.Euler(rotationV.x, rotationV.y, 0); 
        //transform.eulerAngles = new Vector3(rotationV.x, rotationV.y, 0);

        /*
        List<Vector3> tr = ;
        rectT.localScale = tr[2];
        rectT.localPosition = tr[0];
        rectT.localRotation = Quaternion.Euler(tr[1]);
*/


        /*
               //  this.transform.position = cam.transform.position + new Vector3(0,0,3);
                Vector3 relativePos = transform.position - cam.transform.position;
               // rotationQ = cam.transform.rotation;
                this.transform.rotation = Quaternion.LookRotation(relativePos);

         */

        //Vector3 relativePos = (this.transform.position + new Vector3(0, 0, 3)) - cam.transform.position;

        //Quaternion rotation = Quaternion.LookRotation(relativePos);

        //Quaternion current = transform.localRotation;

        //transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        //transform.Translate(0, 0, 3 * Time.deltaTime);

    }
}
