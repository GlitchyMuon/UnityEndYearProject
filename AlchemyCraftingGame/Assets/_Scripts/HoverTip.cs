using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipToShow;
    private float timeToWait = 0.5f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //StopCoroutine(StartTimer()); //check if better to put a boolean ?
        StopAllCoroutines();
        StartCoroutine(StartTimer());
        //Debug.Log("Hovered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

       // Debug.Log("Exited");
       //we wanna stop all couritines again, just in case we've hovered over it but not long enough to show the message
        StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();
        
    }

    private void ShowMessage()
    {
        HoverTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    //We don't want the tooltip box to appear the second we hover a UI element. We want to be sure that the user hover's about half a second before that message pops up or else it's just going to get really annoying
    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);
        ShowMessage();
    }
}

//In Inspector : uncheck Raycast Target in ToolTip Image/Panel and Text

//to replace string tipToShow, link to relevant SO : RecipeSO or ItemSO