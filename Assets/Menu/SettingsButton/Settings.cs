using UnityEngine;
using UnityEngine.Localization.Settings;

public class Settings : MonoBehaviour
{
    public void SettingsGameButton()
    {
        MainGameScript.mainMenu.SetActive(false);
        MainGameScript.insideSettingsMenu.SetActive(true);
    }
    public void ResetGameProgressButton()
    {
        MainGameScript.insideSettingsMenu.SetActive(false);
        MenuMainScript.yesNoReset.SetActive(true);
    }
    public void ChangeLanguage()
    {
        switch (PlayerPrefs.GetString("PlayerLang"))
        {
            case "en-US":
                PlayerPrefs.SetString("PlayerLang", "uk-UA");
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
                break;
            case "uk-UA":
                PlayerPrefs.SetString("PlayerLang", "en-US");
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                break;
        }
    }
    public void BackToMenu()
    {
        MainGameScript.mainMenu.SetActive(true);
        MainGameScript.insideSettingsMenu.SetActive(false);
    }
}
