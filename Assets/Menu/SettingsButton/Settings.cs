using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void SettingsGameButton()
    {
        MenuMainScript.playButton.SetActive(false);
        MenuMainScript.settingsButton.SetActive(false);
        MenuMainScript.exitButton.SetActive(false);

        MenuMainScript.backToMenu.SetActive(true);
        MenuMainScript.resetProgress.SetActive(true);
    }
    public void ResetGameProgressButton()
    {
        foreach( var tempList in WordsAndDescriptionriptions.listsFlags )
        {
            PlayerPrefs.SetInt(tempList, 0);
        }
        foreach (var counterName in WordsCounters.countersData)
        {
            PlayerPrefs.SetInt(counterName, 0);
        }
    }
    public void BackToMenu()
    {
        MenuMainScript.backToMenu.SetActive(false);
        MenuMainScript.resetProgress.SetActive(false);

        MenuMainScript.playButton.SetActive(true);
        MenuMainScript.settingsButton.SetActive(true);
        MenuMainScript.exitButton.SetActive(true);
    }
}
