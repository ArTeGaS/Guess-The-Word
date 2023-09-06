using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class JSON_Control : MonoBehaviour
{
    public static string localizationPath = "Assets/Localizations/CustomTables/";

    public static Dictionary<string, string> LoadJsonFile(string fileName)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        string filePath = Path.Combine(localizationPath, fileName + ".json");

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

    public static void SaveJsonFile(string fileName, Dictionary<string, string> data)
    {
        string jsonText = JsonConvert.SerializeObject(data, Formatting.Indented);

        string filePath = Path.Combine(localizationPath, fileName + ".json");
        File.WriteAllText(filePath, jsonText);

        Debug.Log("File saved: " + filePath);
    }
}
