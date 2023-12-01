using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeListLinkToSO : MonoBehaviour
{
    public GameObject recipePrefab;
    public GridLayoutGroup gridLayoutGroup;

    [HideInInspector]
    public RecipeSO associatedRecipeSO;

    public List<RecipeSO> recipes;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateRecipes();
    }

    void InstantiateRecipes()
    {
        foreach(RecipeSO recipe in recipes)
        {
            //Instantiate the RecipeScroll prefab as a new GameObject
            GameObject newScroll = Instantiate(recipePrefab, gridLayoutGroup.transform);

            //Access the script on the instantiated prefab
            RecipeUnit scrollScript = newScroll.GetComponent<RecipeUnit>();

            if (scrollScript != null)
            {
                //Assign the ScriptableObject data to the prefab script
                scrollScript.SetRecipeData(recipe);
            }
            else 
            {
                Debug.LogError("RecipeUnit script not found on the instantiated prefab.");
            }
        }
    }

}
