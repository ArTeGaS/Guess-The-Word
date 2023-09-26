using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameScript : MonoBehaviour
{
    // Main text window
    public TextMeshProUGUI textMeshPro; // Посилання на об'єкт TextMeshPro, де ви відображаєте текст.
    public static int currentPage = 1; // Поточна сторінка тексту.

    public static TextMeshProUGUI textMeshProS;
    public static int totalPages;

    // Game objects
    public GameObject ingameBackObj,
                        ingameNextObj,
                        ingameHintsObj,
                        ingameSectionObj,
                        ingameTextObj,
                        ingameInputFieldObj,
                        congratsTextObj;

    public static GameObject ingameBack,
                                ingameNext,
                                ingameHints,
                                ingameSection,
                                ingameText,
                                ingameInputField,
                                congratsText;

    public CanvasGroup inGameCanvasGroupObj;
    public static CanvasGroup inGameCanvasGroup;

    // Lists of Categoty
    public GameObject listOfAnimalsObj;
    public static GameObject listOfAnimals;

    public GameObject fromListToMenuObj;
    public static GameObject fromListToMenu;

    // TMP objects
    public TMP_InputField inputFieldTextObj;
    public static TMP_InputField inputFieldText;

    //Canvas pos correctors
    public RectTransform myCanvas;
    public RectTransform settingsFolder;
    public RectTransform inGameButtonsAndOther;

    private void Start()
    {
        // Main text window
        textMeshProS = textMeshPro;

        // Game objects
        ingameBack = ingameBackObj;
        ingameNext = ingameNextObj;
        ingameHints = ingameHintsObj;
        ingameSection = ingameSectionObj;
        ingameText = ingameTextObj;
        ingameInputField = ingameInputFieldObj;
        congratsText = congratsTextObj;

        inGameCanvasGroup = inGameCanvasGroupObj;

        // TMP objects
        inputFieldText = inputFieldTextObj;

        // Lists of Categoty
        listOfAnimals = listOfAnimalsObj;

        fromListToMenu = fromListToMenuObj;

        // Canvas pos correctors
        settingsFolder.sizeDelta = new Vector2(myCanvas.rect.width, myCanvas.rect.height);
        inGameButtonsAndOther.sizeDelta = new Vector2(myCanvas.rect.width, myCanvas.rect.height);
    }
}
