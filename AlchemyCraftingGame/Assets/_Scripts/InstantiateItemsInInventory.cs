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
        transform.SetParent(transform.root);
        transform.SetAsLastSibling(); //to set at our very top of our view
    }
}
//instantiate sans mettre de coordonnées
//ensuite je parente l'objet que je viens d'instancier à mon inventaire
//object.transform.parent = transform de l'inventaire
//donner une locale position

//Quaternion.identity

//1ère méthode : Créer un prefab(gameObject) qui représente mon objet, et dans lequel je dois juste changer l'image pour changer l'ingrédient. Le préfab doit contenir un lien vers le SO. Une fois créer le préfab : on l'instancie dans mon code et je lui assigne la bonne image et le lien vers le bon scriptableobject.
        //Inconvénient : écrire deux trois lignes de code en plus.
//2ème méthode : Je crée un prefab par ingrédient (qui contient le lien vers le sprite et le lien vers le bon SO). Je fais toutes les assignations déjà dans Unity. Après j'instancie le bon prefab. L'inconvénient : à chaque fois que j'ai un nouvel ingrédient : je dois créer un nouveau prefab.
//3) Méthode de Thomas se fait après un des deux méthodes expliquées de Bastien pour instancier les prefabs.
