using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]   //will create an asset menu option from ItemSO inside the CreateAsset Menu
public class ItemSO : ScriptableObject
{
    [field : SerializeField]

    public bool IsStackable { get; set; }

    public int ID => GetInstanceID();   //will return a unique instance ID for each instanciated scirptable object item. So we can check and compare if we have an instance of "" object in our inventory by detecting if we have an object with this ID already in our inventory

    [field : SerializeField]
    public int MaxStackSize { get; set; } = 1;

    [field : SerializeField]
    public string Name { get; set; }

    /// <summary>
    /// Spefificies an item type. String type.
    /// </summary>
    /// <value>Herb, Flower, Gemstone or Creature</value>
    [field : SerializeField]
    public string ItemType { get; set; }

    /// <summary>
    /// Elemental type of the item
    /// </summary>
    /// <value>Moon, Sun, Time, Earth, Wind, Electricity, Fire or Water</value>
    [field : SerializeField]
    public string ElementalType { get; set; }
    
    [field : SerializeField]
    [field : TextArea]
    public string Description { get; set; }

    [field : SerializeField]
    public Sprite ItemImage { get; set; }
}
