using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//RecipeInstantiator
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
        // Find the GridLayoutGroup if it's not assigned in the Inspector
        if (gridLayoutGroup == null)
        {
            //! this is super wrong lol
            // it is going to fetch the first object of that type, it does work just by chance
            gridLayoutGroup = FindObjectOfType<GridLayoutGroup>();

            if (gridLayoutGroup == null)
            {
                Debug.LogError("GridLayoutGroup not found. Make sure it is assigned or present in the scene.");
                return;
            }
        }
        InstantiateRecipes();
    }

    void InstantiateRecipes()
    {
        foreach (RecipeSO recipe in recipes)
        {
            //Instantiate the RecipeScroll prefab as a new GameObject
            GameObject newScroll = Instantiate(recipePrefab, gridLayoutGroup.transform);

            //Access the script on the instantiated prefab
            RecipeUnit scrollScript = newScroll.GetComponent<RecipeUnit>();

            if (scrollScript != null)
            {
                //Assign the ScriptableObject data to the prefab script
                scrollScript.SetRecipeData(recipe); //link to associatedRecipeSO ?
            }
            else
            {
                Debug.LogError("RecipeUnit script not found on the instantiated prefab.");
            }
        }
        // Log the number of instantiated recipes
        Debug.Log($"Number of instantiated recipes: {gridLayoutGroup.transform.childCount}");
    }
}

//If I manually put the RecipeSO's into the Recipes list of the RecipeListLinkToSO script on the Textmeshpro Object of my RecipeScrollImage.prefab, in inspector, it fires an error : 
//UnassignedReferenceException: The variable recipePrefab of RecipeListLinkToSO has not been assigned.
// You probably need to assign the recipePrefab variable of the RecipeListLinkToSO script in the inspector.
// UnityEngine.Object.Instantiate (UnityEngine.Object original, UnityEngine.Transform parent, System.Boolean instantiateInWorldSpace) (at <30adf90198bc4c4b83910c6fb1877998>:0)
// UnityEngine.Object.Instantiate[T] (T original, UnityEngine.Transform parent, System.Boolean worldPositionStays) (at <30adf90198bc4c4b83910c6fb1877998>:0)
// UnityEngine.Object.Instantiate[T] (T original, UnityEngine.Transform parent) (at <30adf90198bc4c4b83910c6fb1877998>:0)
// RecipeListLinkToSO.InstantiateRecipes () (at Assets/_Scripts/RecipeListLinkToSO.cs:37)