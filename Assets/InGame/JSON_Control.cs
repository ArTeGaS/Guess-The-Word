using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

public class JSON_Control : MonoBehaviour
{
    public static string localizationPath = "Assets/InGame/CustomTables/Upd";
    public static string localOldPath = "Assets/InGame/CustomTables/Old";
    public static string localTempPath = "Assets/InGame/CustomTables/Temp";

    public static TextAsset _cachedObject;

    public static Dictionary<string, string> LoadJsonFile(string fileName, string locPath= "Assets/InGame/CustomTables/Upd")
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        string filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");

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
    public static async Task<Dictionary<string, string>> LoadJsonFileNew(string assetId)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        //string folderPath = Path.Combine(Application.persistentDataPath, "/Saves/Tables");
        //Directory.CreateDirectory(folderPath);

        var handle = Addressables.LoadAssetAsync<TextAsset>(assetId);
        _cachedObject = await handle.Task;
        if (_cachedObject == null)
        {
            Debug.LogError("Failed to load the object from Addressables.");
            return null; // Або виконайте іншу логіку обробки помилки
        }
        string component = _cachedObject.text;

        data = JsonConvert.DeserializeObject<Dictionary<string, string>>(component);

        return data;
    }

    public static void SaveJsonFile(string fileName, Dictionary<string, string> data, string locPath= "Assets/InGame/CustomTables/Upd")
    {
        string jsonText = JsonConvert.SerializeObject(data, Formatting.Indented);

        string filePath = Path.Combine(locPath, fileName + ".json");
        File.WriteAllText(filePath, jsonText);
    }

    public static void SaveJsonFileNew(string fileName, Dictionary<string, string> data, string locPath)
    {
        string jsonText = JsonConvert.SerializeObject(data, Formatting.Indented);

        string filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        File.WriteAllText(filePath, jsonText);
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
