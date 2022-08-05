using BaseClasses;
using Managers;
using ResourceManager;
using Scripts.MVC;
using UnityEngine;

namespace Windows.PointsWidget
{
    public class PointsWidgetController : BaseWindowController<PointsWidgetView, PointsWidgetModel>
    {
        public override WindowTypes Type => WindowTypes.Widget;
        public override string WindowName => WidgetNames.Points;
        public override string Resource => ResourceNames.PointsWidgetResource;

        private UserState _state;
        public PointsWidgetController(UserState state) : base()
        {
            _state = state;
            _state.OnScoreChange += OnScoreChanged;
        }
        
        public override void OnViewAdded()
        {
            View.Score.text = $"{_state.Score}";
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
        }

        public override void OnBeforeModelChanged()
        {
            // Do nothing
        }

        private void OnScoreChanged(int score)
        {
            if (View != null)
            {
                View.Score.text = $"{score}";
            }
        }

    }
}