using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon",menuName = "Inventory/Weapon")]
public class Weapon : ItemData
{
    public int DMG;

    public EquipmentSlot equipSlot;

    public override void Use()
    {
        base.Use();
    }
}

public enum EquipmentSlot
{ 
    Head,Chest,Legs,Weapon,Feet
}
