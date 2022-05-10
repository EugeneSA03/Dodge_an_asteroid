using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAd : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string gameId = "4746203";
    [SerializeField] private bool testMode = true;

    public void OnInitializationComplete() {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message) {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds() {
        Advertisement.Initialize(gameId, testMode);
    }
}
