using System.IO;
using UnityEngine;

public class YesNoScript : MonoBehaviour
{
    public async void YesReturnButton()
    {
        foreach (var tempList in WordsAndDescriptions.listsFlags)
        {
            PlayerPrefs.SetInt(tempList, 0);
        }
        foreach (var counterName in WordsCounters.countersData)
        {
            PlayerPrefs.SetInt(counterName, 0);
        }
        File.Delete(Path.Combine(Application.persistentDataPath, "WrongAnswers.json"));
        WordsAndDescriptions.wrongAnswersDict = await JSON_Control.LoadAddressableJsonFile("WrongAnswers.json");
        MainGameScript.insideSettingsMenu.SetActive(true);
        MenuMainScript.yesNoReset.SetActive(false);
    }
    public void NoReturnButton()
    {
        MainGameScript.insideSettingsMenu.SetActive(true);
        MenuMainScript.yesNoReset.SetActive(false);
    }
}
