using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    // Reference to the associated ScriptableObject
    [HideInInspector] public ItemSO associatedItemSO;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.parent.CompareTag("InventorySlotTag"))
        {  //check if parent of the item has an InventororySlotTag
            parentAfterDrag = transform.parent.parent;  //prarent.parent = great parent xD
            Transform transformParent = transform.parent;
            transform.SetParent(transform.root);
            Destroy(transformParent.gameObject);
            //if parent is slot then deparent and destroy slot parent
            //not the following code because on canvas :
            //transform.parent = null; //but transform.SetParent(transform.root);
            image.raycastTarget = false;    //we want to detect the dropArea, so we want to ignore raycast that detects the item image ! Without this line, the first drop in area will not spawn an inventory slot !
        }

        else
        {  //code applies on magic circle drag&drop
            Debug.Log("Begin drag");
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root); //transform.root points to the canvas wherever we are in the hierarchy
            transform.SetAsLastSibling(); //to set at our very top of our view
            image.raycastTarget = false;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true; //interaction with the item will be possible again after the drag ends.
        //parent after drag should be InventoryDropArea which is InventoryGrid. Code in InventoryDropArea.cs
    }
}

//If I release the drag on any other part of the InventoryDropArea and Slot, the Ingredient returns to the inventory but doesn't spawn a slot. Need to fix this with following code :
// Destroy(dropped.gameObject);
// GameObject newSlot = Instantiate(inventorySlotPrefab, gridLayoutGroup.transform);
// // Access the script on the instantiated prefab
// InventorySlot slotScript = newSlot.GetComponent<InventorySlot>();
// slotScript.SetItemData(draggableItem.associatedItemSO); //setups the script on the instantiated prefab slot with the associatedItemSO
