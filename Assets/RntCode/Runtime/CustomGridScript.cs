using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using RntCode.Utils;

namespace RntCode.Runtime{
    public class CustomGridScript<TGridObject> {

        private int height;
        private int width;
        private TGridObject[,] gridArray;

        private Vector3 originPosition;
        
        private float cellSize;
        
        private bool drawDebug;

        public CustomGridScript(int width, int height, float cellSize, Vector3 originPosition, Func<TGridObject> createTGridObject, bool drawDebug = false, int fontSize = 30) {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.originPosition = originPosition;
            this.drawDebug = drawDebug;
            gridArray = new TGridObject[width, height];

            for(int x = 0; x < gridArray.GetLength(0); x++) {
                for(int y = 0; y < gridArray.GetLength(1); y++) {
                    gridArray[x, y] = createTGridObject();
                }
            }

            if(this.drawDebug)
                drawCustomGrid(fontSize);
        }

        //Draw grid lines and texts
        private void drawCustomGrid(int fontSize) {
            GameObject textParent = new GameObject("GridTexts");
            for(int x = 0; x < gridArray.GetLength(0); x++) {
                for(int y = 0; y < gridArray.GetLength(1); y++) {
                    TextUtils.CreateWorldText(gridArray[x,y].ToString(), textParent.transform, getCellCenterWorldPosition(x, y), fontSize, null, TextAnchor.MiddleCenter);
                    Debug.DrawLine(getCellWorldPosition(x, y), getCellWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(getCellWorldPosition(x, y), getCellWorldPosition(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(getCellWorldPosition(0, height), getCellWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(getCellWorldPosition(width, 0), getCellWorldPosition(width, height), Color.white, 100f);
        }

        //Calculation of cell position in WorldSpace
        public Vector3 getCellWorldPosition(int x, int y) {
            return new Vector3(x, y) * cellSize + originPosition;
        }

        //Calculation of center of cell position in WorldSpace
        public  Vector3 getCellCenterWorldPosition(int x, int y) {
            return new Vector3(x, y) * cellSize + originPosition + new Vector3(cellSize, cellSize) * 0.5f;
        }

        public Vector3 getCellCenterWorldPosition(Vector3 worldPosition) {
            int x, y;
            getCellXY(worldPosition - originPosition, out x, out y);
            return new Vector3(x, y) * cellSize + originPosition + new Vector3(cellSize, cellSize) * 0.5f;
        }

        //Return object on position x,y
        public TGridObject getObjectOnCellPostion(int x, int y) {
            return gridArray[x,y];
        }

        //Return object on position worldposition
        public TGridObject getObjectOnCellPostion(Vector3 worldPosition) {
            int x, y;
            getCellXY(worldPosition - originPosition, out x, out y);
            return gridArray[x, y];
        }

        //Calculation of cell position in world space depands on Input
        //Vector3 worldPosition: Input -> MousePosition for example
        public void getCellXY(Vector3 worldPosition, out int x, out int y) {
            x = Mathf.FloorToInt(worldPosition.x / cellSize);
            y = Mathf.FloorToInt(worldPosition.y / cellSize);
        }

        //Set value to cell on x,y
        public void setGridObjectValue(int x, int y, TGridObject value){
            gridArray[x, y] = value;
        }

        //Set value to cell on worldPosition;
        public void setGridObjectValue(Vector3 worldPosition, TGridObject value) {
            int x, y;
            getCellXY(worldPosition - originPosition, out x, out y);
            gridArray[x, y] = value;
        }
    }
}

