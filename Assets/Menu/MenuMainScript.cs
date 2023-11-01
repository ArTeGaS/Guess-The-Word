using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainScript : MonoBehaviour
{
    public GameObject playButtonObj,
                    settingsButtonObj,
                    resetProgressObj,
                    backToMenuObj,
                    yesNoResetObj,
                    exitButtonObj;



    public static GameObject playButton,
                            settingsButton,
                            resetProgress,
                            backToMenu,
                            yesNoReset,
                            exitButton;

    private void Start()
    {
        playButton = playButtonObj;
        settingsButton = settingsButtonObj;
        resetProgress = resetProgressObj;
        backToMenu = backToMenuObj;
        yesNoReset = yesNoResetObj;
        exitButton = exitButtonObj;

        playButton.SetActive(true);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);
    }
}
