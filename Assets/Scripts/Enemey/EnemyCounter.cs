using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    public GameObject[] EarthEnemies;
    public GameObject[] FireEnemies;
    public GameObject bossPortal;
    public GameObject ForestPortal;
    // Start is called before the first frame update
    void Start()
    {
        bossPortal.gameObject.SetActive(false);
        ForestPortal.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EarthEnemies = GameObject.FindGameObjectsWithTag("EarthEnemy");

        FireEnemies = GameObject.FindGameObjectsWithTag("FireEnemy");

        if (FireEnemies.Length == 0)
        {
            ForestPortal.gameObject.SetActive(true);
        }

        if (EarthEnemies.Length == 0)
        {
            bossPortal.gameObject.SetActive(true);
        }
        
        
    }
}
