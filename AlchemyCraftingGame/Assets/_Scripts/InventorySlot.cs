using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotImage; //Image component of the InventorySlot prefab

    public Image itemImage;  // New Image component for displaying the ItemImage

    public ItemSO itemSO;    // Reference to the associated ScriptableObject

    public void SetItemData(ItemSO item)
    {
        // Retain the original sprite of the InventorySlot
        slotImage.sprite = GetComponent<Image>().sprite;
        
        // Assign the data from the ScriptableObject to the UI elements
        

        // Assign the itemSprite to the new Image component
        itemImage.sprite = item.ItemImage;

        // Set the associated ScriptableObject. Now DraggableItem knows the associated ScriptableObject
        GetComponentInChildren<DraggableItem>().associatedItemSO = item;

        // Here, I'm just logging the item name for demonstration purposes
        Debug.Log("Item Name: " + item.Name);
    }
}
