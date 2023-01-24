using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject tutorialPanel;
    private bool tutorialPanelOn = false;

    public GameObject creditsPanel;
    private bool creditsPanelOn = false;


    public void LoadScene(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }

    public void QuitGame()
    {

        Application.Quit();

    }

    public void tutorialToggle()
    {
        if (tutorialPanelOn == false)
        {
            tutorialPanel.SetActive(true);
        }
        else
        {
            tutorialPanel.SetActive(false);
        }

        tutorialPanelOn = !tutorialPanelOn;
    }


    public void creditsToggle()
    {
        if (creditsPanelOn == false)
        {
            creditsPanel.SetActive(true);
        }
        else
        {
            creditsPanel.SetActive(false);
        }

        creditsPanelOn = !creditsPanelOn;
    }
}
