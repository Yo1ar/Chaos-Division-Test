using ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;
using UI;

namespace Tiles
{
    [RequireComponent(typeof(MeshRenderer))]
    public class TilePointerComponent : EventTrigger
    {
        public Color defaultTileColor;
        public Color pointerEnterTileColor;
        [HideInInspector] public TileComponent tileComponent;
        private MeshRenderer _meshRenderer;
        
        
        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            tileComponent = GetComponent<TileComponent>();
            SetMeshRendererColor(defaultTileColor);
        }

        public override void OnPointerEnter(PointerEventData eventData) => SetMeshRendererColor(pointerEnterTileColor);
        public override void OnPointerExit (PointerEventData eventData) => SetMeshRendererColor(defaultTileColor);
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
                ShowPopUp();
        } 

        private void ShowPopUp()
        {
            GameObject popUp = Instantiate(tileComponent.gridHandler.popUpWindow, this.transform.position, Quaternion.identity);
            PopUpComponent popUpComponent = popUp.GetComponent<PopUpComponent>();

            SetPopUpText(popUpComponent);
        }
        private void SetPopUpText(PopUpComponent popUpComponent)
        {
            if (tileComponent.isEmpty)
                popUpComponent.popUpText.text = "Empty";
            else
            {
                BuildingSo buildingSo = tileComponent.gridHandler.FindBuildingSoOfType(tileComponent.buildingType);
                popUpComponent.popUpText.text = buildingSo.buildingDescription;
            }
        }
        
        private void SetMeshRendererColor(Color color) => _meshRenderer.material.color = color;
    }
}