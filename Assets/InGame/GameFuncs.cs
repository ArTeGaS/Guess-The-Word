using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFuncs : MonoBehaviour
{
    public void OnEnterPress()
    {
        if (MainGameScript.inputFieldText.text == WordsAndDescriptionriptions.listOfWords[WordsAndDescriptionriptions.currentWord])
        {
            StartCoroutine(CongratsEvent());
        }
    }
    public IEnumerator CongratsEvent()
    {
        PlayerPrefs.SetInt(WordsCounters.SelectedSection + "Count", PlayerPrefs.GetInt(WordsCounters.SelectedSection) + 1);
        MainGameScript.inGameCanvasGroup.blocksRaycasts = false;
        ListOfSections.HideWordDescriprion();
        MainGameScript.congratsText.SetActive(true);
        WordsAndDescriptionriptions.listOfWords.RemoveAt(WordsAndDescriptionriptions.currentWord);
        WordsAndDescriptionriptions.listOfWordsParallel.RemoveAt(WordsAndDescriptionriptions.currentWord);
        WordsAndDescriptionriptions.listOfDiscriptions.RemoveAt(WordsAndDescriptionriptions.currentWord);
        WordsAndDescriptionriptions.listOfDiscriptionsParallel.RemoveAt(WordsAndDescriptionriptions.currentWord);
        ListOfSections.SaveProgress();
        yield return new WaitForSeconds(2f);
        switch (ListOfSections.CalculateAllWords())
        {
            case > 0:
                MainGameScript.congratsText.SetActive(false);
                ListOfSections.UpdateWordDescription();
                MainGameScript.inGameCanvasGroup.blocksRaycasts = true;
                break;
            case 0:
                BackToSections();
                break;
        }
        
    }
    public void NextWordButton()
    {
        switch (WordsAndDescriptionriptions.currentWord)
        {
            case int n when n < ListOfSections.CalculateAllWords() - 1:
                WordsAndDescriptionriptions.currentWord++;
                break;
            case int n when n <= ListOfSections.CalculateAllWords() -1:
                WordsAndDescriptionriptions.currentWord = 0;
                break;
        }
        ListOfSections.UpdateWordDescription();
    }
    public void BackWordButton()
    {
        switch (WordsAndDescriptionriptions.currentWord)
        {
            case > 0:
                WordsAndDescriptionriptions.currentWord--;
                break;
            case <= 0:
                WordsAndDescriptionriptions.currentWord = ListOfSections.CalculateAllWords() -1;
                break;
        }
        ListOfSections.UpdateWordDescription();
    }
    public void BackToSections()
    {
        ListOfSections.CountersUpdate();
        ListOfSections.ListsUpdate();
        ListOfSections.SaveProgress();

        MainGameScript.sectionsWindow.SetActive(true);

        MainGameScript.gameWindow.SetActive(false);
    }
}
