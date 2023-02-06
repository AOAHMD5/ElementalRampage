using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static event Action<List<InventoryItem>> OnInventoryChange; 
    public List<InventoryItem> inventory = new List<InventoryItem>();
    ItemData itemData;
    public event Action itemUsed;

  
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

   

    private void OnEnable()
    {
        Gem.onGemCollected += Add;
        PickUp.onItemCollected += Add;
    }

    private void OnDisable()
    {
        Gem.onGemCollected -= Add;
        PickUp.onItemCollected -= Add;
    }
    public void Add(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            if(itemData.IsStackable())
            {            
                {
                    item.AddToStack();
                    Debug.Log($"{item.itemData.Name} total stack is now {item.stackSize}");
                    OnInventoryChange?.Invoke(inventory);
                }
               
            }
          
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added{itemData.Name} to inventory for first time");
            OnInventoryChange?.Invoke(inventory);
        }
    }

    public void Remove(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
            OnInventoryChange?.Invoke(inventory);
        }
    }

    public void UseItem()
    {
      if (itemData != null)
        {
            itemData.Use();
      }
    }

}
