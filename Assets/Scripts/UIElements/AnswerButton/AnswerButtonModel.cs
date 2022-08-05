using BaseClasses;
using Managers;

namespace UIElements.AnswerButton
{
    public class AnswerButtonModel : BaseModel
    {
        public readonly Answer Answer;

        public AnswerButtonModel(Answer answer)
        {
            Answer = answer;
        }
    }
}
