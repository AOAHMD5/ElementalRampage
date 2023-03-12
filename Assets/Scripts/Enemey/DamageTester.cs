using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{

    public AttribuesManager playeratm;
    public AttribuesManager enemyatm;
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F11))
        {
            playeratm.DealDamage(enemyatm.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.F12))
        {
            enemyatm.DealDamage(playeratm.gameObject);
        }
    }
}
