using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Request Data", menuName = "ScriptableObjects/Request SO")]
public class RequestSO : ScriptableObject
{
    public int ID => GetInstanceID();

    [field: SerializeField]
    public string VillagerName { get; set; }

    [field: SerializeField]
    [field: TextArea]
    public string Description { get; set; }

    /// <summary>
    /// The correct recipe for the request
    /// </summary>
    /// <value>Drag&Drop correct RecipeSO</value>
    [field: SerializeField]
    public RecipeSO AssignedRecipe { get; set; }
}
