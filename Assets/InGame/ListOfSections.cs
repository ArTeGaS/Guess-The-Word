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

        WordsCounters.SelectedSection = nameOfSection;

        string playerPrefsId = nameOfSection + "ListFirstRunFlag";

        switch (PlayerPrefs.GetString("PlayerLang"))
        {
            case "en-US":
                WordsAndDescriptionriptions.targetLang = "_us";
                WordsAndDescriptionriptions.anotherLang = "_ua";
                break;
            case "uk-UA":
                WordsAndDescriptionriptions.targetLang = "_ua";
                WordsAndDescriptionriptions.anotherLang = "_us";
                break;
        }

        switch (PlayerPrefs.GetInt(playerPrefsId))
        {
            case 0:
                {
                    WordsAndDescriptionriptions.tempDict =
                        await JSON_Control.LoadJsonFileNew(nameOfSection + WordsAndDescriptionriptions.targetLang + "_upd");
                    WordsAndDescriptionriptions.tempDictParallel =
                        await JSON_Control.LoadJsonFileNew(nameOfSection + WordsAndDescriptionriptions.anotherLang + "_upd");
                    PlayerPrefs.SetInt(playerPrefsId, 1);
                    break;
                }
            case 1:
                {
                    WordsAndDescriptionriptions.tempDict =
                        JSON_Control.LoadJsonFile(nameOfSection + WordsAndDescriptionriptions.targetLang + "_temp");
                    WordsAndDescriptionriptions.tempDictParallel =
                        JSON_Control.LoadJsonFile(nameOfSection + WordsAndDescriptionriptions.anotherLang + "_temp");
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
        MainGameScript.sectionsWindow.SetActive(false);

        foreach( var tempList in WordsAndDescriptionriptions.listOfCategories)
        {
            tempList.SetActive(false);
        }

        MainGameScript.mainMenu.SetActive(true);
    }
    public static void FromListToGame()
    {
        MainGameScript.sectionsWindow.SetActive(false);

        foreach (var tempList in WordsAndDescriptionriptions.listOfCategories)
        {
            tempList.SetActive(false);
        }

        MainGameScript.gameWindow.SetActive(true);

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
                                    WordsAndDescriptionriptions.tempDict);
        JSON_Control.SaveJsonFileNew(WordsAndDescriptionriptions.parallelLoadedListName,
                                    WordsAndDescriptionriptions.tempDictParallel);
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

    public static void ListsUpdate()
    {
        List<GameObject> listLink = WordsAndDescriptionriptions.listOfCategories;
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
        List<GameObject> listLink = WordsAndDescriptionriptions.listOfCategories;
        listLink.Insert(0, listLink[listLink.Count -1]);
        listLink.RemoveAt(listLink.Count - 1);
        ListsUpdate();
    }
    public static void ListsDown()
    {
        List<GameObject> listLink = WordsAndDescriptionriptions.listOfCategories;
        listLink.Add(listLink[0]);
        listLink.RemoveAt(0);
        ListsUpdate();
    }
}
