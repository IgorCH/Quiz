using UnityEngine;

namespace BaseClasses
{
    public abstract class BaseView: MonoBehaviour
    {
        [SerializeField] public Transform Transform;
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}