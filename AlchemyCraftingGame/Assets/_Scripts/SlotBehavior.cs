using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SlotBehavior : MonoBehaviour, IDropHandler
{
    public ElementalType elementalType;
    public bool isInCircle = false;
    private MagicCircleSlotManager slotManager;
    private void Start()
    {
        // Find the SlotManager in the scene and assign it to the slotManager variable
        if (isInCircle)
        {
            slotManager = FindObjectOfType<MagicCircleSlotManager>();
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        { //if statement prevents from stacking two different items and prevents from being stuck between gridslots
            GameObject dropped = eventData.pointerDrag; //we get the object from which the pointer is dragging and we assign it to the dropped variable
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            // Notify the manager that an item has been added to the slot
            slotManager?.AddItemToSlot(draggableItem); //if slotmManager not equal null
        }
    }

    // Implement a method to be called when the item is removed from the slot
    public void OnItemRemoved()
    {
        // Notify the manager that an item has been removed from the slot
        slotManager?.RemoveItemFromSlot(GetComponentInChildren<DraggableItem>());    //it searches from the component and will also check the child in hierarchy (item is child of slot)
    }
}
