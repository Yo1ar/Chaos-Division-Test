using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GridSet", menuName = "GridSettings", order = 0)]
    public class GridSettingsSo : ScriptableObject
    {
        public int width;
        public int height;
        public GameObject tilePrefab;
    }
}