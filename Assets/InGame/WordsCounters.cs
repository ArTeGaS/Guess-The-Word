using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordsCounters : MonoBehaviour
{
    // Lists counters fields
    public TextMeshProUGUI animalsCounter,
                            archeologyCounter,
                            architectureCounter,
                            cinemaCounter,
                            foodCounter,
                            gamesCounter,
                            middleAgesCounter,
                            plantCounter;

    public static TextMeshProUGUI animalsCounterObj,
                            archeologyCounterObj,
                            architectureCounterObj,
                            cinemaCounterObj,
                            foodCounterObj,
                            gamesCounterObj,
                            middleAgesCounterObj,
                            plantCounterObj;

    public static List<string> countersData =
        new List<string> { "AnimalsCount",
                            "ArcheologyCount",
                            "ArchitectureCount",
                            "CinemaCount",
                            "FoodCount",
                            "GamesCount",
                            "MiddleAgesCount",
                            "PlantsCount"};
    public static int animalsFull = 43,
                            archeologyFull = 20,
                            architectureFull = 21,
                            cinemaFull = 25,
                            foodFull = 40,
                            gamesFull = 28,
                            middleAgesFull = 37,
                            plantsFull = 34;

    public static string SelectedSection;
    public void Start()
    {
        foreach (var counterName in countersData)
        {
            if (!PlayerPrefs.HasKey(counterName))
            {
                PlayerPrefs.SetInt(counterName, 0);
            }
        }

        animalsCounterObj = animalsCounter;
        archeologyCounterObj = archeologyCounter;
        architectureCounterObj = architectureCounter;
        cinemaCounterObj = cinemaCounter;
        foodCounterObj = foodCounter;
        gamesCounterObj = gamesCounter;
        middleAgesCounterObj = middleAgesCounter;
        plantCounterObj = plantCounter;
    }
}
