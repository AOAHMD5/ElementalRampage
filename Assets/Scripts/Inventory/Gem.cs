using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gem : MonoBehaviour, ICollectible
{
    public static event GemCollected onGemCollected;

    public delegate void GemCollected(ItemData itemData);

    public ItemData gemData;
    public void Collect()
    {
        Destroy(gameObject);
        onGemCollected?.Invoke(gemData);
    }
}
