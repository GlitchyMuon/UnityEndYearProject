using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//says to DraggableItem that 
public class InventoryDropArea : MonoBehaviour, IDropHandler    //don't forget the IDropHandler on scripts using OnDrop! Didn't work because of that !
{
    // Reference to the InventorySlot prefab
    public GameObject inventorySlotPrefab;

    // Reference to the Grid Layout Group in the Content GameObject
    public GridLayoutGroup gridLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData){
        //can't put child.Count == 0 because Inventory has 2 children.
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.parentAfterDrag = transform;
        
        //if in invetoryDropArea : instantiate another slot for item back in inventory
        Destroy(dropped.gameObject);
        GameObject newSlot = Instantiate(inventorySlotPrefab, gridLayoutGroup.transform);
        // Access the script on the instantiated prefab
        InventorySlot slotScript = newSlot.GetComponent<InventorySlot>();
        slotScript.SetItemData(draggableItem.associatedItemSO); //setups the script on the instantiated prefab slot with the associatedItemSO
        
    }
}
