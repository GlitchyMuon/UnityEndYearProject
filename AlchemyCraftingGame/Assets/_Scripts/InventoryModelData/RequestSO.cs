using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Request Data", menuName = "ScriptableObjects/Request SO")]
public class RequestSO : ScriptableObject
{
    public int ID => GetInstanceID();   //will return a unique instance ID for each instanciated scirptable object request So we can check and compare if we have an instance of "" object on our requestboard by detecting if we have an object with this ID already on our requestboard

    [field: SerializeField]
    public string VillagerName { get; set; }

    [field: SerializeField]
    [field: TextArea(5, 30)]
    public string Description { get; set; }

    /// <summary>
    /// The correct recipe for the request
    /// </summary>
    /// <value>Drag&Drop correct RecipeSO</value>
    [field: SerializeField]
    public RecipeSO AssignedRecipe { get; set; }
}
