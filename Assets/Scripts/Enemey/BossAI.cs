using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : AttribuesManager
{
    public Transform player;
    public Transform shotArea;
    public GameObject bullet;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.LookAt(player);
        if(health <= 0)
        {
            anim.Play("Die");
            Invoke("Die", 5f);
            Debug.Log("canvas off");
            canvas.gameObject.SetActive(true);
          
        }

      if(health <= 50)
        {
            Debug.Log("Dragon is now Enraged!!!!");
            GetComponent<Animator>().SetBool("isEnranged", true);
        }
    }

    
    public void shoot()
    {
        GameObject bullet = ObjectPooling.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = shotArea.position;
           // bullet.transform.rotation = Quaternion.identity;
            
            bullet.SetActive(true);
        }
    }

    public override void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttribuesManager>();

        if (atm != null)
        {
            atm.TakeDamage(attack);
        }
    }
}
