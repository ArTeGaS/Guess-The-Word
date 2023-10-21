using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void SettingsGameButton()
    {
        MainGameScript.mainMenu.SetActive(false);
        MainGameScript.insideSettingsMenu.SetActive(true);
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
        MainGameScript.mainMenu.SetActive(true);
        MainGameScript.insideSettingsMenu.SetActive(false);
    }
}
