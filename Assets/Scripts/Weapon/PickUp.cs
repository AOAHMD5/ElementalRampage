using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isWeaponEquipped;
   // public float currentweapon;
    public GameObject[] weapons;
    public GameObject[] weaponsOnPlayer;
    public GameObject WeaponText;
    private int currentWeapon;
  //  PickUpSword swordEquipped;
     void Start()
    {
        currentWeapon = 0;
        isWeaponEquipped = false;
    }
    void Update()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == currentWeapon)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }

           
            }

        for (int i = 0; i < weaponsOnPlayer.Length; i++)
        {
            if (i == currentWeapon)
            {
                weaponsOnPlayer[i].SetActive(true);
            }
            else
            {
                weaponsOnPlayer[i].SetActive(false);
            }

        }

       
        
            weaponsOnPlayer[currentWeapon].gameObject.SetActive(true);
        
       }

    public void WeaponEquipped()
    {
       // if(swordEquipped.SwordEquipped = true)
        {

            currentWeapon = 1;
            Debug.Log("Weapon Equipped! Sword");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WeaponText.SetActive(true);

            if(currentWeapon == 1)
            {
                Debug.Log("Sword");
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Picked Up");
                   // swordEquipped.SwordEquipped = true;
                    isWeaponEquipped = true;
                    // swordEquipped.SwordOnPlayer.SetActive(true);
                    weaponsOnPlayer[currentWeapon].SetActive(true);
                    
                    WeaponText.SetActive(false);
                    this.gameObject.SetActive(false);
                }
            }
        }
           
    }

    private void OnTriggerExit(Collider other)
    {
        WeaponText.SetActive(false);
    }
}
