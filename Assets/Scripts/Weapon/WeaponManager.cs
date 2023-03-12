using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    public WeaponSO equippedWeapon;
    private GameObject currentWeapon;
    public bool isHeld = false;
    [SerializeField]
    private Transform weaponSlot;


    [Header("Variables")]
    int comboCounter;
    float cooldownTime = 0.1f;
    float lastClicked;
    float lastComboEnd;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if(currentWeapon != null)
        {
            Attack(equippedWeapon.weaponName);
        }
        
    }

    public void EquipWeapon(WeaponSO weaponData)
    {
        equippedWeapon = weaponData;
        if (currentWeapon != null)
            Destroy(currentWeapon);

        isHeld = true;
        currentWeapon = Instantiate(weaponData.weaponPrefab);
        currentWeapon.transform.SetParent(weaponSlot);
        currentWeapon.transform.localPosition = Vector3.zero ;
        currentWeapon.transform.localRotation = Quaternion.identity;

    }

    public void Drop()
    {
        isHeld = false;
       // Instantiate(currentWeapon);

    }

 
    void Attack(string weapon)
     {
         if (Input.GetButtonDown("Fire1") && Time.time - lastComboEnd > cooldownTime)
         {
             comboCounter++;
             comboCounter = Mathf.Clamp(comboCounter, 0, equippedWeapon.comboLength);

             //create attack names
             for (int i = 0; i < comboCounter; i++)
             {
                 if (i == 0)
                 {
                     if (comboCounter == 1 && anim.GetCurrentAnimatorStateInfo(0).IsTag("Movement"))
                     {
                         anim.SetBool("AttackStart", true);
                         anim.SetBool(weapon + "Attack" + (i + 1), true);
                         lastClicked = Time.time;
                         Debug.Log("Playing first attack");
                     }
                 }
                 else
                 {
                     if (comboCounter >= (i + 1) && anim.GetCurrentAnimatorStateInfo(0).IsName(weapon + "Attack" + i))
                     {
                       
                        anim.SetBool(weapon + "Attack" + (i + 1), true);
                         anim.SetBool(weapon + "Attack" + (i), true);
                         lastClicked = Time.time;
                         Debug.Log("Playing second attack");
                     }
                 }
             }
         }

         //animation exil bool reset
         for (int i = 0; i < equippedWeapon.comboLength; i++)
         {
             Debug.Log(equippedWeapon.comboLength);
             if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(0).IsName(weapon + "Attack" + (i + 1)))
             {
                 comboCounter = 0;
                 Debug.Log("end of attacks");
                 lastComboEnd = Time.time;
                 anim.SetBool(weapon + "Attack" + (i + 1), false);
                 anim.SetBool("AttackStart", false);
             }
         }

     }   
}
