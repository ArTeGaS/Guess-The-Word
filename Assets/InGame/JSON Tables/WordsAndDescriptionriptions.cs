using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsAndDescriptionriptions : MonoBehaviour
{
    public string id;
    public string word;
    public string discriptions;

    public static Dictionary<string, string> tempDict;
    public static List<string> listOfWords;
    public static List<string> listOfDiscriptions;

    public static int animalsListFirstRunFlag = 0;
    private void Start()
    {
        if (PlayerPrefs.HasKey("animalsListFirstRunFlag"))
        {
            animalsListFirstRunFlag = PlayerPrefs.GetInt("animalsListFirstRunFlag");
        }
    }
}

