using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public LayerMask enemyLayer;
    public float damage = 1f;
    public float radius = 0.3f;

    private Enemey Health;
    private bool collided;

    // Start is called before the first frame update
    void Update()
    {
        CheckForDamage();
    }

    // Update is called once per frame
    void CheckForDamage()
    {
        //if radius (def above) of sphere encounters object onenemyLayer = collides
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach (Collider h in hits)
        {
            Health = h.GetComponent<Enemey>();

            if (Health)
            {//if got script
                collided = true;
            }
        }

        if (collided)
        {
            collided = false; //so apply damage once
            Health.Damage(damage);
            gameObject.SetActive(false);
        }


    }





}//class