using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainScript : MonoBehaviour
{
    public GameObject playButtonObj,
                    settingsButtonObj,
                    exitButtonObj,
                    ingameBackObj,
                    ingameNextObj,
                    ingameTextObj,
                    ingameInputFieldObj;

    public GameObject listOfAnimalsObj;

    public static GameObject playButton,
                            settingsButton,
                            exitButton,
                            ingameBack,
                            ingameNext,
                            ingameText,
                            ingameInputField;

    public static GameObject listOfAnimals;

    private void Start()
    {
        playButton = playButtonObj;
        settingsButton = settingsButtonObj;
        exitButton = exitButtonObj;
        ingameBack = ingameBackObj;
        ingameNext = ingameNextObj;
        ingameText = ingameTextObj;
        ingameInputField = ingameInputFieldObj;

        listOfAnimals = listOfAnimalsObj;

        playButton.SetActive(true);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);
    }
}
