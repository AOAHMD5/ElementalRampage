 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AttribuesManager : MonoBehaviour
{
    public int health;
    public int attack;

    public GameObject effect;
    public Animator anim;
    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        DamagePopUpGenerator.current.CreatePopUp(transform.position, amount.ToString(), Color.red);

        if (anim != null)
        {
            anim.SetTrigger("Hit");
        }
      
    }
    public virtual void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttribuesManager>();
        if(atm != null)
        {
            atm.TakeDamage(attack);
        }
       
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        GameObject deathEffectClone = Instantiate(effect,transform.position,Quaternion.identity);
        Destroy(deathEffectClone, 2);
    }

    public  virtual void Respawn()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
