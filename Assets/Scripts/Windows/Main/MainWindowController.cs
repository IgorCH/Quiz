using System.Collections.Generic;
using System.Linq;
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
        private List<int> _availableQuestions;
        
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
                QuestionIconModel model = new QuestionIconModel(_dataSource.GetQuestion(view.QuestionID));
                newIcon.SetModel(model);
                _icons.Add(newIcon);
            }
        }

        public override void OnViewRemoved()
        {

        }

        public override void OnAfterModelChanged()
        {

        }
        
        public override void Show()
        {
            base.Show();

            _availableQuestions = new List<int>();
            for (int j = 0; j < _dataSource.Questions.Count; j++)
            {
                if (_state.PassedSteps.Contains(_dataSource.Questions[j].prevId))
                {
                    _availableQuestions.Add(j);
                }
            }
            
            foreach (QuestionIconController icon in _icons)
            {
                if (_state.PassedSteps.Contains(icon.Model.Question.id))
                {
                    // Анимация пройденной иконки
                    icon.Fade();
                    icon.IsEnabled = false;
                } 
                else if (_availableQuestions.Contains(icon.Model.Question.id))
                {
                    // Анимация доступной иконки
                    icon.Highlight();
                    icon.IsEnabled = true;
                }
                else
                {
                    // Обычная иконка
                    icon.DefaultView();
                    icon.IsEnabled = false;
                }
            }
        }

        public override void OnBeforeModelChanged()
        {
            // Do nothing
        }

        private void OnSelectQuestion(int index)
        {
            if (_state.PassedSteps.Contains(index))
            {
                return;
            }

            Managers.Question question = _dataSource.GetQuestion(index);
            QuestionWindowModel model = new QuestionWindowModel(question);
            _windowManager.Show(WindowNames.Question, model);
        }
    }
}