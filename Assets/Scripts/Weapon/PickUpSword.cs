using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    [Header("Sword Settings")]
    public GameObject SwordOnPlayer;
    public bool SwordEquipped = false;
    public GameObject WeaponText;
    // Start is called before the first frame update
    void Start()
    {
        SwordOnPlayer.SetActive(false);
        WeaponText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            WeaponText.SetActive(true);


            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Picked Up");
                this.gameObject.SetActive(false);
                SwordOnPlayer.SetActive(true);
                WeaponText.SetActive(false);
                SwordEquipped = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        WeaponText.SetActive(false);
    }
}

