using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMenu : MonoBehaviour
{
    public void ContinueButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
    }
}
