using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotBehavior : MonoBehaviour, IDropHandler
{
    public bool isInCircle = false;
    private MagicCircleSlotManager slotManager;
    private void Start()
    {
        // Find the SlotManager in the scene and assign it to the slotManager variable
        if (isInCircle){
            slotManager = FindObjectOfType<MagicCircleSlotManager>();
        }
    }
    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0) { //if statement prevents from stacking two different items and prevents from being stuck between gridslots
            GameObject dropped = eventData.pointerDrag; //on récupère l'objet dont le pointeur est en train de dragger, et on l'assigne à la variable dropped
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
        slotManager?.RemoveItemFromSlot(GetComponentInChildren<DraggableItem>());    //ça cherche ton composant Et va voir ses enfants dans sa hiérarchie (l'item est enfant du slot)
    }
}
