using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseClickEvent : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onClickEvent;
    
    
    public void OnPointerClick(PointerEventData eventData) => onClickEvent?.Invoke();
    public void DestroyGO(GameObject gameObject) => Destroy(gameObject);
}