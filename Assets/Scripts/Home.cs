using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Advertisements;
#if UNITY_IOS
    using Unity.Advertisement.IosSupport;
#endif

[RequireComponent(typeof(AudioSource))]
public class Home : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener {
	string _interstitialAdUnitId = null; 

    public Button playButton;
    public Button moreGamesButton;
    public Button removeAdsButton;
    public Button restorePurchaseButton;
    public Button feedbackButton;
    public Button challengesButton;
    public Text lastDistanceTxt;
    public Text coinsTxt;
    public Text supportTxt;
    public GameObject prevButton;
    public GameObject nextButton;
    public int playerInt = 0;
    public GameObject[] players;
    public TMP_Text[] pPriceTxts;
    public int[] playersBought;
    int exits;
    Ray ray;
    RaycastHit hit;
    int bestDistance;
    int coins;
    int IAPmade = 0;
    int playerPrice;
    // Audio
    AudioSource audioSource;
    public AudioClip clickSND;

    public Image Alert;
    public Text alertTitleTxt;
    public Button alertOKButton;
    public Button alertCancelButton;

    // Set FrameRate
    private void Awake(){ 
        Application.targetFrameRate = 60;
        
        // Load IAPMade
        IAPmade = PlayerPrefs.GetInt("IAPmade", 0);
        print("IAPmade - HOME SCREEN: " +  IAPmade);
        if(IAPmade == 0) { removeAdsButton.gameObject.SetActive(true); restorePurchaseButton.gameObject.SetActive(true);
        } else {removeAdsButton.gameObject.SetActive(false); restorePurchaseButton.gameObject.SetActive(false); } 

        #if UNITY_IOS
            if(ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED) {
                ATTrackingStatusBinding.RequestAuthorizationTracking();
            }
            _interstitialAdUnitId = "Rewarded_iOS";

        #elif UNITY_ANDROID
            _interstitialAdUnitId = "Rewarded_Android";
        #endif

        LoadAd();

        // Check for interstitial Ad
        exits = PlayerPrefs.GetInt("exits", 0);
        if(exits == 3){
            PlayerPrefs.SetInt("exits", 0);
            if(IAPmade == 0){ showInterstitialAd(); }
        }
    }

    //-------------------------------------------
    // MARK - START
    //-------------------------------------------
    void Start(){

        //// TEST ////
            // PlayerPrefs.SetInt("IAPmade", 0);
            // PlayerPrefs.SetInt("totalCoins", 0);
            // for(int i=0;i<playersBought.Length;i++){ PlayerPrefs.SetInt("pb"+i.ToString(), 0); }
            // coins = 20000;
        /// TEST ////

        // Init audioSource
        audioSource = GetComponent<AudioSource>();

        // Set Texts
        playButton.GetComponentInChildren<Text>().text = Lang.playStr();
        removeAdsButton.GetComponentInChildren<Text>().text = Lang.purchaseStr();
        restorePurchaseButton.GetComponentInChildren<Text>().text = Lang.restorePurchaseStr();
        moreGamesButton.GetComponentInChildren<Text>().text = Lang.moreGamesStr();;
        alertCancelButton.GetComponentInChildren<Text>().text = Lang.cancelStr();;
        alertOKButton.GetComponentInChildren<Text>().text = Lang.buyStr();;
        feedbackButton.GetComponentInChildren<Text>().text = Lang.feedbackStr();;
        supportTxt.text = Lang.supportStr();;
        
        // Init Buttons
        playButton.onClick.AddListener(() => playButt());
        moreGamesButton.onClick.AddListener(() => moreGamesButt());
        alertOKButton.onClick.AddListener(() => alertOKButt());
        alertCancelButton.onClick.AddListener(() => alertCancelButt());
        feedbackButton.onClick.AddListener(() => feedbackButt());
        challengesButton.onClick.AddListener(() => challengesButt());

        // Load data
        bestDistance = PlayerPrefs.GetInt("bestDistance", 0);
        coins = PlayerPrefs.GetInt("totalCoins", 0);
        lastDistanceTxt.text = Lang.bestStr() + bestDistance.ToString(); 
        coinsTxt.text = coins.ToString(); 
        
        // Load selected player
        playerInt = PlayerPrefs.GetInt("player", 0);
        foreach(GameObject p in players){ p.SetActive(false); }

        for(int i=0;i<playersBought.Length;i++){ 
            playersBought[i] = PlayerPrefs.GetInt("pb"+i.ToString(), 0);
            playersBought[0] = 1;
            if(playersBought[i] == 1){ pPriceTxts[i].text = Lang.inUseStr(); }
        }
        players[playerInt].SetActive(true);

        #if UNITY_ANDROID
            restorePurchaseButton.gameObject.SetActive(false);    
        #endif

    } //./ Start()



    //-------------------------------------------
    // MARK - UPDATE 
    //-------------------------------------------
    void Update(){
        // Touch Down
        if (Input.GetMouseButtonDown(0)) {
            // PrevButton   
            if (prevButton == getClickedObject(out hit) ) {
                audioSource.PlayOneShot(clickSND, 1.0f);
                playerInt -= 1;
                if(playerInt < 0){ playerInt = 0; }
                foreach(GameObject p in players){ p.SetActive(false); }
                players[playerInt].SetActive(true);
                string price = pPriceTxts[playerInt].text;
                if(price == Lang.inUseStr()){ PlayerPrefs.SetInt("player", playerInt); }
            }

            // NextButton   
            if (nextButton == getClickedObject(out hit) ) {
                audioSource.PlayOneShot(clickSND, 1.0f);
                playerInt += 1;
                if(playerInt > players.Length-1){ playerInt = players.Length-1; }
                foreach(GameObject p in players){ p.SetActive(false); }
                players[playerInt].SetActive(true);
                string price = pPriceTxts[playerInt].text;
                if(price == Lang.inUseStr()){ PlayerPrefs.SetInt("player", playerInt); }
            }

            // [Players]
            for(int i=0; i<players.Length; i++){
                if (players[i] == getClickedObject (out hit) ) {
                    audioSource.PlayOneShot(clickSND, 1.0f);
                    playerPrice = Int32.Parse(pPriceTxts[i].text);
                    if(playerPrice == 0){ return; }

                    // Buy player
                    if(playerPrice < coins){
                        Alert.gameObject.SetActive(true);
                        alertTitleTxt.text = Lang.wantToBuyStr();
                        alertOKButton.gameObject.SetActive(true);

                    // NO enough coins to buy player
                    } else {
                        Alert.gameObject.SetActive(true);
                        alertTitleTxt.text = Lang.noEnoughCoinsStr();
                        alertOKButton.gameObject.SetActive(false);

                    }
                }
            } //./ For

        }// ./ Touch down
        
    }// ./ Update()

    void alertOKButt() {
        audioSource.PlayOneShot(clickSND, 1.0f);
        Alert.gameObject.SetActive(false);
        coins = coins - playerPrice;
        pPriceTxts[playerInt].text = Lang.inUseStr();
        PlayerPrefs.SetInt("totalCoins", coins);
        coinsTxt.text = coins.ToString(); 
        PlayerPrefs.SetInt("player", playerInt); 
        playersBought[playerInt] = 1;
        PlayerPrefs.SetInt("pb"+playerInt.ToString(), 1);
    }

    void alertCancelButt() {
        audioSource.PlayOneShot(clickSND, 1.0f);
        Alert.gameObject.SetActive(false);
    }


    //-------------------------------------------
    // MARK - PLAY BUTTON
    //-------------------------------------------
    void playButt() {
        audioSource.PlayOneShot(clickSND, 1.0f);
        StartCoroutine(changeScene(0.3f, "GameScene"));
    }

    void challengesButt() {
        audioSource.PlayOneShot(clickSND, 1.0f);
        StartCoroutine(changeScene(0.3f, "Challenges"));
    }

    //-------------------------------------------
    // MARK - CHANGE SCENE
    //-------------------------------------------
    IEnumerator changeScene(float time, string sceneName){ 
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

    //-------------------------------------------
    // MARK - MORE GAMES BUTTONS
    //-------------------------------------------
    void moreGamesButt() { 
        audioSource.PlayOneShot(clickSND, 1.0f);
        Application.OpenURL("https://your-website");
    }

    void feedbackButt() { 
        audioSource.PlayOneShot(clickSND, 1.0f);
        Application.OpenURL("https://your-game-landing-page");
    }

    //-------------------------------------------
    // MARK - GET CLICKED OBJECT
    //-------------------------------------------
    GameObject getClickedObject (out RaycastHit hit){
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) { target = hit.collider.gameObject; }
        return target;
    }

    //-------------------------------------------
    // SHOW INTERSTITIAL AD
    //-------------------------------------------
    public void showInterstitialAd() {
        Advertisement.Show(_interstitialAdUnitId, this);
    }

    //-------------------------------------------
    // MARK - UNITY ADS CALLBACKS
    //-------------------------------------------
    // Load content to the Ad Unit:
    public void LoadAd() {
        print("Unity Ads: Loading Ad: " + _interstitialAdUnitId);
        Advertisement.Load(_interstitialAdUnitId, this);
    }
 
    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId) {
        print("UnityAds: Ad Loaded: " + adUnitId);
    }
    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message) {
        print($"Unity Ads: Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.   
    }
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message) {
        print($"Unity Ads: Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }
    public void OnUnityAdsShowStart(string adUnitId) {}
    public void OnUnityAdsShowClick(string adUnitId) {}
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }

} // ./ end
