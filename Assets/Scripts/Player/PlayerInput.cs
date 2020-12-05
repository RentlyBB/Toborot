using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{

    FourDirMovement fdm;

    private void Awake() {
        fdm = GetComponent<FourDirMovement>();
    }

    private void Update() {
        movementInputs();
    }

    public void movementInputs(){

        if(Input.GetKey(KeyCode.W)){ 
            fdm.moveByInput(Vector2.up);
        } else if(Input.GetKey(KeyCode.S)){ 
            fdm.moveByInput(Vector2.down);
        } else if(Input.GetKey(KeyCode.D)){ 
            fdm.moveByInput(Vector2.right);
        } else if(Input.GetKey(KeyCode.A)){ 
            fdm.moveByInput(Vector2.left);
        }
    }
}
