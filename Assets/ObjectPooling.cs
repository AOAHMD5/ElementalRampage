using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance; //singleton 

    private List<GameObject> pooling = new List<GameObject>();
    private int amountToPool = 20;

    [SerializeField] private GameObject bullet;

    //singleton 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            pooling.Add(obj);
        }
    }

    // Update is called once per frame

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooling.Count; i++)
        {
            if (!pooling[i].activeInHierarchy)
            {
                return pooling[i];
            }
        }
        return null;
    }

}
