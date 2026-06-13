/*
 * Author: Adam Clark
 * Date: 10 June 2026
 * Description: Manages & stores inventory items for game using Singleton instances
 */

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores collected inventory items and updates the inventory UI.
/// </summary>
public class InventoryManager : MonoBehaviour
{
    /// <summary>
    /// Global access point for the active inventory manager instance.
    /// </summary>
    public static InventoryManager instance { get; private set; }

    /// <summary>
    /// Sets up the singleton reference and removes duplicate inventory manager objects.
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log($"ERROR! Duplicate instance found (Instance: {instance})");
            Destroy(gameObject);
        }
        else
        { instance = this; }
    }

    /// <summary>
    /// Names of inventory items currently held by the player.
    /// </summary>
    private List<string> inventoryList = new List<string>();

    /// <summary>
    /// Checks whether the player currently has a named inventory item.
    /// </summary>
    /// <param name="newItem">Name of the item to check for.</param>
    /// <returns>True if the item exists in the inventory; otherwise false.</returns>
    public bool HasItem(string newItem)
    {
        if (newItem != "")
        {
            if (inventoryList.Contains(newItem))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Adds a named item to the inventory if it is not already present.
    /// </summary>
    /// <param name="newItem">Name of the item to add.</param>
    public void AddItem(string newItem)
    {
        if (inventoryList.Contains(newItem) == false)
        {
            inventoryList.Add(newItem);
            UIManager.instance.SetInventoryText(inventoryList);
        }
    }

    /// <summary>
    /// Removes a named item from the inventory if it is present.
    /// </summary>
    /// <param name="newItem">Name of the item to remove.</param>
    public void RemoveItem(string newItem)
    {
        if (inventoryList.Contains(newItem) == true)
        {
            inventoryList.Remove(newItem);
            UIManager.instance.SetInventoryText(inventoryList);
        }
        else
        {
            Debug.Log($"INVMANAGER: ERROR! RemoveItem called, but item not found (item: {newItem}");
        }
    }
}
