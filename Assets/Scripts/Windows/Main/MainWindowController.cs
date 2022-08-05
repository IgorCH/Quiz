using System.Collections.Generic;
using Windows.Question;
using BaseClasses;
using Managers;
using ResourceManager;
using Scripts.MVC;
using UIElements.QuestionIcon;

namespace Windows.Main
{
    public class MainWindowController : BaseWindowController<MainWindowView, MainWindowModel>
    {
        public override WindowTypes Type => WindowTypes.Window;
        public override string WindowName => WindowNames.Main;
        public override string Resource => ResourceNames.MainWindow;

        private IWindowManager _windowManager;
        private IDataSource _dataSource;
        private UserState _state;
        
        private List<QuestionIconController> _icons = new List<QuestionIconController>();
        
        public MainWindowController(IDataSource dataSource, UserState state, IWindowManager windowManager) : base()
        {
            _dataSource = dataSource;
            _state = state;
            _windowManager = windowManager;
        }
        
        public override void OnViewAdded()
        {
            foreach (var view in View.Icons)
            {
                QuestionIconController newIcon = new QuestionIconController(view);
                newIcon.OnSelect = OnSelectQuestion;
                _icons.Add(newIcon);
            }
        }

        public override void OnViewRemoved()
        {

        }

        public override void OnAfterModelChanged()
        {
            if (Model == null)
            {
                return;
            }
        }
        
        public override void Show()
        {
            base.Show();
            
            if (_state.UIProgress < _state.PassedSteps.Count)
            {
                // Есть не проанимированные шаги
                
            }
            else
            {
                // Все шаги мы уже видели, просто отображаем ситуацию
                
            }
        }

        public override void OnBeforeModelChanged()
        {
            // Do nothing
        }

        private void OnSelectQuestion(int index)
        {
            Managers.Question question = _dataSource.GetQuestion(index);
            QuestionWindowModel model = new QuestionWindowModel(question);
            _windowManager.Show(WindowNames.Question, model);
        }
    }
}