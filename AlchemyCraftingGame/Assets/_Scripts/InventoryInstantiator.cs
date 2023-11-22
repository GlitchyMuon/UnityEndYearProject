using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//manages the item creation in slots
public class InventoryInstantiator : MonoBehaviour
{
    // Reference to the InventorySlot prefab
    public GameObject inventorySlotPrefab;

    // Reference to the Grid Layout Group in the Content GameObject
    public GridLayoutGroup gridLayoutGroup;

    // List of ScriptableObjects representing your items
    public List<ItemSO> items;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate items in the scene
        InstantiateItems();
    }

    void InstantiateItems()
    {
        foreach (ItemSO item in items)
        {
            // Instantiate the InventorySlot prefab as a new GameObject
            GameObject newSlot = Instantiate(inventorySlotPrefab, gridLayoutGroup.transform);

            // Access the script on the instantiated prefab
            InventorySlot slotScript = newSlot.GetComponent<InventorySlot>();

            // Check if the script is attached
            if (slotScript != null)
            {
                // Assign the ScriptableObject data to the prefab script
                slotScript.SetItemData(item);
            }
            else
            {
                Debug.LogError("InventorySlot script not found on the prefab.");
            }
        }
    }
}
