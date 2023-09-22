using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameScript : MonoBehaviour
{
    // Main text window
    public TextMeshProUGUI textMeshPro; // ��������� �� ��'��� TextMeshPro, �� �� ���������� �����.
    public static int currentPage = 1; // ������� ������� ������.

    public static TextMeshProUGUI textMeshProS;
    public static int totalPages;

    // Game objects
    public GameObject ingameBackObj,
                        ingameNextObj,
                        ingameHintsObj,
                        ingameSectionObj,
                        ingameTextObj,
                        ingameInputFieldObj;
    
    public static GameObject ingameBack,
                                ingameNext,
                                ingameHints,
                                ingameSection,
                                ingameText,
                                ingameInputField;

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

        // TMP objects
        inputFieldText = inputFieldTextObj;

        // Lists of Categoty
        listOfAnimals = listOfAnimalsObj;

        fromListToMenu = fromListToMenuObj;

        // Canvas pos correctors
        settingsFolder.sizeDelta = new Vector2(myCanvas.rect.width, myCanvas.rect.height);
    }
}
