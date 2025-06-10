using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


// This class works like enum. 
// It is used to pass values to between CommandValues and CommandEffects in CommandSO.
[CreateAssetMenu(fileName = "EffectValue", menuName = "ScriptableObjects/CommandValue")]
public class CommandValueEnumSO : ScriptableObject
{
    public string valueName;
}
