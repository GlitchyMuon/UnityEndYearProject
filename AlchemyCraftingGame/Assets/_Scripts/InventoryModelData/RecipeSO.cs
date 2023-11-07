using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RecipeSO : ScriptableObject
{
    [field : SerializeField]
    public string Name {get;set;}

    public int ID => GetInstanceID(); 

    [field : SerializeField]
    /// <summary>
    /// First ingredient of the recipe
    /// </summary>
    /// <value>Type SciptableObject ItemSO</value>
    public ItemSO FirstIngredient {get;set;}

    [field : SerializeField]
    /// <summary>
    /// Second ingredient of the recipe
    /// </summary>
    /// <value>Type SciptableObject ItemSO</value>
    public ItemSO SecondIngredient {get;set;}

    [field : SerializeField]
    /// <summary>
    /// Third ingredient of the recipe
    /// </summary>
    /// <value>Type SciptableObject ItemSO</value>
    public ItemSO ThirdIngredient {get;set;}

    [field : SerializeField]
    [field : TextArea]
    /// <summary>
    /// Description of recipe
    /// </summary>
    /// <value>String of text</value>
    public string Description { get; set; }

    [field : SerializeField]
    public Sprite PotionImage {get; set;}
}
