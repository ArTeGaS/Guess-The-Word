using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ListOfSections : MonoBehaviour
{
    public static async void ListOf(string nameOfSection)
    {
        WordsAndDescriptionriptions.listOfWords = new List<string>();
        WordsAndDescriptionriptions.listOfDiscriptions = new List<string>();

        WordsAndDescriptionriptions.listOfWordsParallel = new List<string>();
        WordsAndDescriptionriptions.listOfDiscriptionsParallel = new List<string>();

        switch (PlayerPrefs.GetString("PlayerLang"))
        {
            case "en-US":
                WordsAndDescriptionriptions.targetLang = "_us";
                WordsAndDescriptionriptions.anotherLang = "_ua";
                break;
            case "uk-UA":
                WordsAndDescriptionriptions.targetLang = "_ua";
                WordsAndDescriptionriptions.anotherLang = "_us";
                Debug.Log("Відкрита Українська локлізація");
                break;
        }

        switch (PlayerPrefs.GetInt("animalsListFirstRunFlag"))
        {
            case 0:
                {
                    WordsAndDescriptionriptions.tempDict =
                        await JSON_Control.LoadJsonFileNew(nameOfSection + WordsAndDescriptionriptions.targetLang + "_upd");
                    WordsAndDescriptionriptions.tempDictParallel =
                        await JSON_Control.LoadJsonFileNew(nameOfSection + WordsAndDescriptionriptions.anotherLang + "_upd");
                    Debug.Log(nameOfSection + WordsAndDescriptionriptions.targetLang + "_upd");
                    PlayerPrefs.SetInt("animalsListFirstRunFlag", 1);
                    Debug.Log("Створено новий список");
                    break;
                }
            case 1:
                {
                    WordsAndDescriptionriptions.tempDict =
                        JSON_Control.LoadJsonFile(nameOfSection + WordsAndDescriptionriptions.targetLang + "_temp");
                    WordsAndDescriptionriptions.tempDictParallel =
                        JSON_Control.LoadJsonFile(nameOfSection + WordsAndDescriptionriptions.anotherLang + "_temp");
                    Debug.Log("Відкрито існуючий список");
                    break;
                }
        }

        WordsAndDescriptionriptions.currentLoadedListName = nameOfSection + WordsAndDescriptionriptions.targetLang + "_temp";
        WordsAndDescriptionriptions.parallelLoadedListName = nameOfSection + WordsAndDescriptionriptions.anotherLang + "_temp";

        foreach (var pair in WordsAndDescriptionriptions.tempDict)
        {
            WordsAndDescriptionriptions.listOfWords.Add(pair.Key);
            WordsAndDescriptionriptions.listOfDiscriptions.Add(pair.Value);
        }
        foreach (var pair in WordsAndDescriptionriptions.tempDictParallel)
        {
            WordsAndDescriptionriptions.listOfWordsParallel.Add(pair.Key);
            WordsAndDescriptionriptions.listOfDiscriptionsParallel.Add(pair.Value);
        }
        FromListToGame();
    }
    public static void FromListToMenu()
    {
        MainGameScript.listOfAnimals.SetActive(false);

        MainGameScript.fromListToMenu.SetActive(false);

        MenuMainScript.playButton.SetActive(true);
        MenuMainScript.settingsButton.SetActive(true);
        MenuMainScript.exitButton.SetActive(true);
    }
    public static void FromListToGame()
    {
        MainGameScript.listOfAnimals.SetActive(false);

        MainGameScript.fromListToMenu.SetActive(false);

        MainGameScript.ingameBack.SetActive(true);
        MainGameScript.ingameNext.SetActive(true);
        MainGameScript.ingameHints.SetActive(true);
        MainGameScript.ingameSection.SetActive(true);
        MainGameScript.ingameText.SetActive(true);
        MainGameScript.ingameInputField.SetActive(true);

        UpdateWordDescription();
    }
    public static void SaveProgress()
    {
        WordsAndDescriptionriptions.tempDict = new Dictionary<string, string>();
        WordsAndDescriptionriptions.tempDictParallel = new Dictionary<string, string>();

        for (int i = 0; i < WordsAndDescriptionriptions.listOfWords.Count; i++)
        {
            WordsAndDescriptionriptions.tempDict.Add(WordsAndDescriptionriptions.listOfWords[i],
                                                        WordsAndDescriptionriptions.listOfDiscriptions[i]);
            WordsAndDescriptionriptions.tempDictParallel.Add(WordsAndDescriptionriptions.listOfWordsParallel[i],
                                                                WordsAndDescriptionriptions.listOfDiscriptionsParallel[i]);
        }
        JSON_Control.SaveJsonFileNew(WordsAndDescriptionriptions.currentLoadedListName,
                                    WordsAndDescriptionriptions.tempDict,
                                    JSON_Control.localTempPath);
        JSON_Control.SaveJsonFileNew(WordsAndDescriptionriptions.parallelLoadedListName,
                                    WordsAndDescriptionriptions.tempDictParallel,
                                    JSON_Control.localTempPath);
    }
    public static void HideWordDescriprion()
    {
        MainGameScript.textMeshProS.text = " ";
    }
    public static void UpdateWordDescription()
    {
        MainGameScript.textMeshProS.text = "    " + WordsAndDescriptionriptions.listOfDiscriptions[WordsAndDescriptionriptions.currentWord];
    }
    public static int CalculateAllWords()
    {
        WordsAndDescriptionriptions.wordsCount = WordsAndDescriptionriptions.listOfWords.Count;
        return WordsAndDescriptionriptions.listOfWords.Count;
    }
}
