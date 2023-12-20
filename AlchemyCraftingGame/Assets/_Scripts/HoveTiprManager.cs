using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;

    public static Action<string, Vector2, bool> OnMouseHover; //string is the message we want to display and Vector2 being the position want to display it ie: the mouse position
                                                              //, bool
    public static Action OnMouseLoseFocus;  //to disable the tip focus
    // Start is called before the first frame update

    public TooltipType tooltipType;
    void Start()
    {
        HideTip();
    }

    private void OnEnable()
    {
        //whenever OnMouseHover is activated : I also want to subscribe my ShowTip method
        //OnMouseHover += ShowTip;    //CallShowTip
        HoverTipManager.OnMouseHover += CallShowTip;
        OnMouseLoseFocus += HideTip;
    }

    private void OnDisable()
    {
        //-= so we don't end up with any Null reference exceptions
        //OnMouseHover -= ShowTip;
        HoverTipManager.OnMouseHover -= CallShowTip;
        OnMouseLoseFocus -= HideTip;

    }

    private void ShowTip(string tip, Vector2 mousePosition, bool isRecipeList) //, bool isRecipeList
    {
        tipText.text = tip;
        //make backgroundbox scale dynamically to fit the text, no matter how wide or tall it is
        //interrogate our text, to see how long this message that we've passed in actually is. But also gonna take into consideration that 200pix max width. Use a ternary operator here
        //if my tipText preferredWidth is greather than 350 then set it the width to 350. If not, then use actual preferredWidth. Next parameter sets automatically to preferredHeight.
        //original tutorial method:
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 350 ? 350 : tipText.preferredWidth, tipText.preferredHeight);

        // Calculate the x position based on whether it's a recipe list or not
        float xOffset = isRecipeList ? -tipWindow.sizeDelta.x : tipWindow.sizeDelta.x;
        // Set the position
        tipWindow.transform.position = new Vector2(mousePosition.x + xOffset, mousePosition.y);

        // // Calculate the preferred size of the text
        // Vector2 preferredTextSize = new Vector2(tipText.preferredWidth + 20, tipText.preferredHeight + 20); // Add padding

        // // Set the position relative to the mouse position and canvas size
        // Vector2 adjustedPosition = mousePosition;
        // float xOffset = isRecipeList ? -preferredTextSize.x : preferredTextSize.x;
        // adjustedPosition.x += xOffset;

        // // Adjust the position to keep the tooltip within the screen boundaries
        // float screenWidth = Screen.width;
        // float screenHeight = Screen.height;
        // adjustedPosition.x = Mathf.Clamp(adjustedPosition.x, preferredTextSize.x / 2, screenWidth - preferredTextSize.x / 2);
        // adjustedPosition.y = Mathf.Clamp(adjustedPosition.y, preferredTextSize.y / 2, screenHeight - preferredTextSize.y / 2);

        // // Set the size of the tooltip background
        // tipWindow.sizeDelta = preferredTextSize;


        // // Set the position
        // tipWindow.transform.position = adjustedPosition;
        //tipWindow.transform.position = new Vector2(mousePosition.x + xOffset, mousePosition.y);

        tipWindow.gameObject.SetActive(true);

        //original method before adaption:
        //we want to position that tipbox over the top of our cursor, but we don't want it directly over the top, but slightly to the right of the cursor, so the cursor itself doens't actually cover any of the message.
        //tipWindow.transform.position = new Vector2(mousePosition.x + tipWindow.sizeDelta.x / 4, mousePosition.y);
    }

    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }

    private void CallShowTip(string tip, Vector2 mousePosition, bool isRecipeList)
    {
        ShowTip(tip, mousePosition, isRecipeList);
    }
}
