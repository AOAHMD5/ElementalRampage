using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    public int coins;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
         coins = coins + 1000;
            this.gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
