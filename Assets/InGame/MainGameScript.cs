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

    public GameObject ingameBackObj,
                    ingameNextObj,
                    ingameTextObj,
                    ingameInputFieldObj;

    public GameObject listOfAnimalsObj;

    public static GameObject ingameBack,
                            ingameNext,
                            ingameText,
                            ingameInputField;

    public static GameObject listOfAnimals;

    public TMP_InputField inputFieldTextObj;
    public static TMP_InputField inputFieldText;

    private void Start()
    {
        textMeshProS = textMeshPro;

        ingameBack = ingameBackObj;
        ingameNext = ingameNextObj;
        ingameText = ingameTextObj;
        ingameInputField = ingameInputFieldObj;

        inputFieldText = inputFieldTextObj;

        listOfAnimals = listOfAnimalsObj;
    }
}
