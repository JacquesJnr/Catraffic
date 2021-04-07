using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{  
	public void PlayMenu()
    {
    	// Menu Screen
    	SceneManager.LoadScene("Menu");
    }

    public void PlayGame()
    {
    	// Game Screen
        SceneManager.LoadScene("Catraffic");
    }

    public void PlayHowToPlay()
    {
    	// Guide Screen
    	SceneManager.LoadScene("HowToPlay");
    }

    public void PlayCredits()
    {
    	// Credits Screen
    	SceneManager.LoadScene("Credits");
    }
}
