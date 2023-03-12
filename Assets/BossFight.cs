using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{

    public GameObject canvas;
    bool introactive = false;
    public GameObject dragon;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        if(introactive == true)
        {
            Debug.Log("Canvas active");
            canvas.gameObject.SetActive(true);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            introactive = true;
            dragon.GetComponent<Animator>().SetBool("intro", true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dragon.GetComponent<Animator>().SetBool("intro", false);
        }
    }
}
