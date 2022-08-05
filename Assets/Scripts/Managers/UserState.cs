using System;
using System.Collections.Generic;

namespace Managers
{
    public class UserState
    {
        private List<int> _passedSteps = new List<int>();
        
        // Счет игрока
        public int Score { get; private set; }
        
        // Последний показвнный на UI progress, требуется для анимаций. 
        public int UIProgress { get; private set; }
        
        public event Action<int> OnScoreChange;

        public List<int> PassedSteps => _passedSteps;
        
        public UserState()
        {
            Score = 0;
            UIProgress = 0;
        }

        public void UpdateUIProgress()
        {
            UIProgress = _passedSteps.Count;
        }

        public void PassQuestion(int index)
        {
            if (!_passedSteps.Contains(index))
            {
                Score++;
                OnScoreChange?.Invoke(Score);
            }
        }
    }
}