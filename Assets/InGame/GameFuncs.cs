using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFuncs : MonoBehaviour
{
    public void OnEnterPress()
    {
        string titleLetter = MainGameScript.inputFieldText.text[0].ToString().ToUpper();
        string restOfTheString = MainGameScript.inputFieldText.text.Substring(1).ToLower();
        MainGameScript.inputFieldText.text = titleLetter + restOfTheString;

        if (MainGameScript.inputFieldText.text == WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord])
        {
            StartCoroutine(CongratsEvent());
        }
        else if (MainGameScript.inputFieldText.text != WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord])
        {
            if (WordsAndDescriptions.wrongAnswersDict.ContainsKey(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]))
            {
                WordsAndDescriptions.wrongAnswersDict[WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]] =
                    WordsAndDescriptions.wrongAnswersDict[WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]] +
                    MainGameScript.inputFieldText.text + ", ";
                JSON_Control.SaveAndroidJsonFile("WrongAnswers", WordsAndDescriptions.wrongAnswersDict);
                ListOfSections.UpdateWordDescription();
            }
        }
    }
    public IEnumerator CongratsEvent()
    {
        PlayerPrefs.SetInt(WordsCounters.SelectedSection + "Count", PlayerPrefs.GetInt(WordsCounters.SelectedSection + "Count") + 1);
        MainGameScript.inGameCanvasGroup.blocksRaycasts = false;
        ListOfSections.HideWordDescriprion();
        MainGameScript.congratsText.SetActive(true);
        WordsAndDescriptions.listOfWords.RemoveAt(WordsAndDescriptions.currentWord);
        WordsAndDescriptions.listOfWordsParallel.RemoveAt(WordsAndDescriptions.currentWord);
        WordsAndDescriptions.listOfDiscriptions.RemoveAt(WordsAndDescriptions.currentWord);
        WordsAndDescriptions.listOfDiscriptionsParallel.RemoveAt(WordsAndDescriptions.currentWord);
        ListOfSections.SaveProgress();
        yield return new WaitForSeconds(2f);
        switch (ListOfSections.CalculateAllWords())
        {
            case > 0:
                MainGameScript.congratsText.SetActive(false);
                MainGameScript.inputFieldText.text = "";
                ListOfSections.UpdateWordDescription();
                MainGameScript.inGameCanvasGroup.blocksRaycasts = true;
                break;
            case 0:
                MainGameScript.congratsText.SetActive(false);
                MainGameScript.inputFieldText.text = "";
                MainGameScript.inGameCanvasGroup.blocksRaycasts = true;
                BackToSections();
                break;
        }
        
    }
    public void NextWordButton()
    {
        switch (WordsAndDescriptions.currentWord)
        {
            case int n when n < ListOfSections.CalculateAllWords() - 1:
                WordsAndDescriptions.currentWord++;
                break;
            case int n when n <= ListOfSections.CalculateAllWords() -1:
                WordsAndDescriptions.currentWord = 0;
                break;
        }
        ListOfSections.UpdateWordDescription();
    }
    public void BackWordButton()
    {
        switch (WordsAndDescriptions.currentWord)
        {
            case > 0:
                WordsAndDescriptions.currentWord--;
                break;
            case <= 0:
                WordsAndDescriptions.currentWord = ListOfSections.CalculateAllWords() -1;
                break;
        }
        ListOfSections.UpdateWordDescription();
    }
    public void BackToSections()
    {
        ListOfSections.CountersUpdate();
        ListOfSections.ListsUpdate();
        ListOfSections.SaveProgress();
        WordsAndDescriptions.currentWord = 0;

        MainGameScript.sectionsWindow.SetActive(true);

        MainGameScript.gameWindow.SetActive(false);

        SectionsBlocker();
    }

    public void HintsButton()
    {
        MainGameScript.gameWindow.SetActive(false);

        MainGameScript.hintsWindow.SetActive(true);
    }
    public void CloseHintsButton()
    {
        MainGameScript.hintsWindow.SetActive(false);

        MainGameScript.gameWindow.SetActive(true);
    }
    // Секція перемикачів підказок
    public static void NumberOfLettersButton()
    {
        Hints_script.numberOfLettersFlag = !Hints_script.numberOfLettersFlag;
        ListOfSections.UpdateWordDescription();
        switch (PlayerPrefs.GetString("numberOfLettersFlag"))
        {
            case "false":
                PlayerPrefs.SetString("numberOfLettersFlag", "true");
                break;
            case "true":
                PlayerPrefs.SetString("numberOfLettersFlag", "false");
                break;
        }
    }
    public static void FirstLetterButton()
    {
        Hints_script.firstLetterFlag = !Hints_script.firstLetterFlag;
        ListOfSections.UpdateWordDescription();
        switch (PlayerPrefs.GetString("firstLetterFlag"))
        {
            case "false":
                PlayerPrefs.SetString("firstLetterFlag", "true");
                break;
            case "true":
                PlayerPrefs.SetString("firstLetterFlag", "false");
                break;
        }
    }
    public static void LastLetterButton()
    {
        Hints_script.lastLetterFlag = !Hints_script.lastLetterFlag;
        ListOfSections.UpdateWordDescription();
        switch (PlayerPrefs.GetString("lastLetterFlag"))
        {
            case "false":
                PlayerPrefs.SetString("lastLetterFlag", "true");
                break;
            case "true":
                PlayerPrefs.SetString("lastLetterFlag", "false");
                break;
        }
    }
    public static void WrongAnswersButton()
    {
        Hints_script.wrongAnswersFlag = !Hints_script.wrongAnswersFlag;
        ListOfSections.UpdateWordDescription();
        switch (PlayerPrefs.GetString("wrongAnswersFlag"))
        {
            case "false":
                PlayerPrefs.SetString("wrongAnswersFlag", "true");
                break;
            case "true":
                PlayerPrefs.SetString("wrongAnswersFlag", "false");
                break;
        }
    }
    public void SectionsBlocker()
    {
        switch (WordsCounters.SelectedSection)
        {
            case "Animals":
                if (PlayerPrefs.GetInt("AnimalsCount") == WordsCounters.animalsFull)
                {
                    CanvasGroup temp = WordsAndDescriptions.listOfAnimals.GetComponent<CanvasGroup>();
                    temp.blocksRaycasts = false;
                }
                break;

            case "Archeology":
                if (PlayerPrefs.GetInt("ArcheologyCount") == WordsCounters.archeologyFull)
                {
                    CanvasGroup temp = WordsAndDescriptions.listOfArcheology.GetComponent<CanvasGroup>();
                    temp.blocksRaycasts = false;
                }
                break;
            case "Architecture":
                if (PlayerPrefs.GetInt("ArchitectureCount") == WordsCounters.architectureFull)
                {
                    CanvasGroup temp = WordsAndDescriptions.listOfArchitecture.GetComponent<CanvasGroup>();
                    temp.blocksRaycasts = false;
                }
                break;
            case "Cinema":
                if (PlayerPrefs.GetInt("CinemaCount") == WordsCounters.cinemaFull)
                {
                    CanvasGroup temp = WordsAndDescriptions.listOfCinema.GetComponent<CanvasGroup>();
                    temp.blocksRaycasts = false;
                }
                break;
            case "Food":
                if (PlayerPrefs.GetInt("FoodCount") == WordsCounters.foodFull)
                {
                    CanvasGroup temp = WordsAndDescriptions.listOfFood.GetComponent<CanvasGroup>();
                    temp.blocksRaycasts = false;
                }
                break;
            case "Games":
                if (PlayerPrefs.GetInt("GamesCount") == WordsCounters.gamesFull)
                {
                    CanvasGroup temp = WordsAndDescriptions.listOfGames.GetComponent<CanvasGroup>();
                    temp.blocksRaycasts = false;
                }
                break;
            case "MiddleAges":
                if (PlayerPrefs.GetInt("MiddleAgesCount") == WordsCounters.middleAgesFull)
                {
                    CanvasGroup temp = WordsAndDescriptions.listOfMiddleAges.GetComponent<CanvasGroup>();
                    temp.blocksRaycasts = false;
                }
                break;
            case "Plants":
                if (PlayerPrefs.GetInt("PlantsCount") == WordsCounters.plantsFull)
                {
                    CanvasGroup temp = WordsAndDescriptions.listOfPlants.GetComponent<CanvasGroup>();
                    temp.blocksRaycasts = false;
                }
                break;
        }
    }
}
