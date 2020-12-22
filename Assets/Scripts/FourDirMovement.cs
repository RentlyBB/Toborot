using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FourDirMovement : MonoBehaviour {
    public Vector3 nextPos;

    public LayerMask layerMask;

    public float movementSpeed = 20f;

    public bool isMoving = false;

    Vector2 tempDir = Vector2.zero;

    public GameObject tempObj;

    void Start() {
        nextPos = transform.position;
    }

    private void FixedUpdate() {
        castAndRenderRayCast();
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * movementSpeed);

        if(transform.position == nextPos){
            isMoving = false;
            moveHitted();
        } else { 
            isMoving = true;
        }
    }

    public void moveByInput(Vector2 moveDirection) {
          if(!isMoving) {
            float distance = calculateRayCastDistance(moveDirection);

            if(moveDirection.y > 0)
                nextPos += new Vector3(0, distance, 0);
            else if(moveDirection.y < 0)
                nextPos -= new Vector3(0, distance, 0);
            else if(moveDirection.x > 0)
                nextPos += new Vector3(distance, 0, 0);
            else if(moveDirection.x < 0)
                nextPos -= new Vector3(distance, 0, 0);
        }
    }

    public void moveHitted(){ 
        if(tempDir != Vector2.zero){
            tempObj.transform.GetComponent<FourDirMovement>().moveByInput(tempDir);
            tempObj = null;
            tempDir = Vector2.zero;
        }
    }

    float calculateRayCastDistance(Vector2 moveDirection) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + ((Vector3)moveDirection / 2), moveDirection, 500, ~layerMask);

        if(hit.transform.CompareTag("Player") || hit.transform.CompareTag("MoveableObject")){
            if(hit.transform.GetComponent<FourDirMovement>().isMoving){
                return 0;
            }
            tempDir = moveDirection;
            tempObj = hit.transform.gameObject;
        }

        return (float)Math.Round(hit.distance * 2, MidpointRounding.AwayFromZero) / 2;
    }

    void castAndRenderRayCast() {
        //Vykresleni raycastu
        Debug.DrawRay(transform.position + ((Vector3)Vector2.up / 2), new Vector3(0, calculateRayCastDistanceDebug(Vector2.up), 0), Color.yellow);
        Debug.DrawRay(transform.position + ((Vector3)Vector2.left / 2), new Vector3(-calculateRayCastDistanceDebug(Vector2.left), 0, 0), Color.yellow);
        Debug.DrawRay(transform.position + ((Vector3)Vector2.down / 2), new Vector3(0, -calculateRayCastDistanceDebug(Vector2.down), 0), Color.yellow);
        Debug.DrawRay(transform.position + ((Vector3)Vector2.right / 2), new Vector3(calculateRayCastDistanceDebug(Vector2.right), 0, 0), Color.yellow);
    }

    float calculateRayCastDistanceDebug(Vector2 moveDirection) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + ((Vector3)moveDirection / 2), moveDirection, 500, ~layerMask);
        return hit.distance;
    }
}
