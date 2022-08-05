using BaseClasses;
using Managers;
using ResourceManager;
using Scripts.MVC;

namespace Windows.ScoreWidget
{
    public class ScoreWidgetController : BaseWindowController<ScoreWidgetView, ScoreWidgetModel>
    {
        public override WindowTypes Type => WindowTypes.Widget;
        public override string WindowName => WidgetNames.Points;
        public override string Resource => ResourceNames.ScoreWidgetResource;

        private UserState _state;
        public ScoreWidgetController(UserState state) : base()
        {
            _state = state;
            _state.OnScoreChange += OnScoreChanged;
        }
        
        public override void OnViewAdded()
        {
            View.Text.text = $"{_state.Score}";
        }

        public override void OnViewRemoved()
        {
            // Do nothing
        }

        public override void OnAfterModelChanged()
        {
            // Do nothing
        }

        public override void OnBeforeModelChanged()
        {
            // Do nothing
        }

        private void OnScoreChanged(int score)
        {
            if (View != null)
            {
                View.Text.text = $"{score}";
            }
        }

    }
}