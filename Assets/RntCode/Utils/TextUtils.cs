using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RntCode.Utils{
    public static class TextUtils {

        public const int sortingOrderDefault = 5000;

        // Create Text in the World
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="parent"></param>
        /// <param name="localPosition"></param>
        /// <param name="fontSize"></param>
        /// <param name="color"></param>
        /// <param name="textAnchor"></param>
        /// <param name="textAlignment"></param>
        /// <param name="sortingOrder"></param>
        /// <returns></returns>
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault) {
           
            GameObject gameObject = new GameObject("Text_" + text, typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = (color == null ? Color.white : (Color)color);
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="localPosition"></param>
        /// <param name="fontSize"></param>
        public static void CreateWorldTextInCanvas(string text, Vector3 localPosition = default(Vector3), int fontSize = 12) {

            GameObject rntUtilsCanvas = GameObject.FindGameObjectWithTag("RntCanvas");
            GameObject rntUtilsText;
            Canvas myCanvas;
            Text myText;
            RectTransform rectTransform;

            //Canvas
            if(rntUtilsCanvas == null){
                rntUtilsCanvas = new GameObject("RntUtilsCanvas");
                rntUtilsCanvas.tag = "RntCanvas";
                rntUtilsCanvas.AddComponent<Canvas>();

                myCanvas = rntUtilsCanvas.GetComponent<Canvas>();
                myCanvas.renderMode = RenderMode.WorldSpace;
                myCanvas.worldCamera = Camera.main;
                rntUtilsCanvas.AddComponent<CanvasScaler>();
                rntUtilsCanvas.AddComponent<GraphicRaycaster>();
            }

            // Text
            rntUtilsText = new GameObject("RntUtilsText");
            rntUtilsText.transform.parent = rntUtilsCanvas.transform;

            myText = rntUtilsText.AddComponent<Text>();
            myText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            myText.text = text;
            myText.fontSize = fontSize;
            myText.alignment = TextAnchor.MiddleCenter;

            // Text position
            rectTransform = myText.GetComponent<RectTransform>();
            localPosition.z = 0;
            rectTransform.localPosition = localPosition;
            rectTransform.localScale = new Vector3(0.02f, 0.02f);
        }

    }
}


