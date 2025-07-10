using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that main goal is to pass a current state of the game to a class that
// requires that information (For example, CommandEffect that requires reference to influance it)
public class CommandContext
{
    public List<CommandDisplay> CurrentQueue;
    public CommandDisplay SourceCommand { get; set; } // Reference to Command that triggers the effect
}
