using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }
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

    private List<string> inventoryList = new List<string>();

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

    public void AddItem(string newItem)
    {
        if (inventoryList.Contains(newItem) == false)
        {
            inventoryList.Add(newItem);
            UIManager.instance.SetInventoryText(inventoryList);
        }
    }

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
