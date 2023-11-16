using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateItemsInInventory : MonoBehaviour
{
    GridLayoutGroup gridLayoutGroup;    //if without usigng : UI.GridLayoutGroup

    // Reference to the Prefab or SO data. Drag a Prefab into this field in the Inspector.
    public ItemSO mySO;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(mySO);
        //mySO.transform.parent = transform.localPosition;
        //transform.SetParent(transform.root); ?
    }
}
//instantiate sans mettre de coordonnées
//ensuite je parente l'objet que je viens d'instancier à mon inventaire
//object.transform.parent = transform de l'inventaire
//donner une locale position
//Quaternion.identity
