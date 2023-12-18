using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum TooltipType
{
    Item,
    Recipe
}

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //Tooltip related variables
    public TooltipType tooltipType;
    public string tipToShow;
    private float timeToWait = 0.5f;

    //Recipe related variables
    // public Image recipeScrollImage; //Image component of the RecipeScroll prefab
    // public Image recipePotionImage;   //new Image component for displaying the PotionImage

    // public RecipeSO recipeSO; //Reference to the associated ScriptableObject

    // public ItemSO itemSO;

    // Reference to the associated ScriptableObject
    public ScriptableObject associatedSO;

    private bool isDragging = false;

    private void Awake()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //! this is better formatting than scoping
        // 1. It is clearer and cleaner
        // 2. it is a bit shorter to evaluate because it never looks after the scope at all
        if (isDragging) return;

        //StopCoroutine(StartTimer()); //check if better to put a boolean ?
        StopCoroutine(StartTimer());
        //StopAllCoroutines();
        StartCoroutine(StartTimer());
        //Debug.Log("Hovered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        // Debug.Log("Exited");
        //we wanna stop all couritines again, just in case we've hovered over it but not long enough to show the message
        StopCoroutine(StartTimer());
        //StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        StopCoroutine(StartTimer());
        //StopAllCoroutines();
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
        //HoverTipManager.OnMouseHover?.Invoke(tipToShow, Input.mousePosition);
        HoverTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private string GetTipToShow()
    {
        switch (tooltipType)
        {
            case TooltipType.Item:
                if (associatedSO is ItemSO itemSO)  //associatedSO is ItemSO itemSO
                //TryGetComponentInChildren(out ItemSO itemSO
                {
                    Debug.Log("Item tooltip");
                    string[] elementNames = Enum.GetNames(typeof(ElementalType));
                    string elementName = itemSO.ElementType.ToString();

                    string[] ingredientTypes = Enum.GetNames(typeof(ItemType));
                    string ingredientType = itemSO.IngredientType.ToString();

                    return $"<b>Item:</b> {itemSO.Name}\n<b>Type:</b> {ingredientType}\n<b>ElementType:</b>  {elementName}\n <b>Description:</b>  {itemSO.Description}";    //itemSO.ItemType
                }
                break;

            case TooltipType.Recipe:
                if (associatedSO is RecipeSO recipeSO)//associatedSO is RecipeSO recipeSO
                //TryGetComponentInChildren(out RecipeSO recipeSO)
                {
                    //SetRecipeData();
                    string[] elementNames = Enum.GetNames(typeof(ElementalType));
                    string elementName = recipeSO.ElementType.ToString();
                    // Explicitly specify the type of array elements
                    string ingredients = string.Join(", ", recipeSO.Ingredient.Select(ingredient => ingredient.Name));

                    return $"<b>Recipe:</b> {recipeSO.RecipeName}\n<b>Ingredients:</b> {ingredients}\n<b>ElementType:</b> {elementName}\n<b>Description:</b> {recipeSO.Description}";
                }
                break;
        }

        return "Invalid tooltip content";   //goes right to this statement. Need to  Debug.Log in cases
    }

    public void SetTooltipItemData(ItemSO item)
    {
        associatedSO = item;
    }

    public void SetTooltipRecipeData(RecipeSO recipe)
    {
        associatedSO = recipe;
    }

    // public void SetRecipeData(RecipeSO recipe)
    // {
    //     //Retain the original sprite of the recipe scroll image
    //     //recipeScrollImage.sprite = GetComponent<Image>().sprite;

    //     //Assign the PotionImage to the new Image component
    //     //recipePotionImage.sprite = recipe.PotionImage;

    //     // Set the associated ScriptableObject. Now RecipeListLinkToSO knows the associated ScriptableObject
    //     GetComponentInChildren<RecipeListLinkToSO>().associatedRecipeSO = recipe;
    // }


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