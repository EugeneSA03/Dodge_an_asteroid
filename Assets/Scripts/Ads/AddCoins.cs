using UnityEngine;
using UnityEngine.Advertisements;

public class AddCoins : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AddCoins ad;

    private string unitId = "Rewarded_Android";

    void Awake()
    {
        ad = this;
    }

    public void LoadAd() {
        Advertisement.Load(unitId, this);
    }

    public void ShowAd() {
        Advertisement.Show(unitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId) {
        //Debug.Log("Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) {
        //Debug.Log("Load failed");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {
        //Debug.Log("Show failed");
    }

    public void OnUnityAdsShowStart(string placementId) {
        //Debug.Log("Show started");
    }

    public void OnUnityAdsShowClick(string placementId) {
        //Debug.Log("Show clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) {

        if (placementId.Equals(unitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)) {
            PlayerPrefs.SetInt("Total coins", PlayerPrefs.GetInt("Total coins") + 50);
            GlobalEventManager.OnGameStatusChanged.Invoke(6);

            Advertisement.Load(unitId, this);
        }
    }
}
