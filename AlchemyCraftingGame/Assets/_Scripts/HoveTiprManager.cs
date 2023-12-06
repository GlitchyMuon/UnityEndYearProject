using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;

    public static Action<string, Vector2> OnMouseHover; //string is the mesage we want to display and Vector2 being the position want to display it ie: the mouse position
    public static Action OnMouseLoseFocus;  //to disable the tip focus
    // Start is called before the first frame update
    void Start()
    {
        HideTip();
    }

    private void OnEnable()
    {
        //whenever OnMouseHover is activated : I also want to subscribe my ShowTip method
        OnMouseHover += ShowTip;
        OnMouseLoseFocus += HideTip;     
    }

    private void OnDisable()
    {
        //-= so we don't end up with any Null reference exceptions
        OnMouseHover -= ShowTip;
        OnMouseLoseFocus -= HideTip; 

    }

    private void ShowTip(string tip, Vector2 mousePosition)
    {
        tipText.text = tip;
        //make backgroundbox scale dynamically to fit the text, no matter how wide or tall it is
        //interrogate our text, to see how long this message that we've passed in actually is. But also gonna take into consideration that 200pix max width. Use a ternary operator here
        //if my tipText preferredWidth is greather than 200 then set it the width to 200. If not, then use actual preferredWidth. Next parameter sets automatically to preferredHeight.
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 200 ? 200 : tipText.preferredWidth, tipText.preferredHeight);

        tipWindow.gameObject.SetActive(true);

        //we want to position that tipbox over the top of our cursor, but we don't want it directly over the top, but slightly to the right of the cursor, so the cursor itself doens't actually cover any of the message.
        tipWindow.transform.position = new Vector2(mousePosition.x + tipWindow.sizeDelta.x / 2, mousePosition.y);


    }

    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }

}
