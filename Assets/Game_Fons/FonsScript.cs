using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class FonsScript : MonoBehaviour
{
    public Sprite fonAsset_1;
    public Sprite fonAsset_2;
    public Sprite fonAsset_3;
    public Sprite fonAsset_4;
    public Sprite fonAsset_5;
    public Sprite fonAsset_6;
    public Sprite fonAsset_7;
    public Sprite fonAsset_8;
    public Sprite fonAsset_9;

    private List<Sprite> fonAssetsList;

    public GameObject gameFon;
    private int currentFon;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CurrentFon"))
        {
            PlayerPrefs.SetInt("CurrentFon", 0);
        }
        currentFon = PlayerPrefs.GetInt("CurrentFon");

        //fonAsset_1 = LoadSprite("fon_1");
        //fonAsset_2 = LoadSprite("fon_2");
        //fonAsset_3 = LoadSprite("fon_3");
        //fonAsset_4 = LoadSprite("fon_4");
        //fonAsset_5 = LoadSprite("fon_5");
        //fonAsset_6 = LoadSprite("fon_6");
        //fonAsset_7 = LoadSprite("fon_7");
        //fonAsset_8 = LoadSprite("fon_8");
        //fonAsset_9 = LoadSprite("fon_9");

        fonAssetsList = new List<Sprite> 
        {
            fonAsset_1,
            fonAsset_2,
            fonAsset_3,
            fonAsset_4,
            fonAsset_5,
            fonAsset_6,
            fonAsset_7,
            fonAsset_8,
            fonAsset_9
        };

        gameFon.GetComponent<Image>().sprite = fonAssetsList[currentFon];
    }

    public Sprite LoadSprite(string spriteAddress)
    {
        // Завантаження спрайта за його адресою
        AsyncOperationHandle<Sprite> spriteHandle = Addressables.LoadAssetAsync<Sprite>(spriteAddress);

        spriteHandle.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Sprite sprite = handle.Result;
                // Використовуйте sprite зараз
            }
            else
            {
                Debug.LogError("Failed to load sprite: " + handle.OperationException);
            }

            // Звільніть ресурс після використання, якщо це потрібно
            Addressables.Release(spriteHandle);
        };
        return spriteHandle.Result;
    }

    public void NextFon()
    {
        switch (currentFon)
        {
            case <= 7:
                currentFon++;
                PlayerPrefs.SetInt("CurrentFon", currentFon);
                gameFon.GetComponent<Image>().sprite = fonAssetsList[currentFon];
                break;
        }
    }
    public void PrevFon()
    {
        switch (currentFon)
        {
            case >=1:
                currentFon--;
                PlayerPrefs.SetInt("CurrentFon", currentFon);
                gameFon.GetComponent<Image>().sprite = fonAssetsList[currentFon];
                break;
        }
    }
}
