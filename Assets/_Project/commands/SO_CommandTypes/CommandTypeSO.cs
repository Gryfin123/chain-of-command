using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Command Type", menuName = "ScriptableObjects/Command Type")]
public class CommandTypeSO : ScriptableObject
{
    [SerializeField] public string commandTypeName;
    [SerializeField] public Color associatedColor;
}
