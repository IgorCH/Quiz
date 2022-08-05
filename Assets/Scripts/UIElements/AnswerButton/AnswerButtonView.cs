using System.Collections;
using System.Collections.Generic;
using BaseClasses;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonView : BaseView
{
    private readonly Color SUCCESS_COLOR = new Color(0, 1, 0);
    private readonly Color FAILED_COLOR = new Color(1, 0, 0);
    
    public TextMeshProUGUI Text;
    public Image BackgroundImage;
    public Button Button;

    public void SetSuccessBackground()
    {
        BackgroundImage.color = SUCCESS_COLOR;
    }
    
    public void SetFailedBackground()
    {
        BackgroundImage.color = FAILED_COLOR;
    }
}
