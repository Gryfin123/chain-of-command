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

/*public enum EffectTarget
{
    PLAYER,     // Target player (For example to heal)
    OPPONENT,   // Target opponent (For example to deal damage to)
    DUPLICATES, // All other commands of the same name (For example to increase damage of all other instances of triggering command)

}*/
