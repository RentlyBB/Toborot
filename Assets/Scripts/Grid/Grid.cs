using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RntCode.Runtime;

public class Grid : MonoBehaviour{

    private CustomGrid grid;

    private void Start() {
        grid = new CustomGrid(25,14,10, new Vector3(-125,-70), true);
    }

}
