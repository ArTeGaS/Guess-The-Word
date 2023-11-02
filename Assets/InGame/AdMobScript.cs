using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{
    public string appId = "ca-app-pub-3227481332211386~5221961576";

    public static string bannerId = "ca-app-pub-3227481332211386/9296937953";

    public static AdSize adSize = AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

    public static BannerView bannerView;

    public static int textMod = 125;

    public static Coroutine adCoroutine;

    // Ads Flag
    public static bool adsLoaded = false;


    private void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus =>{

            Debug.Log("Ads Done!");
        });
    }

    public static void LoadBannerAds()
    {
        CreateBannerViev();

        ListenToBannerEvents();

        if (bannerView == null) 
        {
            CreateBannerViev();
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        Debug.Log("Loading banner");
        bannerView.LoadAd(adRequest);
    }
    public static void CreateBannerViev()
    {
        if (bannerView != null)
        {
            DestroyBannerAds();
        }
        bannerView = new BannerView(bannerId, adSize, AdPosition.Top);

        switch ((float)Screen.width / (float)Screen.height)
        {
            case > 0.6f:
                textMod = 125;
                break;
            case > 0.51f:
                textMod = 145;
                break;
            case > 0.49f:
                textMod = 165;
                break;
            case > 0.44f:
                textMod = 185;
                break;
        }

        MainGameScript.textMeshProS.margin = new Vector4(
            MainGameScript.textMeshProS.margin.x,
            textMod,
            MainGameScript.textMeshProS.margin.z,
            MainGameScript.textMeshProS.margin.w);
    }
    public static void ListenToBannerEvents()
    {
        // Raised when an ad is loaded into the banner view.
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Banner view paid {0} {1}." +
                adValue.Value +
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }
    public static void DestroyBannerAds()
    {
        if (bannerView != null)
        {
            Debug.Log("Destroying banner Ad");
            bannerView.Destroy();
            bannerView = null;

            MainGameScript.textMeshProS.margin = new Vector4(
            MainGameScript.textMeshProS.margin.x,
            25,
            MainGameScript.textMeshProS.margin.z,
            MainGameScript.textMeshProS.margin.w);
        }
    }
}
