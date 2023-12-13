using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespace Inventory.Model
// {

public static class EnumExtensions
{
    public static string ToFriendlyString(this ItemSO.ElementalType element)
    {
        return ItemSO.ElementalType.GetName(element.GetType(), element);
    }
}
[CreateAssetMenu(fileName = "Ingredient Data", menuName = "ScriptableObjects/Item SO")]   //will create an asset menu option from ItemSO inside the CreateAsset Menu
public class ItemSO : ScriptableObject
{
    public enum ElementalType
    {
        Sun = 0,
        Fire = 1,
        Electricity = 2,
        Earth = 3,
        Moon = 4,
        Time = 5,
        Wind = 6
    }


    // [field : SerializeField]

    // public bool IsStackable { get; set; }

    public int ID => GetInstanceID();   //will return a unique instance ID for each instanciated scirptable object item. So we can check and compare if we have an instance of "" object in our inventory by detecting if we have an object with this ID already in our inventory

    // [field : SerializeField]
    // public int MaxStackSize { get; set; } = 1;

    [field: SerializeField]
    public string Name { get; set; }

    /// <summary>
    /// Spefificies an item type. String type.
    /// </summary>
    /// <value>Herb, Flower, Gemstone or Creature</value>
    [field: SerializeField]
    public string ItemType { get; set; }

    // /// <summary>
    // /// Elemental type of the item
    // /// </summary>
    // /// <value>Moon, Sun, Time, Earth, Wind, Electricity, Fire or Water</value>
    // [field : SerializeField]
    // public string ElementType { get; set; }

    /// <summary>
    /// Elemental type of the item
    /// </summary>
    /// <value>Moon, Sun, Time, Earth, Wind, Electricity, Fire or Water</value>
    [field: SerializeField]
    public ElementalType ElementType;

    [field: SerializeField]
    [field: TextArea]
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