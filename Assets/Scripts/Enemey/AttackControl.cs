using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    private Animator anim;
    public AttribuesManager atm;
   
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (atm.health == 0)
        {
            atm.Respawn();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
        }
    }
}
