using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, ICollectible
{
    public static event ItemCollected onItemCollected;

    public delegate void ItemCollected(ItemData itemData);

    public ItemData itemData;
    public void Collect()
    {
        Destroy(gameObject);
        onItemCollected?.Invoke(itemData);
    }
}


