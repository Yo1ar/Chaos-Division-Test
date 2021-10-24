using Buildings;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Building", menuName = "Building", order = 0)]
    public class BuildingSo : ScriptableObject
    {
        public BuildingType buildingType;
        public GameObject buildingPrefab;
        public string buildingDescription;
        
        
        public static bool CompareBuildingTypes(BuildingType buildingType1, BuildingType buildingType2)
        {
            return buildingType1.Equals(buildingType2);
        }
    }
}