using System;
using System.Collections.Generic;
using BaseClasses;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements.QuestionIcon
{
    public class QuestionIconView : BaseView
    {
        private readonly float DEFAULT_ALPHA = 0.8f;
        private readonly float HIGHLIGHT_ALPHA = 1f;
        private readonly float FADE_ALPHA = 0.7f;
        
        public List<Sprite> CategorySprites;
        public Image Category;
        public int QuestionID;
        public Button Trigger;

        public void Highlight()
        {
            transform.DOScale(1.1f, 0.3f);
            Category.DOFade(HIGHLIGHT_ALPHA, 0.3f);
        }

        public void Fade()
        {
            transform.DOScale(0.9f, 0.3f);
            Category.DOFade(FADE_ALPHA, 0.3f);
        }
        
        public void DefaultView()
        {
            transform.DOScale(1f, 0.0f);
            Category.DOFade(DEFAULT_ALPHA, 0.0f);
        }
    }
}
