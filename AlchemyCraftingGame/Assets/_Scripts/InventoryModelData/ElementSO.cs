using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element Data", menuName = "ScriptableObjects/Element SO")]
public class ElementSO : ScriptableObject
{
    [field : SerializeField]
    public string ElementalType { get; set; }
}
