using System;
using BaseClasses;
using ResourceManager;

namespace UIElements.QuestionIcon
{
    public class QuestionIconController : BaseViewController<QuestionIconView, QuestionIconModel>
    {
        public override string Resource => ResourceNames.QuestionIcon;

        public Action<int> OnSelect;
    
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
            // do nothing
        }

        public override void OnBeforeModelChanged()
        {
            // do nothing
        }

        private void OnTrigger()
        {
            OnSelect?.Invoke(View.QuestionID);
        }
    }
}
