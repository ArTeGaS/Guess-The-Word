using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Посилання на об'єкт TextMeshPro, де ви відображаєте текст.
    public static int currentPage = 1; // Поточна сторінка тексту.

    public static TextMeshProUGUI textMeshProS;
    public static int totalPages;

    private Dictionary<string, string> animals;

    private void Start()
    {
        textMeshProS = textMeshPro;
        //Debug.Log(PlayerPrefs.GetString("PlayerLang"));
        switch (PlayerPrefs.GetString("PlayerLang"))
        {
            case "en-US":
                animals = JSON_Control.LoadJsonFile("Animals_us");
                Debug.Log(animals["ZebraD"]);
                break;
            case "uk-UA":
                animals = JSON_Control.LoadJsonFile("Animals_ua");
                Debug.Log(animals["ZebraD"]);
                break;
        }
        //JSON_Control.JsonRestruct();
    }

    public static void CalculateTotalPages()
    {
        totalPages = textMeshProS.textInfo.pageCount;
    }

    public static void NextPage()
    {
        CalculateTotalPages();
        if (currentPage <= totalPages)
        {
            currentPage = totalPages;
            textMeshProS.pageToDisplay = currentPage;
        }
        else
        {
            currentPage++;
            textMeshProS.pageToDisplay = currentPage;
        }
    }

    public static void PreviousPage()
    {
        CalculateTotalPages();
        switch (currentPage){
            case <= 1:
                currentPage = 1;
                textMeshProS.pageToDisplay = currentPage;
                break;
            case > 1:
                currentPage--;
                textMeshProS.pageToDisplay = currentPage;
                break;
        }
    }
}
