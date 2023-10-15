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
                        congratsTextObj,
                        naviFrameObj;

    public static GameObject ingameBack,
                                ingameNext,
                                ingameHints,
                                ingameSection,
                                ingameText,
                                ingameInputField,
                                congratsText,
                                naviFrame;

    public CanvasGroup inGameCanvasGroupObj;
    public static CanvasGroup inGameCanvasGroup;

    // ListsNavigation
    public GameObject fromListToMenuObj,
                        listsUpObj,
                        listsDownObj;

    public static GameObject fromListToMenu,
                                listsUp,
                                listsDown;

    //Lists position etalons
    public GameObject posE_1_Obj
                    , posE_2_Obj
                    , posE_3_Obj
                    , posE_4_Obj;

    public static GameObject posE_1
                            , posE_2
                            , posE_3
                            , posE_4;

    // TMP objects
    public TMP_InputField inputFieldTextObj;
    public static TMP_InputField inputFieldText;

    //Canvas pos correctors
    public RectTransform myCanvas;
    public RectTransform settingsFolder;
    public RectTransform inGameButtonsAndOther;
    public RectTransform listOfGameCatefories;

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

        naviFrame = naviFrameObj;

        inGameCanvasGroup = inGameCanvasGroupObj;

        // TMP objects
        inputFieldText = inputFieldTextObj;

        // ListsNavigation

        fromListToMenu = fromListToMenuObj;
        listsUp = listsUpObj;
        listsDown = listsDownObj;

        //Lists position etalons
        posE_1 = posE_1_Obj;
        posE_2 = posE_2_Obj;
        posE_3 = posE_3_Obj;
        posE_4 = posE_4_Obj;

        // Canvas pos correctors
        settingsFolder.sizeDelta = new Vector2(myCanvas.rect.width, myCanvas.rect.height);
        inGameButtonsAndOther.sizeDelta = new Vector2(myCanvas.rect.width, myCanvas.rect.height);
        listOfGameCatefories.sizeDelta = new Vector2(myCanvas.rect.width, myCanvas.rect.height);

    }
}
