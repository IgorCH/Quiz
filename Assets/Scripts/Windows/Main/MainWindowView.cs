using System.Collections.Generic;
using BaseClasses;
using UIElements.QuestionIcon;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.Main
{
    public class MainWindowView: BaseWindowView
    {
        [SerializeField] private List<QuestionIconView> _icons;
        
        public List<QuestionIconView> Icons => _icons;
    }
}