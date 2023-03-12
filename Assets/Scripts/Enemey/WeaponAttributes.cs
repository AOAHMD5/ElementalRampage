using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    public AttribuesManager atm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FireEnemy"))
        {
            other.GetComponent<AttribuesManager>().TakeDamage(atm.attack);
          
        }

        if (other.CompareTag("EarthEnemy"))
        {
            other.GetComponent<AttribuesManager>().TakeDamage(atm.attack);

        }

        if (other.CompareTag("Dragon"))
        {
            other.GetComponent<AttribuesManager>().TakeDamage(atm.attack);

        }
    }

}
