using UnityEngine;

/// <summary>
/// Empty Scriptable object. To use it properly, create the instance of this, switch inspector 
/// tab to debug mode, and change source to scriptable object that you want to use.
/// </summary>

[CreateAssetMenu(fileName = nameof(DummyScriptableObject), menuName = "ScriptableObjects/" + nameof(DummyScriptableObject))]
class DummyScriptableObject : ScriptableObject
{
}