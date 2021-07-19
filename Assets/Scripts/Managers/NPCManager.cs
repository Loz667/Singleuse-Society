using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    [SerializeField] int litterersRemaining = 0;
    [SerializeField] int litterersConverted = 0;
    [SerializeField] Text remainText;
    [SerializeField] Text convertedText;

    private void Update()
    {
        GameObject[] litterers = GameObject.FindGameObjectsWithTag("NPC");

        litterersRemaining = litterers.Length;

        remainText.text = "Remaining: " + litterersRemaining;
    }

    public void LittererConverted(int amount)
    {
        litterersConverted += amount;
        convertedText.text = "Converted: " + litterersConverted;

        if (litterersRemaining == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameWon");
        }
    }
}
