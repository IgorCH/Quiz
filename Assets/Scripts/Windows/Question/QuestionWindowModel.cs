using System;
using BaseClasses;

namespace Windows.Question
{ 
    public class QuestionWindowModel: BaseWindowModel
    {
        public readonly Managers.Question Question;
        
        public QuestionWindowModel(Managers.Question question)
        {
            Question = question;
        }
    }
}