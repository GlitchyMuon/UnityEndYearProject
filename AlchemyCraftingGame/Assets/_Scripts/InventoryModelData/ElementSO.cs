using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ElementSO : ScriptableObject
{
    [field : SerializeField]
    public string ElementalType { get; set; }
}
