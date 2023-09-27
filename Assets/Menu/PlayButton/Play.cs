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

        ListOfSections.ListsUpdate();

        MainGameScript.fromListToMenu.SetActive(true);
        MainGameScript.listsUp.SetActive(true);
        MainGameScript.listsDown.SetActive(true);

        Debug.Log(Application.persistentDataPath);
    }
}
