using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] List<InventorySlot> inventorySlots;

    private void Start()
    {
        SetIndex();
        Show();
    }

    private void Update()
    {
        Show();
    }

    private void SetIndex()
    {
        for( int i = 0; i < inventory.slots.Count; i++)
        {
            inventorySlots[i].SetIndex(i);
        }
    }

    private void Show()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                inventorySlots[i].Clean();
            }
            else
            {
                inventorySlots[i].Set(inventory.slots[i]);
            }
        }
    }
}
