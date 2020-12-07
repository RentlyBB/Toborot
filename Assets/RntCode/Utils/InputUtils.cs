using UnityEngine;
using System.Collections;

namespace RntCode.Utils {
    public static class InputUtils {

        //Return mouse position relative in world space
        public static Vector3 getMouseWorldPosition(Vector3 mousePosition){
            Vector3 mousePos = mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }

    }
}