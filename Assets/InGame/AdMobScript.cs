using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobScript : MonoBehaviour
{
    public string appId = "";

    public static string bannerId = "ca-app-pub-3940256099942544/6300978111";
    public static string interId = "ca-app-pub-3940256099942544/1033173712";
    public static string rewardedId = "ca-app-pub-3940256099942544/5224354917";

    public static AdSize adSize = AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

    public static BannerView bannerView;
    public static InterstitialAd interstitialAd;
    public static RewardedAd rewardedAd;

    public static int textMod = 125;

    public static Coroutine adCoroutine;

    public static bool inGameFlag = false;

    // Ads Flag
    public static bool adsLoaded = false;


    private void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        MobileAds.Initialize(initStatus =>{

            Debug.Log("Ads Done!");
        });
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
        }
    }
    public void GameTextModAdd()
    {
        MainGameScript.textMeshProS.margin = new Vector4(
            MainGameScript.textMeshProS.margin.x,
            textMod,
            MainGameScript.textMeshProS.margin.z,
            MainGameScript.textMeshProS.margin.w);

        inGameFlag = true;
    }

    public void InGameFlagDisable() { inGameFlag = false; }
    public static void HintsModAdd()
    {
        MainGameScript.hintsTextPub.margin = new Vector4(
            MainGameScript.hintsTextPub.margin.x,
            textMod,
            MainGameScript.hintsTextPub.margin.z,
            MainGameScript.hintsTextPub.margin.w);
    }
    public void SectionsModAdd()
    {
        MainGameScript.sectionsTextPub.margin = new Vector4(
            MainGameScript.sectionsTextPub.margin.x,
            textMod,
            MainGameScript.sectionsTextPub.margin.z,
            MainGameScript.sectionsTextPub.margin.w);
    }
    #region extra
    public static void UnlockHints(int unlocker)
    {
        switch (PlayerPrefs.HasKey(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]))
        {
            case false:
                PlayerPrefs.SetInt(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord], 0);
                break;
        }
        int checker = PlayerPrefs.GetInt(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord]);
        checker += unlocker;
        PlayerPrefs.SetInt(WordsAndDescriptions.listOfWords[WordsAndDescriptions.currentWord], checker);
    }
    #endregion

    #region Interstitial

    public static void LoadInterstitialAd()
    {
        UnlockHints(1);
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        InterstitialAd.Load(interId, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if(error != null||ad == null)
            {
                Debug.Log("inter load fail");
            }
            interstitialAd = ad;
            InterstitialEvent(interstitialAd);
            ShowInterstitialAd();
        });
    }
    public static void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            Debug.Log("inter ad not ready");
        }
    }
    public static void InterstitialEvent(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Interstitial ad paid {0} {1}."+
                adValue.Value+
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }
    #endregion
    #region Rewarded
    public static void LoadRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        RewardedAd.Load(rewardedId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.Log("rewarded ad load error");
                return;
            }
            Debug.Log("rewarded ad loaded");
            rewardedAd = ad;
            RewardedAdEvents(rewardedAd);
        });
    }
    public static void ShowRewardedAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("give reward");

                UnlockHints(1);
            });
        }
    }
    public static void RewardedAdEvents(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Rewarded ad paid {0} {1}."+
                adValue.Value+
                adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }
    #endregion
}
