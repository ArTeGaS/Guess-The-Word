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

        MenuMainScript.ingameBack.SetActive(true);
        MenuMainScript.ingameNext.SetActive(true);
        MenuMainScript.ingameText.SetActive(true);
        MenuMainScript.ingameInputField.SetActive(true);
    }
}
