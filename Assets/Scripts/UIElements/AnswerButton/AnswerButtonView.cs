using System;
using BaseClasses;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonView : BaseView
{
    private readonly Color DEFAULT_COLOR = new Color(1, 1, 1);
    private readonly Color SUCCESS_COLOR = new Color(0, 1, 0);
    private readonly Color FAILED_COLOR = new Color(1, 0, 0);
    
    public TextMeshProUGUI Text;
    public Image BackgroundImage;
    public Button Button;

    public void SetDefaultBackgroundInstantly()
    {
        BackgroundImage.color = DEFAULT_COLOR;
    }

    public void SetSuccessBackground(Action callback)
    {
        Sequence animation = DOTween.Sequence();
        animation.Append(BackgroundImage.DOColor(SUCCESS_COLOR, 0.4f));
        animation.AppendInterval(1);
        animation.OnComplete(() =>
        {
            callback?.Invoke();
        });
    }
    
    public void SetFailedBackground(Action callback)
    {
        Sequence animation = DOTween.Sequence();
        animation.Append(BackgroundImage.DOColor(FAILED_COLOR, 0.4f));
        animation.AppendInterval(1);
        animation.OnComplete(() =>
        {
            callback?.Invoke();
        });
    }
}
