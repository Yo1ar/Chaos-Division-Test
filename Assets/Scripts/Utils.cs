using UnityEngine;

public static class Utils
{
    public static class Tags
    {
        public const string Tile = "Tile";
        public const string PopUp = "PopUp";
    }
    
    public static RaycastHit PreformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(GameManager.singleton.MousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit);
        return raycastHit;
    }
}