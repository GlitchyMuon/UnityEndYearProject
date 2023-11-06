using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MagicCircleSlotManager : MonoBehaviour
{
    private List<SlotBehavior> slotBehaviors = new List<SlotBehavior>();
    private List<DraggableItem> itemsInSlots = new List<DraggableItem>(); // List to track items in the slots

    private void Start()
    {
        SlotBehavior[] slotScripts = FindObjectsOfType<SlotBehavior>();
        slotBehaviors.AddRange(slotScripts);    //Appends items to the end of array.
    }

    // Add an item to the list of items in slots
    public void AddItemToSlot(DraggableItem item)
    {
        itemsInSlots.Add(item);
    }

    // Remove an item from the list of items in slots
    public void RemoveItemFromSlot(DraggableItem item)
    {
        itemsInSlots.Remove(item);
    }

    // Example method to check if there are items in any of the slots
    public bool AreItemsInSlots()
    {
        return itemsInSlots.Count > 0;
    }
}
