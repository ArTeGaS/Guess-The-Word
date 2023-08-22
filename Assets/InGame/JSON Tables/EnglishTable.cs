using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnglishTable : MonoBehaviour
{
    static void Start()
    {
        var engishTable = File.Exists("englishTable.json") ? JsonConvert.DeserializeObject<WordsAndDescriptionriptions>(File.ReadAllText("englishTable.json")) : new WordsAndDescriptionriptions
        {
            id = "Pear",
            word = "Pear",
            discriptions = "A type of fruit that is typically red or green and has a curved shape, but it's not what most people would think of first."
        };

        File.WriteAllText("engishTable.json", JsonConvert.SerializeObject(engishTable));
    }
}
