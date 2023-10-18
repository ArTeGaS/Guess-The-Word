using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsAndDescriptionriptions : MonoBehaviour
{
    public static Dictionary<string, string> tempDict;
    public static List<string> listOfWords;
    public static List<string> listOfDiscriptions;

    public static Dictionary<string, string> tempDictParallel;
    public static List<string> listOfWordsParallel;
    public static List<string> listOfDiscriptionsParallel;

    public static string currentLoadedListName;
    public static string parallelLoadedListName;

    public static string targetLang;
    public static string anotherLang;

    public static int currentWord = 0;
    public static int wordsCount;

    // Lists of Categoty
    public GameObject listOfAnimalsObj,
                        listOfArcheologyObj,
                        listOfArchitectureObj,
                        listOfCinemaObj,
                        listOfFoodObj,
                        listOfGamesObj,
                        listOfMiddleAgesObj,
                        listOfPlantsObj;

    public static GameObject listOfAnimals,
                                listOfArcheology,
                                listOfArchitecture,
                                listOfCinema,
                                listOfFood,
                                listOfGames,
                                listOfMiddleAges,
                                listOfPlants;

    public static List<string> listsFlags =
        new List<string> { "AnimalsListFirstRunFlag",
                            "ArcheologyListFirstRunFlag",
                            "ArchitectureListFirstRunFlag",
                            "CinemaListFirstRunFlag",
                            "FoodListFirstRunFlag",
                            "GamesListFirstRunFlag",
                            "MiddleAgesListFirstRunFlag",
                            "PlantsListFirstRunFlag"};
    public static List<GameObject> listOfCategories;

    public void Start()
    {
        foreach (string key in listsFlags)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetInt(key, 0);
            }
        }

        // Lists of Categoty
        listOfAnimals = listOfAnimalsObj;
        listOfArcheology = listOfArcheologyObj;
        listOfArchitecture = listOfArchitectureObj;
        listOfCinema = listOfCinemaObj;
        listOfFood = listOfFoodObj;
        listOfGames = listOfGamesObj;
        listOfMiddleAges = listOfMiddleAgesObj;
        listOfPlants = listOfPlantsObj;

        listOfCategories =
            new List<GameObject> { listOfAnimals,
                                    listOfArcheology,
                                    listOfArchitecture,
                                    listOfCinema,
                                    listOfFood,
                                    listOfGames,
                                    listOfMiddleAges,
                                    listOfPlants};
    }
}

