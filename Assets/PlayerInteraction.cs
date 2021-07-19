using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] Item producedItem;
    [SerializeField] Text gameText;

    NPCManager npcManager;
    ItemSlot itemSlot;

    private void Start()
    {
        itemSlot = new ItemSlot();
        npcManager = GameObject.Find("Game Manager").GetComponent<NPCManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisplayInfo("Press E to stop this dropper", 2));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;

            if (itemSlot.item == null && Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.instance.inventoryContainer.Check(producedItem))
                {
                    ConversionProcessing();
                }
            }
        }
    }

    private void ConversionProcessing()
    {
        if (itemSlot == null) { return; }

        itemSlot.Copy(GameManager.instance.inventoryContainer.itemSlot);
        GameManager.instance.inventoryContainer.RemoveItem();

        npcManager.LittererConverted(1);
        itemSlot.Clear();

        Destroy(gameObject);
    }

    IEnumerator DisplayInfo(string message, float delay)
    {
        gameText.text = message;
        gameText.enabled = true;
        yield return new WaitForSeconds(delay);
        gameText.enabled = false;
    }
}
