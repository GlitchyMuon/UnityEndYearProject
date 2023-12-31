using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[RequireComponent(typeof(TMP_Text))]
public class RecipeUnit : MonoBehaviour
{
    // public Image recipeScrollImage; //Image component of the RecipeScroll prefab
    public Image recipePotionImage;   //new Image component for displaying the PotionImage

    // [HideInInspector]
    // public RecipeSO recipeSO; //Reference to the associated ScriptableObject
    public TextMeshProUGUI recipeNameTMP;  //wasn't TMP_Text !

    void Awake()
    {

    }
    void Start()
    {
        recipeNameTMP = GetComponentInChildren<TextMeshProUGUI>(); //or TMP_Text ?
        // if (recipeSO != null)
        // {
        //     // Set Recipe Name in TextMeshPro
        //     //recipeNameTMP.text = recipeSO.RecipeName;
        //     Debug.Log($"Recipe Name: {recipeSO?.RecipeName}"); // Check if recipeSO is not null
        //     recipeNameTMP.SetText($"{recipeSO?.RecipeName}");
        //     //recipeNameTMP.SetText($"{recipeSO.RecipeName}");
        // }   //this line if put here : instanciates correct number of recipes but no text change
    }

    // void Update(){
    //     //recipeNameTMP.SetText($"{recipeSO.RecipeName}");   //this line if put here : instanciates correct number of recipes but no text change. And shows an error message in console log : NullReferenceException : Object reference not set to an instance of an object RecipeUnit.Update() (at Assets/_Scripts/RecipeUnit.cs:23)
    // }
    public void SetRecipeData(RecipeSO recipe)
    {
        // //Retain the original sprite of the recipe scroll image
        // recipeScrollImage.sprite = GetComponent<Image>().sprite;

        //Assign the PotionImage to the new Image component
        recipePotionImage.sprite = recipe.PotionImage;

        // Set the associated ScriptableObject. Now RecipeListLinkToSO knows the associated ScriptableObject
        GetComponentInChildren<RecipeListLinkToSO>().associatedRecipeSO = recipe;

        //Update the TextMeshPro text
        // Following if check used, since making recipeNameTMP into public and assigning the TextMeshProUGUI on
        // the RecipeUnit script on the parent (RecipeScrollImage) of my prefab doesn't work, neither putting on the TextMeshPro child
        if (recipeNameTMP == null)
        {
            recipeNameTMP = GetComponentInChildren<TextMeshProUGUI>();
        }
        // Set Recipe Name in TextMeshPro
        recipeNameTMP.SetText($"{recipe.RecipeName}");

        //Set data in HoverTip
        GetComponentInChildren<HoverTip>().SetTooltipRecipeData(recipe);
    }

}
