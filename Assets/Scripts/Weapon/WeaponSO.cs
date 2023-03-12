using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Data")]
public class WeaponSO : ScriptableObject
{

    public int DMG;
    public string weaponName;
    public GameObject weaponPrefab;
    public int comboLength;
}
