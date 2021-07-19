using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteManager : MonoBehaviour
{
    public WasteLevel wasteLevel;

    public int currentWaste = 0;
    public int maxWaste = 500;

    public FuelLevel fuelLevel;
    public int currentFuel;
    public int maxFuel = 100;

    private void Start()
    {
        wasteLevel.SetMaxWaste(maxWaste);
        currentFuel = maxFuel;
        fuelLevel.SetMaxFuel(maxFuel);
    }

    void Update()
    {
        wasteLevel.SetWaste(currentWaste);

        if (currentWaste == maxWaste)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }

    public void WasteCollected()
    {
        if (currentWaste > 0)
        {
            currentWaste--;
        }
    }

    public void FuelUsed(int amount)
    {
        currentFuel -= amount;

        fuelLevel.SetFuel(currentFuel);
    }

    internal void FuelAdded(int amount)
    {
        currentFuel += amount;

        fuelLevel.SetFuel(currentFuel);
    }
}
