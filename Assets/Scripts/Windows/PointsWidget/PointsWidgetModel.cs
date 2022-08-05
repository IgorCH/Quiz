using System;
using BaseClasses;

namespace Windows.PointsWidget
{ 
    public class PointsWidgetModel: BaseWindowModel
    {
        public Action OnSuccess;
        public Action OnInterrupted;
        
        public PointsWidgetModel()
        {

        }
    }
}