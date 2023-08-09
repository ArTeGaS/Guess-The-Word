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
    }
}
