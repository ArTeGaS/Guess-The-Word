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
}
