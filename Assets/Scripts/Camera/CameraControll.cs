using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour{

    public List<GameObject> vCams;
    public int vCamIndex;

    private void Start() {

        vCamIndex = 0;

         foreach (Transform child in transform)
         {
             if (child.tag == "vCams")
             {
                vCams.Add(child.gameObject);
             }
         }

    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            goNextCam();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            goBackCam();
        }
    }

    public void goNextCam() {
        vCams[vCamIndex].SetActive(false);
        if(vCamIndex < (vCams.Count - 1)){
            vCamIndex++;
        }
        vCams[vCamIndex].SetActive(true);
    }

    public void goBackCam() {
        vCams[vCamIndex].SetActive(false);
        if(vCamIndex > 0) {
            vCamIndex--;
        }
        vCams[vCamIndex].SetActive(true);
    }
}
