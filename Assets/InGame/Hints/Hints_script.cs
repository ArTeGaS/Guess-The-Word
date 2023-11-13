using System.Collections.Generic;
using UnityEngine;

public class Hints_script : MonoBehaviour
{
    public static bool numberOfLettersFlag = false;
    public static bool firstLetterFlag = false;
    public static bool lastLetterFlag = false;
    public static bool wrongAnswersFlag = false;

    public GameObject hintsYesNoWindow;
    public static GameObject hintsYesNoWindowObj;

    public void Start()
    {
        hintsYesNoWindowObj = hintsYesNoWindow;
    }
    public static void HintLockCheck()
    {
        if (!PlayerPrefs.HasKey(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]))
        {
            PlayerPrefs.SetInt(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord], 0);
        }
        switch (PlayerPrefs.GetInt(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]))
        {
            case <= 0:
                MainGameScript.gameWindow.SetActive(false);
                hintsYesNoWindowObj.SetActive(true);
                break;

            case >= 1:
                GameFuncs.HintsButton();
                break;
        }
    }
    public static void YesToReward()
    {
        hintsYesNoWindowObj.SetActive(false);
        AdMobScript.LoadInterstitialAd();

        GameFuncs.HintsButton();
    }
    public static void NoToReward()
    {
        MainGameScript.gameWindow.SetActive(true);
        hintsYesNoWindowObj.SetActive(false);
    }
    public static void HintsOff()
    {
        numberOfLettersFlag = false;
        firstLetterFlag = false;
        lastLetterFlag = false;
        wrongAnswersFlag= false;
    }
}
