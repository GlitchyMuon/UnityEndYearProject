using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotBehavior : MonoBehaviour, IDropHandler
{
    private MagicCircleSlotManager slotManager;
    private void Start()
    {
        // Find the SlotManager in the scene and assign it to the slotManager variable
        slotManager = FindObjectOfType<MagicCircleSlotManager>();
    }
    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0) { //if statement prevents from stacking two different items and prevents from being stuck between gridslots
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            // Notify the manager that an item has been added to the slot
            slotManager.AddItemToSlot(draggableItem);
        }
    }

    // Implement a method to be called when the item is removed from the slot
    public void OnItemRemoved()
    {
        // Notify the manager that an item has been removed from the slot
        slotManager.RemoveItemFromSlot(GetComponentInChildren<DraggableItem>());
    }
}
