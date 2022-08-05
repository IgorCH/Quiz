using System;
using System.Collections.Generic;

namespace Managers
{
    public class UserState
    {
        private List<int> _passedSteps = new List<int>();
        
        // Счет игрока
        public int Score { get; private set; }
        
        public event Action<int> OnScoreChange;

        public List<int> PassedSteps => _passedSteps;
        
        public UserState()
        {
            Score = 0;
            _passedSteps.Add(0);
        }

        public void PassQuestion(int index, bool isRight)
        {
            if (!_passedSteps.Contains(index))
            {
                _passedSteps.Add(index);
                
                if (isRight)
                {
                    Score++;
                }
                OnScoreChange?.Invoke(Score);
            }
        }
    }
}