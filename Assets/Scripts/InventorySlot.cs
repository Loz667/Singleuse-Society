using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] Text amountText;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        iconImage.gameObject.SetActive(true);
        iconImage.sprite = slot.item.icon;

        if (slot.item.stackable == true)
        {
            amountText.gameObject.SetActive(true);
            amountText.text = slot.count.ToString();
        }
        else
        {
            amountText.gameObject.SetActive(false);
        }
    }

    public void Clean()
    {
        iconImage.sprite = null;
        iconImage.gameObject.SetActive(false);
        amountText.gameObject.SetActive(false);
    }
}
