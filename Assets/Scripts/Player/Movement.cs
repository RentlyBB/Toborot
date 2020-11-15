using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Movement : MonoBehaviour{

    public float movementSpeed = 20f;

    public LayerMask layerMask;
    Vector3 nextPos;

    // Start is called before the first frame update
    void Start(){
        lineUpPosition();
    }

    private void FixedUpdate() {
        castAndRenderRayCast();
    }

    // Update is called once per frame
    void Update(){
        toEdgeMovemet();
    }

    void toEdgeMovemet(){
        if(transform.position == nextPos) {
            if(Input.GetKey(KeyCode.W)) 
                nextPos += new Vector3(0, calculateRayCastDistance(Vector2.up), 0);
             else if(Input.GetKey(KeyCode.S)) 
                nextPos -= new Vector3(0, calculateRayCastDistance(Vector2.down), 0);
             else if(Input.GetKey(KeyCode.A)) 
                nextPos -= new Vector3(calculateRayCastDistance(Vector2.left), 0, 0);
             else if(Input.GetKey(KeyCode.D)) 
                nextPos += new Vector3(calculateRayCastDistance(Vector2.right), 0, 0);
            
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * movementSpeed);
    }

    //Vypocita vzdalenost od hrace k nejblizsimu stene v dannem smeru 
    float calculateRayCastDistance(Vector2 dir){
        return Physics2D.Raycast(transform.position, dir, 500, ~layerMask).distance - 0.5f;
    }
  
    void lineUpPosition(){
        transform.position = new Vector3((float)Math.Ceiling(transform.position.x) - 0.5f, (float)Math.Ceiling(transform.position.y) - 0.5f, 0);
        nextPos = transform.position;
    }

    void castAndRenderRayCast() {
        //Vykresleni raycastu
        Debug.DrawRay(transform.position, new Vector3(0, calculateRayCastDistance(Vector2.up), 0), Color.blue);
        Debug.DrawRay(transform.position, new Vector3(-calculateRayCastDistance(Vector2.left), 0, 0), Color.blue);
        Debug.DrawRay(transform.position, new Vector3(0, -calculateRayCastDistance(Vector2.down), 0), Color.blue);
        Debug.DrawRay(transform.position, new Vector3(calculateRayCastDistance(Vector2.right), 0, 0), Color.blue);
    }
}

[CustomEditor(typeof(Movement))]
public class MovementEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
    }
}