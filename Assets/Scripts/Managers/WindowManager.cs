using System.Collections.Generic;
using Windows.Main;
using Windows.Question;
using Windows.ScoreWidget;
using BaseClasses;
using Installer;
using ResourceManagement;
using Scripts.MVC;
using UnityEngine;

namespace Managers
{
    public enum WindowTypes
    {
        Window,
        Widget
    }

    public class WindowManager : IWindowManager
    {
        private RectTransform _windowsRoot;
        private RectTransform _widgetsRoot;
        private IWindow _currentWindow;
        
        private readonly List<IWindow> _windows = new List<IWindow>();
        private readonly List<IWindow> _widgets = new List<IWindow>();

        private IResourceManager _resourceManager;
        private IDataSource _dataSource;
        private UserState _state;
        
        public WindowManager(IResourceManager resourceManager, IDataSource dataSource, UserState state, AppSettings appSettings)
        {
            _windowsRoot = appSettings.WindowsRoot;
            _widgetsRoot = appSettings.WidgetsRoot;
            
            _resourceManager = resourceManager;
            _dataSource = dataSource;
            _state = state;
            
            Init();
        }
        
        private void Init()
        {
            MainWindowController mainWindowController = new MainWindowController(_dataSource, _state, this);
            mainWindowController.Init(_resourceManager.Instantiate(_windowsRoot, mainWindowController.Resource));
            mainWindowController.Hide();
            _windows.Add(mainWindowController);
                 
            QuestionWindowController questionWindowController = new QuestionWindowController(this, _resourceManager, _state);
            questionWindowController.Init(_resourceManager.Instantiate(_windowsRoot, questionWindowController.Resource));
            questionWindowController.Hide();
            _windows.Add(questionWindowController);
                 
             ScoreWidgetController scoreWidgetController = new ScoreWidgetController(_state);
             scoreWidgetController.Init(_resourceManager.Instantiate(_widgetsRoot, scoreWidgetController.Resource));
             _widgets.Add(scoreWidgetController);
        }
        
        public void Show(string windowName, BaseWindowModel model)
        {
            Debug.Log($"Try to show {windowName}");
            if (_currentWindow != null && _currentWindow.WindowName.Equals(windowName))
            {
                return;
            }
        
            foreach (IWindow window in _windows)
            {
                if (window.WindowName.Equals(windowName))
                {
                    _currentWindow?.Hide();
                    window.SetModel(model);
                    _currentWindow = window;
                    window.Show();
                    return;
                }
            }
            
            Debug.LogError($"Window {windowName} not found");
        }
        
        public void Dispose()
        {

        }
    }
}