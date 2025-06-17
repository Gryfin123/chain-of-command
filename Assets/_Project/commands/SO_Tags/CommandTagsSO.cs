using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tag", menuName = "ScriptableObjects/Tags")]
public class CommandTagsSO : ScriptableObject
{
    [SerializeField]
    private string tagName;
    public string TagName { get => tagName; private set => tagName = value; }
}
