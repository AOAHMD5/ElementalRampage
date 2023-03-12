using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public ThirdPersonCharacterControl coins;
     public Text CoinsTXT;
  //  ThirdPersonCharacterControl coins;
    public Transform InsideShopUI;
    public GameObject EnterShop;

    void Start()
    {
         CoinsTXT.text = "Coins: " + coins.coins.ToString();

       

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //price
        shopItems[2, 1] = 250;
        shopItems[2, 2] = 400;
        shopItems[2, 3] = 500;
        shopItems[2, 4] = 600;

        //Quantity 
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

        InsideShopUI.gameObject.SetActive(false);
        EnterShop.SetActive(false);

    }
     void Update()
    {
        CoinsTXT.text = "Coins: " + coins.coins.ToString();
        // ShopUI();
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EnterShop.SetActive(true);
            if (Input.GetKey(KeyCode.P))
            {
                InsideShopUI.gameObject.SetActive(true);


                EnterShop.SetActive(false);


            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnterShop.SetActive(false);
        InsideShopUI.gameObject.SetActive(false);
    }

    public void Buy()
    {
       // coins = GetComponent<ThirdPersonCharacterControl>().coins;
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins.coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
          coins.coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTXT.text = "Coins " + coins.coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuanityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }

 
}
