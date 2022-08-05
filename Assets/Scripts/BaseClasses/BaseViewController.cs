using System;
using UnityEngine;

namespace BaseClasses
{
    public abstract class BaseViewController<TView, TModel>: BaseController, IDisposable
        where TView: BaseView
        where TModel: BaseModel
    {
        private TView _view;
        private TModel _model;
        private GameObject _viewGO;
        public abstract string Resource { get; }

        public TView View => _view;
        public TModel Model => _model;
        
        protected GameObject Prefab;
        
        public BaseViewController()
        {
        }

        public void Init(GameObject prefab)
        {
            Prefab = prefab;
            _view = Prefab.GetComponent<TView>();
            OnViewAdded();
        }

        public BaseViewController(TView view)
        {
            _view = view;
            OnViewAdded();
        }
        
        public void SetModel(TModel model)
        {
            OnBeforeModelChanged();
            _model = model;
            OnAfterModelChanged();
        }
        
        public virtual void Show()
        {
            _view.Show();
        }
        
        public virtual void Hide()
        {
            _view.Hide();
        }

        public abstract void OnViewAdded();
        public abstract void OnViewRemoved();
        public abstract void OnAfterModelChanged();
        public abstract void OnBeforeModelChanged();

        public virtual void Dispose()
        {
            // TODO 
            // Remove View
            // Free Resources
            OnViewRemoved();
        }
    }
}