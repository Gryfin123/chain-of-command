using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CommandType
{
    OFFENSIVE,
    DEFENSIVE,
    SUPPORT
}
public enum BuffDurationType
{
    PERMANENT,  // Buffs that persist until the end of the run
    BATTLE,     // Buffs that persist until the end of battle
    EXECUTION   // Buffs that persist until the end of current chain execution
}
