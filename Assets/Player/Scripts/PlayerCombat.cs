using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    //combat combo
    [Header("Variables")]
     int comboCounter;
     float cooldownTime = 0.1f;
     float lastClicked;
     float lastComboEnd;
    

    [SerializeField] public WeaponsHolder weaponEquipped;

    //characterinfo
    
    // protected Weapons currentWeapon;
    Animator anim;
    public Weapons currentWeapon;

    // Start is called before the first frame update
     void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(currentWeapon.weaponName);

    }

    // Update is called once per frame
    void Update()
    {
       
        {
            if (currentWeapon != null)
            {

                Attack(currentWeapon.weaponName);
                Debug.Log(currentWeapon.weaponName);
            }
        }

    }

    void Attack(string weapon)
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastComboEnd > cooldownTime)
        {
            comboCounter++;
            comboCounter = Mathf.Clamp(comboCounter, 0, currentWeapon.comboLength);
           
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
        for (int i = 0; i < currentWeapon.comboLength; i++)
        {
            Debug.Log(currentWeapon.comboLength);
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
