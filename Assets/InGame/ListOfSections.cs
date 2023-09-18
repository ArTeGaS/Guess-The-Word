using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfSections : MonoBehaviour
{
    public static void ListOf(string nameOfSection)
    {
        WordsAndDescriptionriptions.listOfWords = new List<string>();
        WordsAndDescriptionriptions.listOfDiscriptions = new List<string>();
        switch (PlayerPrefs.GetString("PlayerLang"))
        {
            case "en-US":
                WordsAndDescriptionriptions.tempDict = JSON_Control.LoadJsonFile(nameOfSection + "_us_upd");
                break;
            case "uk-UA":
                WordsAndDescriptionriptions.tempDict = JSON_Control.LoadJsonFile(nameOfSection + "_ua_upd");
                break;
        }

        foreach (var pair in WordsAndDescriptionriptions.tempDict)
        {
            WordsAndDescriptionriptions.listOfWords.Add(pair.Key);
            WordsAndDescriptionriptions.listOfDiscriptions.Add(pair.Value);
        }
        FromListToGame();
    }

    public static void FromListToGame()
    {
        MenuMainScript.listOfAnimals.SetActive(false);

        MenuMainScript.ingameBack.SetActive(true);
        MenuMainScript.ingameNext.SetActive(true);
        MenuMainScript.ingameText.SetActive(true);
        MenuMainScript.ingameInputField.SetActive(true);

        MainGameScript.textMeshProS.text = WordsAndDescriptionriptions.listOfDiscriptions[0];
    }
}
