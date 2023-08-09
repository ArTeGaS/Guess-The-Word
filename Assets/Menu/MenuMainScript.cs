using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainScript : MonoBehaviour
{
    public GameObject playButtonObj;
    public GameObject settingsButtonObj;
    public GameObject exitButtonObj;
    public GameObject ingameBackObj;
    public GameObject ingameNextObj;
    public GameObject ingameTextObj;

    public static GameObject playButton;
    public static GameObject settingsButton;
    public static GameObject exitButton;
    public static GameObject ingameBack;
    public static GameObject ingameNext;
    public static GameObject ingameText;

    private void Start()
    {
        playButton = playButtonObj;
        settingsButton = settingsButtonObj;
        exitButton = exitButtonObj;
        ingameBack = ingameBackObj;
        ingameNext = ingameNextObj;
        ingameText = ingameTextObj;

        playButton.SetActive(true);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);

        ingameBack.SetActive(false);
        ingameNext.SetActive(false);
        ingameText.SetActive(false);
    }
}
