using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAd ad;

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
            SpawnerScript.ResetAsteroids();
            GlobalEventManager.OnGameStatusChanged.Invoke(1);

            Advertisement.Load(unitId, this);
        }
    }
}
