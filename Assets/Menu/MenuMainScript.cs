using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainScript : MonoBehaviour
{
    public GameObject playButtonObj,
                    settingsButtonObj,
                    resetProgressObj,
                    backToMenuObj,
                    exitButtonObj;



    public static GameObject playButton,
                            settingsButton,
                            resetProgress,
                            backToMenu,
                            exitButton;

    private void Start()
    {
        playButton = playButtonObj;
        settingsButton = settingsButtonObj;
        resetProgress = resetProgressObj;
        backToMenu = backToMenuObj;
        exitButton = exitButtonObj;

        playButton.SetActive(true);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);
    }
}
