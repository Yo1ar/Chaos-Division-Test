using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PupUp : MonoBehaviour
    {
        public Text popUpText;
        
        
        public void SetPopUpText(string text) => popUpText.text = text;
    }
}
