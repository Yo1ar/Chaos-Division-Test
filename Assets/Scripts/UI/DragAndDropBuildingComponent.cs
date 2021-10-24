using System;
using Buildings;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DragAndDrop
{
    public class DragAndDropBuildingComponent : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public BuildingType buildingType;
        private VerticalLayoutGroup _layoutGroup;
        private Text _textComponent;
        
        
        private void Start()
        {
            _layoutGroup = GetComponentInParent<VerticalLayoutGroup>();
            _textComponent = GetComponentInChildren<Text>();
            if (_textComponent != null) _textComponent.text = buildingType.ToString();

#if UNITY_EDITOR
            this.name = buildingType.ToString();
#endif
        }

        public void OnDrag(PointerEventData eventData) => this.transform.position = GameManager.singleton.GetWorldPointMousePosition();

        public void OnEndDrag(PointerEventData eventData)
        {
            RaycastHit raycastHit = Utils.PreformRaycast();

            if (raycastHit.transform == null || !raycastHit.transform.CompareTag(Utils.Tags.Tile))
            {
                RefreshLayoutGroup();
            }
            else
            {
                GameManager.singleton.GridHandler.InstantiateBuildingOfType(
                    buildingType: buildingType,
                    position: raycastHit.transform.position);
                
                RefreshLayoutGroup();
            }

        }

        private void RefreshLayoutGroup()
        {
            _layoutGroup.SetLayoutHorizontal();
            _layoutGroup.SetLayoutVertical();
        }
    }
}