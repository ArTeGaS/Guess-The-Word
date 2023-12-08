using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class ListOfSections : MonoBehaviour
{
    public async void ListOf(string nameOfSection)
    {
        WordsAndDescriptions.listOfWords = new List<string>();
        WordsAndDescriptions.listOfDiscriptions = new List<string>();

        WordsAndDescriptions.listOfWordsParallel = new List<string>();
        WordsAndDescriptions.listOfDiscriptionsParallel = new List<string>();

        WordsCounters.SelectedSection = nameOfSection;

        string playerPrefsId = nameOfSection + "ListFirstRunFlag";

        switch (PlayerPrefs.GetString("PlayerLang"))
        {
            case "en-US":
                WordsAndDescriptions.targetLang = "_us";
                WordsAndDescriptions.anotherLang = "_ua";
                break;
            case "uk-UA":
                WordsAndDescriptions.targetLang = "_ua";
                WordsAndDescriptions.anotherLang = "_us";
                break;
        }

        switch (PlayerPrefs.GetInt(playerPrefsId))
        {
            case 0:
                {
                    WordsAndDescriptions.tempDict =
                        await JSON_Control.LoadAddressableJsonFile(nameOfSection + WordsAndDescriptions.targetLang + "_upd");
                    WordsAndDescriptions.tempDictParallel =
                        await JSON_Control.LoadAddressableJsonFile(nameOfSection + WordsAndDescriptions.anotherLang + "_upd");
                    PlayerPrefs.SetInt(playerPrefsId, 1);
                    break;
                }
            case 1:
                {
                    WordsAndDescriptions.tempDict =
                        JSON_Control.LoadAndroidJsonFile(nameOfSection + WordsAndDescriptions.targetLang + "_temp");
                    WordsAndDescriptions.tempDictParallel =
                        JSON_Control.LoadAndroidJsonFile(nameOfSection + WordsAndDescriptions.anotherLang + "_temp");
                    break;
                }
        }

        WordsAndDescriptions.currentLoadedListName = nameOfSection + WordsAndDescriptions.targetLang + "_temp";
        WordsAndDescriptions.parallelLoadedListName = nameOfSection + WordsAndDescriptions.anotherLang + "_temp";

        foreach (var pair in WordsAndDescriptions.tempDict)
        {
            WordsAndDescriptions.listOfWords.Add(pair.Key);
            WordsAndDescriptions.listOfDiscriptions.Add(pair.Value);
        }
        foreach (var pair in WordsAndDescriptions.tempDictParallel)
        {
            WordsAndDescriptions.listOfWordsParallel.Add(pair.Key);
            WordsAndDescriptions.listOfDiscriptionsParallel.Add(pair.Value);
        }
        FromListToGame();
        //AdMobScript.LoadInterstitialAd();
        //AdMobScript.LoadBannerAds();
    }
    public void FromListToMenu()
    {
        MainGameScript.sectionsWindow.SetActive(false);

        foreach( var tempList in WordsAndDescriptions.listOfCategories)
        {
            tempList.SetActive(false);
        }

        MainGameScript.mainMenu.SetActive(true);
    }
    public static void FromListToGame()
    {
        MainGameScript.sectionsWindow.SetActive(false);

        foreach (var tempList in WordsAndDescriptions.listOfCategories)
        {
            tempList.SetActive(false);
        }

        MainGameScript.gameWindow.SetActive(true);

        UpdateWordDescription();
    }
    public static void SaveProgress()
    {
        WordsAndDescriptions.tempDict = new Dictionary<string, string>();
        WordsAndDescriptions.tempDictParallel = new Dictionary<string, string>();

        for (int i = 0; i < WordsAndDescriptions.listOfWords.Count; i++)
        {
            WordsAndDescriptions.tempDict.Add(WordsAndDescriptions.listOfWords[i],
                                                        WordsAndDescriptions.listOfDiscriptions[i]);
            WordsAndDescriptions.tempDictParallel.Add(WordsAndDescriptions.listOfWordsParallel[i],
                                                                WordsAndDescriptions.listOfDiscriptionsParallel[i]);
        }
        JSON_Control.SaveAndroidJsonFile(WordsAndDescriptions.currentLoadedListName,
                                    WordsAndDescriptions.tempDict);
        JSON_Control.SaveAndroidJsonFile(WordsAndDescriptions.parallelLoadedListName,
                                    WordsAndDescriptions.tempDictParallel);
    }
    public static void HideWordDescriprion()
    {
        MainGameScript.textMeshProS.text = " ";
    }
    public static void UpdateWordDescription()
    {
        MainGameScript.textMeshProS.text = "    " + WordsAndDescriptions.listOfDiscriptions[WordsAndDescriptions.currentWord] + "\n";
        // Показ кількості слів.
        if (Hints_script.numberOfLettersFlag)
        {
            string local = LocalizationSettings.StringDatabase.GetLocalizedString("Game_texts", "NumOfLetters");

            MainGameScript.textMeshProS.text = MainGameScript.textMeshProS.text + "\n" + local +
                WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord].Count();
        }
        // Показ першої літери.
        if (Hints_script.firstLetterFlag)
        {
            string local = LocalizationSettings.StringDatabase.GetLocalizedString("Game_texts", "FirstLetter");

            MainGameScript.textMeshProS.text = MainGameScript.textMeshProS.text + "\n" + local +
                WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord][0];
        }
        // Показ останньої літери.
        if (Hints_script.lastLetterFlag)
        {
            string local = LocalizationSettings.StringDatabase.GetLocalizedString("Game_texts", "LastLetter");

            MainGameScript.textMeshProS.text = MainGameScript.textMeshProS.text + "\n" + local +
                WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord][
                    WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord].Count() - 1];
        }
        // Показ хибних відповідей.
        if (Hints_script.wrongAnswersFlag)
        {
            if (!WordsAndDescriptions.wrongAnswersDict.ContainsKey(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]))
            {
                WordsAndDescriptions.wrongAnswersDict.Add(
                    WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord], "");

            }
            string local = LocalizationSettings.StringDatabase.GetLocalizedString("Game_texts", "WrongAnswers");

            MainGameScript.textMeshProS.text = MainGameScript.textMeshProS.text + "\n\n" + local + "\n" +
                WordsAndDescriptions.wrongAnswersDict[WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]];
        }
    }
    public static int CalculateAllWords()
    {
        WordsAndDescriptions.wordsCount = WordsAndDescriptions.listOfWords.Count;
        return WordsAndDescriptions.listOfWords.Count;
    }

    public static void ListsUpdate()
    {
        List<GameObject> listLink = WordsAndDescriptions.listOfCategories;
        listLink[0].transform.position = MainGameScript.posE_1.transform.position;
        listLink[1].transform.position = MainGameScript.posE_2.transform.position;
        listLink[2].transform.position = MainGameScript.posE_3.transform.position;
        listLink[3].transform.position = MainGameScript.posE_4.transform.position;

        for (int i = 4; i <= 7; i++)
        {
            listLink[i].SetActive(false);
        }
        for (int i = 0; i <= 3; i++)
        {
            listLink[i].SetActive(true);
        }

    }
    public static void CountersUpdate()
    {
        WordsCounters.animalsCounterObj.text = PlayerPrefs.GetInt("AnimalsCount") + "/" + WordsCounters.animalsFull;
        WordsCounters.archeologyCounterObj.text = PlayerPrefs.GetInt("ArcheologyCount") + "/" + WordsCounters.archeologyFull;
        WordsCounters.architectureCounterObj.text = PlayerPrefs.GetInt("ArchitectureCount") + "/" + WordsCounters.architectureFull;
        WordsCounters.cinemaCounterObj.text = PlayerPrefs.GetInt("CinemaCount") + "/" + WordsCounters.cinemaFull;
        WordsCounters.foodCounterObj.text = PlayerPrefs.GetInt("FoodCount") + "/" + WordsCounters.foodFull;
        WordsCounters.gamesCounterObj.text = PlayerPrefs.GetInt("GamesCount") + "/" + WordsCounters.gamesFull;
        WordsCounters.middleAgesCounterObj.text = PlayerPrefs.GetInt("MiddleAgesCount") + "/" + WordsCounters.middleAgesFull;
        WordsCounters.plantCounterObj.text = PlayerPrefs.GetInt("PlantsCount") + "/" + WordsCounters.plantsFull;
    }
    public static void ListsUp()
    {
        List<GameObject> listLink = WordsAndDescriptions.listOfCategories;
        listLink.Insert(0, listLink[listLink.Count -1]);
        listLink.RemoveAt(listLink.Count - 1);
        ListsUpdate();
    }
    public static void ListsDown()
    {
        List<GameObject> listLink = WordsAndDescriptions.listOfCategories;
        listLink.Add(listLink[0]);
        listLink.RemoveAt(0);
        ListsUpdate();
    }
}
