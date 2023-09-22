using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class JSON_Control : MonoBehaviour
{
    public static string localizationPath = "Assets/InGame/CustomTables/Upd";
    public static string localOldPath = "Assets/InGame/CustomTables/Old";
    public static string localTempPath = "Assets/InGame/CustomTables/Temp";

    public static Dictionary<string, string> LoadJsonFile(string fileName, string locPath= "Assets/InGame/CustomTables/Upd")
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        string filePath = Path.Combine(locPath, fileName + ".json");

        if (File.Exists(filePath))
        {
            string jsonText = File.ReadAllText(filePath);
            data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }

        return data;
    }

    public static void SaveJsonFile(string fileName, Dictionary<string, string> data, string locPath= "Assets/InGame/CustomTables/Upd")
    {
        string jsonText = JsonConvert.SerializeObject(data, Formatting.Indented);

        string filePath = Path.Combine(locPath, fileName + ".json");
        File.WriteAllText(filePath, jsonText);

        Debug.Log("File saved: " + filePath);
    }
    public static void JsonRestruct(string dictOld, string dictNew)
    {
        Dictionary<string, string> dictOldCase = LoadJsonFile(dictOld);
        Dictionary<string, string> temp = new Dictionary<string, string> { };
        List<string> tempList = new List<string>();
        foreach (var pair in dictOldCase)
        {
            tempList.Add(pair.Value);
        }
        for (int i = 0; i < tempList.Count; i += 2)
        {
            temp.Add(tempList[i], tempList[i + 1]);
        }
        SaveJsonFile(dictNew, temp);
    }
}
