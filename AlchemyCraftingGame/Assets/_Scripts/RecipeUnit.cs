using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class RecipeUnit : MonoBehaviour
{
    public Image recipeScrollImage; //Image component of the RecipeScroll prefab
    public Image recipePotionImage;   //new Image component for displaying the PotionImage

    public RecipeSO recipeSO; //Reference to the associated ScriptableObject
    private TMP_Text recipeNameTMP;
    void Start()
    {
        recipeNameTMP = GetComponent<TMP_Text>();
        //Set Recipe Name in TextMeshPro
        recipeNameTMP.SetText("{recipeSO.RecipeName}");   //this line if put here : instanciates correct number of recipes but no text change
    }

    void Update(){
        //recipeNameTMP.SetText($"{recipeSO.RecipeName}");   //this line if put here : instanciates correct number of recipes but no text change. And shows an error message in console log : NullReferenceException : Object reference not set to an instance of an object RecipeUnit.Update() (at Assets/_Scripts/RecipeUnit.cs:23)
    }
    public void SetRecipeData(RecipeSO recipe)
    {
        //Retain the original sprite of the recipe scroll image
        recipeScrollImage.sprite = GetComponent<Image>().sprite;

        //Assign the PotionImage to the new Image component
        recipePotionImage.sprite = recipe.PotionImage;

        // Set the associated ScriptableObject. Now RecipeListLinkToSO knows the associated ScriptableObject
        GetComponentInChildren<RecipeListLinkToSO>().associatedRecipeSO = recipe;

        //recipeName.SetText($"{recipeSO.RecipeName}");   //this line if put here : instanciates Wrong number of recipes (onmy 1) And no text change either
    }
}
