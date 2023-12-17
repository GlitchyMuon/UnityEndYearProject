using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleSlotContentManager : MonoBehaviour
{
    // Reference to the dropped item
    public ItemSO droppedItem;

    RecipeSO activeRecipe;

    // Reference to the expected ElementalType for this slot
    public ElementalType expectedElementalType;    //need to point out the class where the enum is!
    // Start is called before the first frame update
    void Start()
    {
        DraggableItem[] ingredients = FindObjectsOfType<DraggableItem>();

        //RecipeSO assignedRecipe = currentRecipe != null ? currentRecipe.assignedRecipe : null;

    }

    void CheckElementalType()
    {
        // Compare the ElementalType of the dropped item with the expected ElementalType
        if (droppedItem.ElementType == expectedElementalType)
        {
            Debug.Log("ElementalType match!");
            // Perform additional actions for a match
        }
        else
        {
            Debug.Log("ElementalType mismatch!");
            // Perform actions for a mismatch
        }
    }
}
