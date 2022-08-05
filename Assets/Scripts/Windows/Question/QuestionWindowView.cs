using System.Collections.Generic;
using BaseClasses;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.Question
{
    public class QuestionWindowView: BaseWindowView
    {
        public Image Image;
        public TextMeshProUGUI Text;
        public List<AnswerButtonView> Buttons;
    }
}