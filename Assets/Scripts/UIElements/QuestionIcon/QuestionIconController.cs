using System;
using BaseClasses;
using ResourceManager;

namespace UIElements.QuestionIcon
{
    public class QuestionIconController : BaseViewController<QuestionIconView, QuestionIconModel>
    {
        public override string Resource => ResourceNames.QuestionIcon;

        public Action<int> OnSelect;

        public bool IsEnabled;
        
        public QuestionIconController(QuestionIconView view) : base(view)
        {
        }
    
        public override void OnViewAdded()
        {
            View.Trigger.onClick.AddListener(OnTrigger);
        }

        public override void OnViewRemoved()
        {
            View.Trigger.onClick.RemoveAllListeners();
        }

        public override void OnAfterModelChanged()
        {
            int categoryIndex = (int) Model.Question.category;
            View.Category.sprite = View.CategorySprites[categoryIndex];
        }

        public override void OnBeforeModelChanged()
        {
            // do nothing
        }

        public void Highlight()
        {
            View.Highlight();
        }

        public void Fade()
        {
            View.Fade();
        }

        public void DefaultView()
        {
            View.DefaultView();
        }

        private void OnTrigger()
        {
            if (!IsEnabled)
            {
                return;
            }

            OnSelect?.Invoke(View.QuestionID);
        }
    }
}
