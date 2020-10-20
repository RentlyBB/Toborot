using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour{
    
    public float speed = 100f;

    public Vector3 pos;

    // Start is called before the first frame update
    void Start(){
        lineUpPosition();
        pos = transform.position;
    }

    private void FixedUpdate() {
        castAndRenderRayCast();
    }

    // Update is called once per frame
    void Update(){

        if(transform.position == pos){
            if(Input.GetKeyDown(KeyCode.W)) {
                pos += new Vector3(0, calculateRayCastDistance(Vector2.up), 0);
            } else if(Input.GetKeyDown(KeyCode.A)) {
                pos -= new Vector3(calculateRayCastDistance(Vector2.left), 0, 0);
            } else if(Input.GetKeyDown(KeyCode.S)) {
                pos -= new Vector3(0, calculateRayCastDistance(Vector2.down), 0);
            } else if(Input.GetKeyDown(KeyCode.D)) {
                pos += new Vector3(calculateRayCastDistance(Vector2.right), 0, 0);
            }
        }

     
      transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }

    //Vypocita vzdalenost od hrace k nejblizsimu stene v dannem smeru 
    float calculateRayCastDistance(Vector2 dir){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 500);
        return hit.distance - 0.5f;
    }


    void castAndRenderRayCast(){
        //Vykresleni raycastu
        Debug.DrawRay(transform.position, new Vector3(0, calculateRayCastDistance(Vector2.up), 0), Color.blue);
        Debug.DrawRay(transform.position, new Vector3(-calculateRayCastDistance(Vector2.left), 0, 0), Color.blue);
        Debug.DrawRay(transform.position, new Vector3(0, -calculateRayCastDistance(Vector2.down), 0), Color.blue);
        Debug.DrawRay(transform.position, new Vector3(calculateRayCastDistance(Vector2.right), 0, 0), Color.blue);
    }

    void lineUpPosition(){
        transform.position = new Vector3((float)Math.Ceiling(transform.position.x) - 0.5f, (float)Math.Ceiling(transform.position.y) - 0.5f, 0);
    }


}
