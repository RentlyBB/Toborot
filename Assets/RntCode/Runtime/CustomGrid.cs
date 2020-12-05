using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RntCode.Utils;

namespace RntCode.Runtime{
    public class CustomGrid {

        private int height;
        private int width;
        private int[,] gridArray;
        private Vector3 originPosition;
        private float cellSize;
        private bool drawDebug;

        public CustomGrid(int width, int height, float cellSize, Vector3 originPositon, bool drawDebug = false, int fontSize = 30) {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.originPosition = originPositon;
            this.gridArray = new int[width, height];
            this.drawDebug = drawDebug;

            if(this.drawDebug)
                drawCustomGrid(fontSize);
        }


        private void drawCustomGrid(int fontSize) {
            for(int x = 0; x < gridArray.GetLength(0); x++) {
                for(int y = 0; y < gridArray.GetLength(1); y++) {
                    TextUtils.CreateWorldText(x + "," + y, null, getCellCenterWorldPosition(x, y), fontSize, null, TextAnchor.MiddleCenter);
                    Debug.DrawLine(getCellWorldPosition(x, y), getCellWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(getCellWorldPosition(x, y), getCellWorldPosition(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(getCellWorldPosition(0, height), getCellWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(getCellWorldPosition(width, 0), getCellWorldPosition(width, height), Color.white, 100f);
        }

        //Calculation of cell position in WorldSpace
        private Vector3 getCellWorldPosition(int x, int y) {
            return new Vector3(x, y) * cellSize + originPosition;
        }

        //Calculation of center of cell position in WorldSpace
        private Vector3 getCellCenterWorldPosition(int x, int y) {
            return new Vector3(x, y) * cellSize + originPosition + new Vector3(cellSize, cellSize) * 0.5f;
        }

        //Calculation of cell position in world space depands on Input
        //Vector3 worldPosition: Input -> MousePosition for example
        private void getCellXY(Vector3 worldPosition, out int x, out int y) {
            x = Mathf.FloorToInt(worldPosition.x / cellSize);
            y = Mathf.FloorToInt(worldPosition.y / cellSize);
        }
    }
}

