using UnityEngine;
using System.Collections;
using RntCode.Runtime;


namespace RntCode.Runtime {
    public class CustomLevelEditorScript {

        CustomGridScript<bool> editorGrid;
        public CustomLevelEditorScript(){
            editorGrid = new CustomGridScript<bool>(100, 100, 10, new Vector3(-500, -500), () => false, true);

        }


    }
}