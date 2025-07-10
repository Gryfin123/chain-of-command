using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommandSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
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
