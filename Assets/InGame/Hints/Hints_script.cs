using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Hints_script : MonoBehaviour
{
    public static bool numberOfLettersFlag = false;
    public static bool firstLetterFlag = false;
    public static bool lastLetterFlag = false;
    public static bool wrongAnswersFlag = false;

    public static List<string> flags = new List<string> 
    {
        "numberOfLettersFlag",
        "firstLetterFlag",
        "lastLetterFlag",
        "wrongAnswersFlag"

    };
    public void Start()
    {
        if (PlayerPrefs.HasKey("numberOfLettersFlag"))
        {
            numberOfLettersFlag = bool.Parse(PlayerPrefs.GetString("numberOfLettersFlag"));
            firstLetterFlag = bool.Parse(PlayerPrefs.GetString("firstLetterFlag"));
            lastLetterFlag = bool.Parse(PlayerPrefs.GetString("lastLetterFlag"));
            wrongAnswersFlag = bool.Parse(PlayerPrefs.GetString("wrongAnswersFlag"));
        }
        else if (!PlayerPrefs.HasKey("numberOfLettersFlag"))
        {
            foreach (var key in flags)
            {
                PlayerPrefs.SetString(key, "false");
            }
        }
    }
}
