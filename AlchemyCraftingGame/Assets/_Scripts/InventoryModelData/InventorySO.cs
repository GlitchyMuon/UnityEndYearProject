using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// namespace Inventory.Model
// {
//     [CreateAssetMenu(fileName = "Inventory Data", menuName = "ScriptableObjects/Inventory SO")]
//     public class InventorySO : ScriptableObject
//     {
//         public event Action<Dictionary<int, InventoryItem>>OnInventoryUpdated;

//         [SerializeField]
//         private List<InventoryItem> inventoryItems;

//         [field: SerializeField]
//         public int Size {get; private set;} = 10;

//         public void Initialize()
//         {
//             inventoryItems = new List<InventoryItem>();
//             for (int i = 0; i < Size; i++)
//             {
//                 inventoryItems.Add(InventoryItem.GetEmptyItem());
//             }
//         }

//         public int AddItem(ItemSO item, int quantity, List<ItemParameter> itemState = null)
//         {
//             if (item.IsStackable == false)
//             {
//                 for (int i = 0; i < inventoryItems.Count; i++)
//                 {
//                     while(quantity > 0 && IsInventoryFull() == false)
//                     {
//                         quantity -= AddItemToFirstFreeSlot(itemState, 1, itemState);
//                     }
//                     InformAboutChange();
//                     return quantity;
//                 }
//             }
//             quantity = AddStackableItem(item, quantity);
//             InformAboutChange();
//             return quantity;
//         }

//         private int AddItemToFirstFreeSlot(ItemSO item, int quantity, List<ItemParameter> itemState = null)
//         {
//             InventoryItem newItem = new InventoryItem 
//             {
//             item = item,
//             quantity = quantity,
//             itemState = new List<ItemParameter>(itemState == null ? item.DefaultParametersList : itemState)
//             };

//             for (int i = 0; i < inventoryItems.Count; i++)
//             {
//                 if (inventoryItems[i].IsEmpty)
//                 {
//                     inventoryItems[i] = newItem;
//                     return quantity;
//                 }
//             }
//             return 0;
//         }

//         private bool IsInventoryFull()
//         => inventoryItems.Where(item => item.IsEmpty).Any() == false;

//         private int AddStackableItem(ItemSO item)
//         {
//             AddItem(item.item, item.quantity);
//         }

//         public Dictionary<int, InventoryItem> GetCurrentInvetoryState()
//         {
//             Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();

//             for (int i = 0; i < inventoryItems.Count; i++)
//             {
//                 if (inventoryItems[i].IsEmpty) continue;
//                 returnValue[i] = inventoryItems[i];
//             }
//             return returnValue;
//         }

//         public InventoryItem GetItemAt(int itemIndex)
//         {
//             return inventoryItems[itemIndex];
//         }

//         public void SwapItems(int itemIndex_1, int itemIndex_2)
//         {
//             InventoryItem item1 = inventoryItems[itemIndex_1];
//             inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
//             inventoryItems[itemIndex_2] = item1;
//             InformAboutChange();
//         }

//         private void InformAboutChange()
//         {
//             OnInventoryUpdated?.Invoke(GetCurrentInvetoryState());
//         } 
//     }

//     [Serializable]
//     public struct InventoryItem
//     {
//         public int quantity;
//         public ItemSO item;
//         public List<ItemParameter> itemState;
//         public bool IsEmpty => item == null;

//         public InventoryItem ChangeQuantity(int newQuantity)
//         {
//             return new InventoryItem
//             {
//                 item = this.item,
//                 quantity = newQuantity,
//                 itemState = new List<ItemParameter>(this.itemState)
//             };
//         }

//         public static InventoryItem GetEmptyItem() => new InventoryItem
//         {
//             item = null,
//             quantity = 0,
//             itemState = new List<ItemParameter>()
//         };
//     }
// }