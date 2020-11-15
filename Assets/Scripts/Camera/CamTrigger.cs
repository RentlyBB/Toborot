using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour {

    private CameraControll camControll;
    private bool canBeUsed = true;

    private void Start() {
        camControll = transform.GetComponentInParent<CameraControll>();
        if(transform.CompareTag("NextTrigger"))
            canBeUsed = true;
        else
            canBeUsed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.CompareTag("Player") && transform.CompareTag("NextTrigger")){
            if(canBeUsed){
                camControll.goNextCam();
                canBeUsed = false;
            } else{ 
                canBeUsed = true;
            }
        } else if (collision.transform.CompareTag("Player") && transform.CompareTag("BackTrigger")) {
            if(canBeUsed) {
                camControll.goBackCam();
                canBeUsed = false;
            } else {
                canBeUsed = true;
            }
        }
    }
}
