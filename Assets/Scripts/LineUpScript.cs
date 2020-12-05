using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        lineUpPosition();
    }
    void lineUpPosition() {
        transform.position = new Vector3((float)Math.Ceiling(transform.position.x) - 0.5f, (float)Math.Ceiling(transform.position.y) - 0.5f, 0);
    }
}
