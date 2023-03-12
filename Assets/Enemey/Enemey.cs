using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
   
    public float Health = 100f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float dmg)
    {
        Health -= dmg;
        if(Health < 0)
        {

        }
    }

   
}
