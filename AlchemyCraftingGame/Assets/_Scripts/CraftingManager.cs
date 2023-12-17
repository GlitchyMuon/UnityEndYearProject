using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    #region exposed fields
    [SerializeField] private List<ItemSO> _ingredients;
    [SerializeField] private List<RecipeSO> _recipes;
    [SerializeField] private List<RequestSO> _requests;

    [SerializeField] private GameObject _ingredientsPrefab;
    [SerializeField] private GameObject _recipesPrefab;
    [SerializeField] private GameObject _requestsPrefab;

    [SerializeField] private GridLayoutGroup _ingredientsParent; // expose?
    [SerializeField] private GridLayoutGroup _recipesParent;
    [SerializeField] private GridLayoutGroup _requestsParent;

    //.. remplir avec tous les parents de l’UI dans lesquels les prefabs seront instanciés
    #endregion

    void Awake()
    {
        
        // NOTE
        // this is finding the parent with the name, not the injection
        //_ingredientsParent = GameObject.Find("INSTANTIATED INVENTORY ITEMS").GetComponent<GridLayoutGroup>();
        // I tend to think reference injections are safer, on the top of being more optimized since we don’t have to access
        // many objects and / or iterate through the entire hierarchy

        // then we have to 
        
    }
}
