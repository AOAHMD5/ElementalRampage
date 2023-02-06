using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI stackSizeText;
   

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        stackSizeText.enabled = false;
    }

    public void EnableSlot()
    {
        icon.enabled = true;
        labelText.enabled = true;
        stackSizeText.enabled = true;
    }
    public void DrawSlot(InventoryItem item)
    {
        if(item == null)
        {
            ClearSlot();
            return;
        }
         EnableSlot();

        icon.sprite = item.itemData.icon;
        labelText.text = item.itemData.Name;
        stackSizeText.text = item.stackSize.ToString();
    }

  
}
