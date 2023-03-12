using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Customizer : MonoBehaviour
{
    public GameObject[] Hair;
    public GameObject[] chest;
    public GameObject[] pants;
    public GameObject[] boots;
    private int currentHair;
    private int currentChest;
    private int currentPants;
    private int currentBoots;
    public Transform victory;
    public Transform player,cam;
    public Transform InsideShopUI;
    public Transform canvas;
    public Camera cam1;
    public Camera cam2;
    // Start is called before the first frame update
    void Start()
    {
        player.gameObject.GetComponent<vThirdPersonController>().enabled = false;
        player.gameObject.GetComponent<vThirdPersonInput>().enabled = false;
        player.gameObject.GetComponent<AttackControl>().enabled = false;
        cam.gameObject.GetComponent<vThirdPersonCamera>().enabled = false;
        cam1.enabled = true;
        cam2.enabled = false;
    }
    void Update()
    {
        #region customiser 
        for (int i = 0; i < Hair.Length; i++)
        {
            if (i == currentHair)
            {
                Hair[i].SetActive(true);
            }
            else
            {
                Hair[i].SetActive(false);
            }
        }

        for (int i = 0; i < chest.Length; i++)
        {
            if (i == currentChest)
            {
                chest[i].SetActive(true);
            }
            else
            {
                chest[i].SetActive(false);
            }
        }

        for (int i = 0; i < pants.Length; i++)
        {
            if (i == currentPants)
            {
                pants[i].SetActive(true);
            }
            else
            {
                pants[i].SetActive(false);
            }
        }

        for (int i = 0; i < boots.Length; i++)
        {
            if (i == currentBoots)
            {
                boots[i].SetActive(true);
            }
            else
            {
                boots[i].SetActive(false);
            }
        }
        #endregion
        CharacterCreator();


    }
    public void Randon()
    {
        currentHair = Random.Range(0, 4);
        currentChest = Random.Range(0, 4);
        currentPants = Random.Range(0, 4);
        currentBoots = Random.Range(0, 4);



    }
    public void SwitchHair()
    {
        if (currentHair == Hair.Length - 1)
        {
            currentHair = 0;
        }
        else
        {
            currentHair++;
        }
    }

    public void SwitchChest()
    {
        if (currentChest == chest.Length - 1)
        {
            currentChest = 0;
        }
        else
        {
            currentChest++;
        }
    }

    public void CharacterCreator()
    {
        if(canvas.gameObject.activeInHierarchy == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (InsideShopUI.gameObject.activeInHierarchy == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (victory.gameObject.activeInHierarchy == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

  
     
    public void Confirm()
    {
        canvas.gameObject.SetActive(false);

        player.gameObject.GetComponent<vThirdPersonController>().enabled = true;
        cam.gameObject.GetComponent<vThirdPersonCamera>().enabled = true;
        player.gameObject.GetComponent<vThirdPersonInput>().enabled = true;
        player.gameObject.GetComponent<AttackControl>().enabled = true;
        cam1.enabled = false;
        cam2.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void SwitchPants()
    {
        if (currentPants == pants.Length - 1)
        {
            currentPants = 0;
        }
        else
        {
            currentPants++;
        }
    }

    public void SwitchBoots()
    {
        if (currentBoots == boots.Length - 1)
        {
            currentBoots = 0;
        }
        else
        {
            currentBoots++;
        }
    }
}
