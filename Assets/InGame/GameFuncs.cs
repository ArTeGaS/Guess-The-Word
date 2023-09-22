using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFuncs : MonoBehaviour
{
    public void OnEnterPress()
    {
        if (MainGameScript.inputFieldText.text == WordsAndDescriptionriptions.listOfWords[WordsAndDescriptionriptions.currentWord])
        {
            Debug.Log(MainGameScript.inputFieldText.text);
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
        ListOfSections.FromGameToList();
        MainGameScript.listOfAnimals.SetActive(true);

        MainGameScript.fromListToMenu.SetActive(true);

        MainGameScript.ingameBack.SetActive(false);
        MainGameScript.ingameNext.SetActive(false);
        MainGameScript.ingameHints.SetActive(false);
        MainGameScript.ingameSection.SetActive(false);
        MainGameScript.ingameText.SetActive(false);
        MainGameScript.ingameInputField.SetActive(false);
    }
}
