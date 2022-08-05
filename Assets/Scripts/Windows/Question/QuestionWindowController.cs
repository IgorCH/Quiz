using System.Collections.Generic;
using BaseClasses;
using Managers;
using ResourceManagement;
using ResourceManager;
using Scripts.MVC;
using UIElements.AnswerButton;

namespace Windows.Question
{
    public class QuestionWindowController : BaseWindowController<QuestionWindowView, QuestionWindowModel>
    {
        public override WindowTypes Type => WindowTypes.Window;
        public override string WindowName => WindowNames.Question;
        public override string Resource => ResourceNames.QuestionWindow;

        private IWindowManager _windowManager;
        private IResourceManager _resourceManager;
        private UserState _state;
        
        private List<AnswerButtonController> _buttons = new List<AnswerButtonController>();
        
        public QuestionWindowController(IWindowManager windowManager, IResourceManager resourceManager, UserState state) : base()
        {
            _windowManager = windowManager;
            _resourceManager = resourceManager;
            _state = state;
        }
        
        public override void OnViewAdded()
        {
            foreach (var view in View.Buttons)
            {
                AnswerButtonController newButton = new AnswerButtonController(view);
                newButton.OnSelect = OnSelectAnswer;
                _buttons.Add(newButton);
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

            View.Image.sprite = _resourceManager.GetQuestionSprite(Model.Question.id);
            View.Text.text = Model.Question.title;
            
            int answerIndex = 0;
            foreach (var button in _buttons)
            {
                AnswerButtonModel model = new AnswerButtonModel(Model.Question.answers[answerIndex++]);
                button.SetModel(model);
            }
        }

        public override void OnBeforeModelChanged()
        {
            // Do nothing
        }

        private void OnSelectAnswer(bool isRight)
        { 
            _state.PassQuestion(Model.Question.id, isRight);

            // Начисляем звезды
            _windowManager.Show(WindowNames.Main);
                
        }

    }
}