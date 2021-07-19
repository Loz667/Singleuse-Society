using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemConverterInteract : MonoBehaviour
{
    [SerializeField] Item convertableItem;
    [SerializeField] Item producedItem;
    [SerializeField] int producedItemCount = 1;
    [SerializeField] Item refuelItem;

    [SerializeField] Text gameText;

    ItemSlot itemSlot;

    [SerializeField] GameObject radialIndicator;
    [SerializeField] Image indicatorFill;
    [SerializeField] float timeToProcess = 5f;
    float timer;

    WasteManager wasteManager;

    private void Start()
    {
        itemSlot = new ItemSlot();
        wasteManager = GameObject.Find("Game Manager").GetComponent<WasteManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (itemSlot.item == null && Input.GetKeyDown(KeyCode.E) && wasteManager.currentFuel > 0)
            {
                if (GameManager.instance.inventoryContainer.Check(convertableItem))
                {
                    StartItemProcessing();
                }
            }
            else if (itemSlot.item == null && Input.GetKeyDown(KeyCode.R))
            {
                if (GameManager.instance.inventoryContainer.Check(refuelItem))
                {
                    RefuelMachine();
                }
            }

            if (itemSlot.item != null && timer < 0f)
            {
                GameManager.instance.inventoryContainer.Add(itemSlot.item, itemSlot.count);
                itemSlot.Clear();
            }
        }
    }

    private void RefuelMachine()
    {
        if (wasteManager.currentFuel == wasteManager.maxFuel) { return; }

        itemSlot.Copy(GameManager.instance.inventoryContainer.itemSlot);
        GameManager.instance.inventoryContainer.RemoveItem();

        wasteManager.FuelAdded(5);

        itemSlot.Clear();
    }

    private void StartItemProcessing()
    {
        itemSlot.Copy(GameManager.instance.inventoryContainer.itemSlot);
        GameManager.instance.inventoryContainer.RemoveItem();

        timer = timeToProcess;
    }

    private void Update()
    {
        if (itemSlot == null) { return; }

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            radialIndicator.SetActive(true);
            indicatorFill.fillAmount = timer;
            StartCoroutine(DisplayInfo("Processing...", 5));

            if (timer <= 0f)
            {
                indicatorFill.fillAmount = timeToProcess;
                radialIndicator.SetActive(false);
                CompleteItemConversion();
            }
        }
    }

    private void CompleteItemConversion()
    {
        StartCoroutine(DisplayInfo("Complete!", 2));
        wasteManager.FuelUsed(20);
        itemSlot.Clear();
        itemSlot.Set(producedItem, producedItemCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisplayInfo("Press E to deposit plastic or Press R to deposit fuel", 2));
        }
    }

    IEnumerator DisplayInfo(string message, float delay)
    {
        gameText.text = message;
        gameText.enabled = true;
        yield return new WaitForSeconds(delay);
        gameText.enabled = false;
    }
}
