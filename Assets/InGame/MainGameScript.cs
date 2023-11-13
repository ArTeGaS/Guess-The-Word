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
                        ingameTextFonObj,
                        ingameInputFieldObj,
                        congratsTextObj,
                        naviFrameObj;

    public static GameObject ingameBack,
                                ingameNext,
                                ingameHints,
                                ingameSection,
                                ingameText,
                                ingameTextFon,
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

    // Game windows
    public GameObject mainMenuObj,
                        insideSettingsMenuObj,
                        sectionsWindowObj,
                        gameWindowObj,
                        hintsWindowObj;

    public static GameObject mainMenu,
                        insideSettingsMenu,
                        sectionsWindow,
                        gameWindow,
                        hintsWindow;

    public TextMeshProUGUI hintsText;
    public static TextMeshProUGUI hintsTextPub;

    public TextMeshProUGUI sectionsText;
    public static TextMeshProUGUI sectionsTextPub;

    private void Start()
    {
        // Main text window
        textMeshProS = textMeshPro;

        // Game objects
        ingameBack =  ingameBackObj;
        ingameNext = ingameNextObj;
        ingameHints = ingameHintsObj;
        ingameSection = ingameSectionObj;
        ingameText = ingameTextObj;
        ingameTextFon = ingameTextFonObj;
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

        // Lists position etalons
        posE_1 = posE_1_Obj;
        posE_2 = posE_2_Obj;
        posE_3 = posE_3_Obj;
        posE_4 = posE_4_Obj;

        // Game windows
        mainMenu = mainMenuObj;
        insideSettingsMenu = insideSettingsMenuObj;
        sectionsWindow = sectionsWindowObj;
        gameWindow = gameWindowObj;
        hintsWindow = hintsWindowObj;

        hintsTextPub = hintsText;
        sectionsTextPub = sectionsText;
    }
}
