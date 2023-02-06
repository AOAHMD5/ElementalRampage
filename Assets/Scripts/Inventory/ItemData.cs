using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class ItemData : ScriptableObject
{

    public string Name;
    public Sprite icon;
    public ItemType itemType;
    public enum ItemType { 
        Weapon,
        HealthPot,
        ManaPot,
        Coin,
    }

    public virtual void Use()
    {
        Debug.Log("Using" + Name);
    }

   
    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPot:
            case ItemType.ManaPot:
            case ItemType.Coin:
                return true;
            case ItemType.Weapon: 
                return false;

        }

    }

    
}
