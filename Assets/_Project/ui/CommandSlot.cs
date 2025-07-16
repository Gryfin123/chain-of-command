using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CommandSlot : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// Called when a command is moved into the slot (not created)
    /// It's called after the command is moved in.
    /// </summary>
    public UnityEvent<CommandDisplay> onCommandMovedIn;
    /// <summary>
    /// Called when command is dragged out of the slot and moved into other slot (not removed)
    /// It's called before the command is moved out.
    /// </summary>
    public UnityEvent<CommandDisplay> onCommandMovedOut;



    public void OnDrop(PointerEventData eventData)
    {
        if (GetCurrentCommand() == null)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableCommand draggableItem = dropped.GetComponent<DraggableCommand>();
            draggableItem.parentAfterDrag = transform;
        }
    }

    /// <summary>
    /// Comamnd called by other classes when then take a command from this slot, and move it into other one. 
    /// </summary>
    public void CommandMovedOut(CommandDisplay movedCommand)
    {
        onCommandMovedOut.Invoke(movedCommand);
    }

    /// <summary>
    /// Comamnd called by other classes when then take a command has been moved out of different slot and into this one. 
    /// </summary>
    public void CommandMovedIn(CommandDisplay movedCommand)
    {
        onCommandMovedIn.Invoke(movedCommand);
    }

    /// <summary>
    /// Returns a DisplayCommand that is currently stored in the CommandSlot. If Command is not present, returns null.
    /// </summary>
    /// <returns>DisplayCommand or null</returns>
    public CommandDisplay GetCurrentCommand()
    {
        if (transform.childCount > 0)
        {
            return transform.GetChild(0).gameObject.GetComponent<CommandDisplay>();
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Adds Command Game object to the slot
    /// </summary>
    /// <param name="_commandPrefab">Command Prefab</param>
    /// <param name="command">Command data (Not CommandTemplateSO)</param>
    public void InsertCommand(GameObject _commandPrefab, BaseCommand command)
    {
        Vector3 spawnLocation = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            transform.localPosition.z);

        GameObject instPrefab = Instantiate(_commandPrefab, spawnLocation, Quaternion.identity);
        instPrefab.GetComponent<CommandDisplay>().data = command;
        instPrefab.transform.SetParent(transform);
        instPrefab.transform.localScale = new Vector3(1, 1, 1);
    }

    /// <summary>
    /// Removes a command game object from the slot (and any other game object that may show up there. There should be only one anyway)
    /// </summary>
    public void RemoveCommand()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
