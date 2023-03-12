using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp : MonoBehaviour
{

    [SerializeField] Transform transformTp;
    [SerializeField] GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.25f);
        player.transform.position = new Vector3(
            transformTp.transform.position.x,
            transformTp.transform.position.y,
            transformTp.transform.position.z);
    }
}
