using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponSO weaponData;
    public WeaponManager equip;
    public GameObject WeaponText;
    private void OnTriggerEnter(Collider other)
    {
        WeaponManager weaponManager = other.GetComponent<WeaponManager>();
        if (weaponManager != null) 
        {
            WeaponText.SetActive(true);

            if (equip.isHeld == false && Input.GetKey(KeyCode.E))
            {
                weaponManager.EquipWeapon(weaponData);

                gameObject.SetActive(false);
                WeaponText.SetActive(false);

                Debug.Log("Weapon Equipped");
            }
            else if (equip.isHeld == true && Input.GetKey(KeyCode.E))
            {
                equip.Drop();
               
                //Instantiate(gameObject);
                Debug.Log("Weapon Dropped");

            }
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
          //  enemy.TakeDmg(weaponData.DMG);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        WeaponText.SetActive(false);
    }

}
