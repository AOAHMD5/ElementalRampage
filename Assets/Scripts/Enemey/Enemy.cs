using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AttribuesManager
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public GameObject bullet;
    public Transform player;
    public Transform shotArea;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public int inRadius = 3;
   
  
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
      
    }

   
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Die();
           
        }

        if (Vector3.Distance(transform.position, player.position) < inRadius && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            Debug.Log("Chasing Player");
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            Debug.Log("Shooting");
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance && (Vector3.Distance(transform.position, player.position) < inRadius))
        {
            Debug.Log("Running From Player");
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots < -0 && (Vector3.Distance(transform.position, player.position) < inRadius))
        {
            anim.Play("Throw");
            GameObject bullet = ObjectPool.instance.GetPooledObject();
            if(bullet!= null)
            {
                bullet.transform.position = shotArea.position;
                bullet.SetActive(true);
            }
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
}
