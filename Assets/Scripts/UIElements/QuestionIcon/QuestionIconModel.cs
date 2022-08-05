using BaseClasses;
using Managers;

namespace UIElements.QuestionIcon
{
    public class QuestionIconModel : BaseModel
    {
        public readonly Question Question;

        public QuestionIconModel(Question question)
        {
            Question = question;
        }
    }
}
