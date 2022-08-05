using UnityEngine;
using UnityEngine.Serialization;

namespace BaseClasses
{
    public class BaseWindowView: BaseView
    {
        [FormerlySerializedAs("_canvasGroup")] 
        [SerializeField] protected CanvasGroup CanvasGroup;
        
        public override void Show()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
        }
        
        public override void Hide()
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }
    }
}