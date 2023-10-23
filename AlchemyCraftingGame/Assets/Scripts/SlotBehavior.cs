using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotBehavior : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0) { //if statement prevents from stacking two different items and prevents from being stuck between gridslots
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
    }
}
