using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData) {
        if (transform.parent.CompareTag("InventorySlotTag")) {  //check if parent of the item has an InventororySlotTag
            parentAfterDrag = transform.parent.parent;
            Transform transformParent = transform.parent;
            transform.SetParent(transform.root);
            Destroy(transformParent.gameObject);
            //if parent is slot then deparent and destroy slot parent
            //not following code because on canvas :
            //transform.parent = null; //but transform.SetParent(transform.root);
        }

        else {
            Debug.Log("Begin drag");
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root); //transform.root points to the canvas wherever we are in the hierarchy
            transform.SetAsLastSibling(); //to set at our very top of our view
            image.raycastTarget = false;
            }
        
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true; //interaction with the item will be possible again after the drag ends.
        //parent after drag should be InventoryDropArea which is InventoryGrid

        //if invetoryDropArea : instantiate another slot for item back in inventory
    }  
}
