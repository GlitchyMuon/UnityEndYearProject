using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public enum ElementalType
    {
        Sun = 0,
        Fire = 1,
        Electricity = 2,
        Earth = 3,
        Moon = 4,
        Water = 5,
        Time = 6,
        Wind = 7
    }

    public enum ItemType 
    {
        Creatures,
        CrystalAndGemstones,
        Flowers,
        HerbsAndRoots,
    }
[CreateAssetMenu(fileName = "Ingredient Data", menuName = "ScriptableObjects/Item SO")]   //will create an asset menu option from ItemSO inside the CreateAsset Menu
public class ItemSO : ScriptableObject
{

    // [field : SerializeField]

    // public bool IsStackable { get; set; }

    public int ID => GetInstanceID();   //will return a unique instance ID for each instanciated scirptable object item. So we can check and compare if we have an instance of "" object in our inventory by detecting if we have an object with this ID already in our inventory

    // [field : SerializeField]
    // public int MaxStackSize { get; set; } = 1;

    [field: SerializeField]
    public string Name { get; set; }

    /// <summary>
    /// Spefificies an item type. Enum type.
    /// </summary>
    /// <value>Creature, Crystal or Gemstone, Flower, Herb or Root</value>
    [field: SerializeField]
    public ItemType IngredientType;

    // /// <summary>
    // /// Elemental type of the item. String type.
    // /// </summary>
    // /// <value>Moon, Sun, Time, Earth, Wind, Electricity, Fire or Water</value>
    // [field : SerializeField]
    // public string ElementType { get; set; }

    /// <summary>
    /// Elemental type of the item. Enum type.
    /// </summary>
    /// <value>Moon, Sun, Time, Earth, Wind, Electricity, Fire or Water</value>
    [field: SerializeField]
    public ElementalType ElementType;

    [field: SerializeField]
    [field: TextArea(5, 10)]
    public string Description { get; set; }

    [field: SerializeField]
    public Sprite ItemImage { get; set; }

    // [field : SerializeField]
    // public List<ItemParameter> DefaultParameters { get; set; }

}



// [Serializable]
// public struct ItemParameter : IEquatable<ItemParameter>
// {
//     public ItemParameterSO itemParameter;
//     public float value;

//     public bool Equals(ItemParameter other)
//     {
//         return other.itemParameter == itemParameter;
//     }
// }
// }