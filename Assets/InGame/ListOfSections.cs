using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfSections : MonoBehaviour
{
    public static void ListOf(string nameOfSection)
    {
        if (WordsAndDescriptionriptions.animalsListFirstRunFlag == 0)
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
        }
        PlayerPrefs.SetInt("animalsListFirstRunFlag", 0); //need set 1
        FromListToGame();
    }

    public static void FromListToGame()
    {
        MainGameScript.listOfAnimals.SetActive(false);

        MainGameScript.ingameBack.SetActive(true);
        MainGameScript.ingameNext.SetActive(true);
        MainGameScript.ingameText.SetActive(true);
        MainGameScript.ingameInputField.SetActive(true);

        MainGameScript.textMeshProS.text = WordsAndDescriptionriptions.listOfDiscriptions[0];
    }
}
