using System;
using BaseClasses;
using ResourceManager;

namespace UIElements.AnswerButton
{
    public class AnswerButtonController : BaseViewController<AnswerButtonView, AnswerButtonModel>
    {
        public override string Resource => ResourceNames.AnswerButton;
    
        public Action<bool> OnSelect;
        public AnswerButtonController(AnswerButtonView view) : base(view)
        {
        }
    
        public override void OnViewAdded()
        {
            View.Button.onClick.AddListener(OnTrigger);
        }

        public override void OnViewRemoved()
        {
            View.Button.onClick.RemoveAllListeners();
        }

        public override void OnAfterModelChanged()
        {
            View.Text.text = Model.Answer.text;
        }

        public override void OnBeforeModelChanged()
        {
            // do nothing
        }

        private void OnTrigger()
        {
            if (Model.Answer.isRight)
            {
                // Подсвечиваем кнопку
            }

            OnSelect?.Invoke(Model.Answer.isRight);
        }
    }
}
