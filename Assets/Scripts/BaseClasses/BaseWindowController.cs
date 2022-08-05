using Managers;
using Scripts.MVC;
using UnityEngine;

namespace BaseClasses
{
    public abstract class BaseWindowController<TView, TModel>: BaseViewController<TView, TModel>, IWindow
        where TView: BaseWindowView
        where TModel: BaseWindowModel
    {
        public abstract WindowTypes Type { get; }
        public abstract string WindowName { get; }

        protected BaseWindowController() : base()
        {
        }

        void IWindow.SetModel(BaseWindowModel model)
        {
            SetModel(model as TModel);
        }
    }
}