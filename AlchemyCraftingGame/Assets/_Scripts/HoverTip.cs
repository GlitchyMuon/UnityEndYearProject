using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum TooltipType
    {
        Item,
        Recipe
    }
    public TooltipType tooltipType;
    public string tipToShow;
    private float timeToWait = 0.5f;

    // Reference to the associated ScriptableObject
    public ScriptableObject associatedSO;

    private bool isDragging = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isDragging)
        {
            //StopCoroutine(StartTimer()); //check if better to put a boolean ?
            StopAllCoroutines();
            StartCoroutine(StartTimer());
        }
        //Debug.Log("Hovered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

       // Debug.Log("Exited");
       //we wanna stop all couritines again, just in case we've hovered over it but not long enough to show the message
        StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Handle drag if needed
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        // Handle end of drag if needed
    }

    private void ShowMessage()
    {
        string tipToShow = GetTipToShow();
        HoverTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private string GetTipToShow()
    {
        switch (tooltipType)
        {
            case TooltipType.Item:
                if (associatedSO is ItemSO itemSO)
                {
                    return $"Item: {itemSO.Name}\nType: {itemSO.ItemType}\n Description: {itemSO.Description}";
                    //Element: {itemSO.ElementalType.ToFriendlyString()}\n
                    //doesn't work
                }
                break;

            case TooltipType.Recipe:
                if (associatedSO is RecipeSO recipeSO)
                {
                     // Explicitly specify the type of array elements
                string ingredients = string.Join(", ", recipeSO.Ingredient.Select(ingredient => ingredient.Name));
                return $"Recipe: {recipeSO.RecipeName}\nIngredients: {ingredients}\nDescription: {recipeSO.Description}";
                }
                break;
        }

        return "Invalid tooltip content";
    }

    // // Called when the user clicks on the UI element (can be used for item confirmation or recipe selection)
    // public void OnPointerClick()
    // {
    //     switch (tooltipType)
    //     {
    //         case TooltipType.Item:
    //             // Handle item click (e.g., confirm button)
    //             Debug.Log($"Item clicked: {tipToShow}");
    //             // You can access associatedSO (ItemSO) and perform actions accordingly
    //             break;

    //         case TooltipType.Recipe:
    //             // Handle recipe click (e.g., show confirm button)
    //             Debug.Log($"Recipe clicked: {tipToShow}");
    //             // You can access associatedSO (RecipeSO) and perform actions accordingly
    //             break;
    //     }
    // }

    //We don't want the tooltip box to appear the second we hover a UI element. We want to be sure that the user hover's about half a second before that message pops up or else it's just going to get really annoying
    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);
        ShowMessage();
    }
}

//In Inspector : uncheck Raycast Target in ToolTip Image/Panel and Text

//to replace string tipToShow, link to relevant SO : RecipeSO or ItemSO