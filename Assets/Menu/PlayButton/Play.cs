using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public void PlayGameButton()
    {
        MenuMainScript.playButton.SetActive(false);
        MenuMainScript.settingsButton.SetActive(false);
        MenuMainScript.exitButton.SetActive(false);

        MainGameScript.listOfAnimals.SetActive(true);

        MainGameScript.fromListToMenu.SetActive(true);
        Debug.Log(Application.persistentDataPath);
    }
}
