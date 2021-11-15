using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton { get; private set; }
    private Vector2 mousePosition;
    public Vector2 MousePosition => mousePosition;
    private GridHandler gridHandler;
    public GridHandler GridHandler => gridHandler;
    
    
    private void Awake()
    {
        SetSingleton();

        gridHandler = FindObjectOfType<GridHandler>();
    }

    private void SetSingleton()
    {
        if (!singleton)
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
    }
    
    public void SetMousePosition(InputAction.CallbackContext context) => mousePosition = context.ReadValue<Vector2>();
    
    public Vector3 GetWorldPointMousePosition()
    {
        Vector3 mousePosition = new Vector3(this.mousePosition.x, this.mousePosition.y, 1f);
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
