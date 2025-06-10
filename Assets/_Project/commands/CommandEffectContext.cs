using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that main goal is to pass a current state of the game to a class that
// requires that information (For example, CommandEffect that requires reference to influance ity)
public class CommandEffectContext
{
    public CommandController SourceCommand { get; set; } // Reference to Command that triggers the effect
    public RunDataSO RunData { get; set; } // Current playthrough information
    // public BattleController BattleData { get; set; } // Current battle information
}
