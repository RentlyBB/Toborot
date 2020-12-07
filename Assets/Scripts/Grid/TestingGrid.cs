using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RntCode.Runtime;
using RntCode.Utils;

public class TestingGrid : MonoBehaviour{

    private CustomGridScript<bool> editorGrid;

    [SerializeField] public List<GameObject> placeableObjects;

    private void Start() {
        editorGrid = new CustomGridScript<bool>(100,100,10, new Vector3(-500,-500), () => false, false);
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){   
            if(!editorGrid.getObjectOnCellPostion(InputUtils.getMouseWorldPosition(Input.mousePosition))) {
                editorGrid.setGridObjectValue(InputUtils.getMouseWorldPosition(Input.mousePosition), true);
                //Instatiate selectedPrefab
                GameObject i = Instantiate(placeableObjects[0]);
                i.transform.position = editorGrid.getCellCenterWorldPosition(InputUtils.getMouseWorldPosition(Input.mousePosition));
            }
        }
    }
}
