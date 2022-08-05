using System;
using Managers;
using ResourceManagement;
using Scripts.MVC;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class Installer: BaseZenjectInstaller
    {
        [SerializeField]
        protected RectTransform WindowsRoot;

        [SerializeField]
        protected RectTransform WidgetsRoot;

        public override void InstallBindings()
        {
            AppSettings.Instance = new AppSettings(WindowsRoot, WidgetsRoot);
            DiContainer.BindFromInstance(AppSettings.Instance);
            
            DiContainer.BindSingleDisposable<IDataSource, DataSource>();
            DiContainer.BindInterfacesAndSelfTo<UserState>().AsSingle().NonLazy();
            
            DiContainer.BindSingleDisposable<IResourceManager, ResourceManagement.ResourceManager>();
            DiContainer.BindSingleDisposable<IWindowManager, WindowManager>();
            
            Container.BindInitializableExecutionOrder<CoreInitialization>(100);
            Container.BindInterfacesTo<CoreInitialization>().AsSingle();
        }
    }

    public class CoreInitialization : IInitializable, IDisposable
    {
        [Inject]
        IWindowManager _windowManager;
        
        public void Dispose()
        {
            // do nothing
        }
        
        void IInitializable.Initialize()
        {
            _windowManager.Show(WindowNames.Main);
        }
    }
}