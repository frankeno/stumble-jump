using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
 
public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener {


    //// CHANGE THE UNITY AD IDs BELOW WITH THE ONES YOU CREATED IN YOUR UNITY PORTAL /////////
    
    public static string _androidGameId = "5206339";
    public static string _iOSGameId = "5206338";

    ///////////////////////////////////////////////////////////////////////////////////////////

    public static bool _testMode = false;
    private string _gameId;
    
    
    void Awake()
    {
        InitializeAds();
    }
 
    public void InitializeAds(){
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
        print("_gameId: " + _gameId);
    }
 
    public void OnInitializationComplete()
    {
        print("Unity Ads initialization complete");
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
