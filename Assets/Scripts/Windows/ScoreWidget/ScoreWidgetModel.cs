using System;
using BaseClasses;

namespace Windows.ScoreWidget
{ 
    public class ScoreWidgetModel: BaseWindowModel
    {
        public Action OnSuccess;
        public Action OnInterrupted;
        
        public ScoreWidgetModel()
        {

        }
    }
}