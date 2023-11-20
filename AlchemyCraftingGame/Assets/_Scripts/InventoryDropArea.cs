using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDropArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData){
        if (transform.childCount == 0){ //if statement here prevents from stacking two different items and prevents from being stuck between gridslots. For now, we don't do stackable inventory items
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            //draggableItem.parentAfterDrag = transform;
        }
    }
}
