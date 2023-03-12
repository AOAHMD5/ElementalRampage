using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : Interactable
{
   public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up item");
        Destroy(gameObject);
    }
}
