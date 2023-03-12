using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScythe : MonoBehaviour
{
    [Header("Scythe Settings")]
    public GameObject ScytheOnPlayer;
    public bool scytheEquipped = false;
    public GameObject WeaponText;
    // Start is called before the first frame update
    void Start()
    {
        ScytheOnPlayer.SetActive(false);
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
            Debug.Log("Pickable");
            WeaponText.SetActive(true);


            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Scythe Picked Up");
                this.gameObject.SetActive(false);
                ScytheOnPlayer.SetActive(true);
                WeaponText.SetActive(false);
                scytheEquipped = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        WeaponText.SetActive(false);
    }
}
