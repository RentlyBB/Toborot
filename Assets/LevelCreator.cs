using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RntCode.Runtime;
using RntCode.Utils;

public class LevelCreator : MonoBehaviour{

    public enum TileMap{
        none = 0,
        grass = 1,
        dirt = 2,
    }

    CustomGridScript<TileMap> girdOfObjects;
    public TileMap selectedTile;

    // Start is called before the first frame update
    private void Start(){
        girdOfObjects = new CustomGridScript<TileMap>(30, 17, 0.64f, Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)), () => TileMap.none, true, 5);
    }
    public void selectCustomTile(int tileMap){

        switch(tileMap){
            case 0:
                selectedTile = TileMap.none;
                break;
            case 1:
                selectedTile = TileMap.grass;
                break;
            case 2:
                selectedTile = TileMap.dirt;
                break;
        }
    }
}
