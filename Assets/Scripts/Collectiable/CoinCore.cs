using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCore : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.name == "Player"){
            Destroy(transform.gameObject);
        }
    }
}
