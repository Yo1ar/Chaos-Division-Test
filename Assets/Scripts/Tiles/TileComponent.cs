using Buildings;
using UnityEngine;

namespace Tiles
{
    public class TileComponent : MonoBehaviour
    {
        public bool isEmpty = true;
        public int xIndex;
        public int yIndex;
        [HideInInspector] public GridHandler gridHandler;
        [HideInInspector] public BuildingType buildingType;
        
        
        public void InitTileCoords(int x, int y, GridHandler grid)
        {
            xIndex = x;
            yIndex = y;
            gridHandler = grid;
        }
    }
}