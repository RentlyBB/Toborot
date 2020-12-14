using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RntCode.Runtime;
using RntCode.Utils;

public class LevelCreator : MonoBehaviour{

    CustomGridScript<GameObject> girdOfObjects;

    // Start is called before the first frame update
    void Start(){
        girdOfObjects = new CustomGridScript<GameObject>(5, 5, 5, new Vector3(0,0), () => null);
        SaveSystem.Init();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.O)){
            DataToSave dataToSave = new DataToSave(transform.position);
            string stringToSave = JsonUtility.ToJson(dataToSave);
            Debug.Log(stringToSave);
            SaveSystem.save(stringToSave, "Ahoj");
        }

        if(Input.GetKeyDown(KeyCode.L)) {
            DataToSave loadedObject = JsonUtility.FromJson<DataToSave>(SaveSystem.load());
            Debug.Log("LOADED Specific position: " + loadedObject.position);
        }
    }

    public class DataToSave{
        public Vector2 position;
        public DataToSave(Vector2 position){
            this.position = position;
        }
    }
}
