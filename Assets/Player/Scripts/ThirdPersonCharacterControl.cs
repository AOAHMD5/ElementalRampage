using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float MoveSpeed;
    public float WalkSpeed;
    public float WalkBackSpeed;
    public float RunSpeed;
    private Animator anim;
    private Vector3 moveDir;
    private CharacterController controller;
    public float coins;
   // public PickUpScythe WeaponEquipped;
    // public bool weaponEquipped = false;
    // public Text CoinsTXT;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
      //  WeaponEquipped.scytheEquipped = false;
    }
    void Update ()
    {
        PlayerMovement();





    }


   
    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        moveDir = new Vector3(hor, 0, ver);
        //moveDir = new Vector3(0, 0, ver);
        moveDir = transform.TransformDirection(moveDir);
        moveDir *= WalkSpeed;
        //Vector3 playerMovement = new Vector3(hor, 0f, ver) * MoveSpeed * Time.deltaTime;



        if (moveDir != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
           {
               //walk
               Walk();
           }
           else if (moveDir != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
           {
               //run
               Run();
           }
        else if(moveDir == Vector3.zero)
           {
               //idle
               Idle();
           }

       
        controller.Move(moveDir * Time.deltaTime);

    }
    #region anims

    public void OnTriggerEnter(Collider other)
    {
        Interactable interactable =  other.GetComponent<Interactable>();
        if(interactable != null)
        {

        }
    }

    
    private void ScytheIdle()
    {

        anim.Play("SpearIdle");

    }
    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
       
    }

    private void Walk()
    {
        MoveSpeed = WalkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }
    private void Run()
    {
        MoveSpeed = RunSpeed;
       anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }


  /*/
        private void Attack()
    {
        anim.SetTrigger("Attack");
    } /*/
    #endregion

  
}