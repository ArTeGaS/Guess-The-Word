using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsAndDescriptionriptions : MonoBehaviour
{
    public static Dictionary<string, string> tempDict;
    public static List<string> listOfWords;
    public static List<string> listOfDiscriptions;

    public static Dictionary<string, string> tempDictParallel;
    public static List<string> listOfWordsParallel;
    public static List<string> listOfDiscriptionsParallel;

    public static string currentLoadedListName;
    public static string parallelLoadedListName;
    public static string targetLang;
    public static string anotherLang;
    public static int currentWord = 0;
    public static int wordsCount;

    public static int animalsListFirstRunFlag = 0;
    private void Start()
    {
        if (PlayerPrefs.HasKey("animalsListFirstRunFlag"))
        {
            animalsListFirstRunFlag = PlayerPrefs.GetInt("animalsListFirstRunFlag");
        }
    }
}

