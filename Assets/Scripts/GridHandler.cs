using System.Collections.Generic;
using Buildings;
using ScriptableObjects;
using Tiles;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    public GridSettingsSo gridSettings;
    public GameObject popUpWindow;
    public List<BuildingSo> buildings;
    private TileComponent[,] _tiles;

    
    private void Start()
    {
        _tiles = new TileComponent[gridSettings.width, gridSettings.height];
        BuildGrid();
    }

    private void BuildGrid()
    {
        for (int i = 0; i < gridSettings.width; i++)
        {
            for (int j = 0; j < gridSettings.height; j++)
            {
                GameObject gridTile = InstantiateAndReturnGridTile(i, j);
                _tiles[i, j] = gridTile.GetComponent<TileComponent>();
                _tiles[i, j].InitTileCoords(i, j, this);
                
                _tiles[i,j].gameObject.name = $"tile {i},{j}";
            }
        }
    }

    private GameObject InstantiateAndReturnGridTile(float x, float z)
    {
        Vector3 instantiatePosition = new Vector3(x, 0, z);
        GameObject gridTIle = Instantiate(gridSettings.tilePrefab, instantiatePosition, Quaternion.identity, this.transform);

        return gridTIle;
    }
    
    public void InstantiateBuildingOfType(BuildingType buildingType, Vector3 position)
    {
        TileComponent tile = _tiles[(int) position.x, (int) position.z];
        if (!tile.isEmpty) return;
        
        BuildingSo buildingSO = FindBuildingSoOfType(buildingType);
        if (buildingSO == null) return;
        
        GameObject newBuilding =
            Instantiate(buildingSO.buildingPrefab, position, Quaternion.identity, this.transform);
            
        tile.isEmpty = false;
        tile.buildingType = buildingSO.buildingType;
    }
    
    public BuildingSo FindBuildingSoOfType(BuildingType buildingType)
    {
        BuildingSo building = null;

        foreach (BuildingSo buildingSo in buildings)
        {
            if (buildingSo == null)
            {
                Debug.LogError("There is no such building in GridHandler component");
                continue;
            }

            if (buildingType != buildingSo.buildingType) continue;
            
            building = buildingSo;
            break;
        }
        
        return building;
    }
}
