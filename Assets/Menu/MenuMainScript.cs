using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainScript : MonoBehaviour
{
    public GameObject playButtonObj,
                    settingsButtonObj,
                    exitButtonObj;



    public static GameObject playButton,
                            settingsButton,
                            exitButton;

    private void Start()
    {
        playButton = playButtonObj;
        settingsButton = settingsButtonObj;
        exitButton = exitButtonObj;

        playButton.SetActive(true);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);
    }
}
