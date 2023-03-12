using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int atm = 5;
    private Transform player;
    private Vector3 target;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
       
        target = new Vector3(player.position.x, player.position.y,player.position.z);
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x  == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            Debug.Log("target reached");
     
        }    
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<AttribuesManager>().TakeDamage(atm);
            destroyObj();
        }
      
    }
   
    public void destroyObj()
    {
        gameObject.SetActive(false);
    }
}
