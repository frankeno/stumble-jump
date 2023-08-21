using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using Random = UnityEngine.Random;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class GameScene: MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener {
	
    string _adUnitId = null; 

	[Header("\n********* Level Objects/Variables *********\n")]
    public GameObject gameScene;
    public GameObject[] players;
    public ParticleSystem[] particles;
    public int playerInt;
    public Text stepsTxt;
    public Text coinsTxt;
    public GameObject[] obstaclesPrefabs;
    public GameObject[] spawnPoints;
    public Button homeButton;
    public Button pauseButton;
    public Image pauseView;
    public Button resumeButton;
    public Button exitButton;
    public Image gameOverView;
    public Text gameOverTxt;
    public Text wantToContinueTxt;
    public Text lastCoinsTxt;
    public Text lastDistanceTxt;
    public Text bestDistanceTxt;
    public Text pauseTxt;
    public Button goContinueButton;
    public Button watchAdButton;
    public Button goExitButton;
    public Image coinImg;
    int exits;
    int coinsCount = 0;
    int IAPmade;
    bool isTouchEnabled;
    int jumpInt = 0;
    int jumpsCount = 0;
    int stepsInt = 0;
    public bool isGameOver;
    public bool isGamePaused;
    float spawnSpeed = 0.3f;
    int totalCoins;
    int bestDistance;
    public GameObject bestTxtPrefab;
    public GameObject bestSpawnPoint;

    [Header("\n********* Challenges badge *********\n")]
    public int[] challengesMade;
    public Sprite[] chImages;
    public Image challengeBadge;
    public Image challengeIcon;
    public Text challengeTxt;

	[Header("\n********* Audio *********\n")]
	AudioSource audioSource;
	public AudioClip clickSND;
    public AudioClip click2SND;
    public AudioClip jumpSND;
    public AudioClip deathSND;
    public AudioClip coinSND;
    public AudioClip challengeSND;
    int musicOff;
    int soundOff;
	
    // Level standard stuff
	Ray ray;
    RaycastHit hit;
    
    [Header("\n********* Bkg Colors *********\n")]
    public Color[] colors;
    public float colorSpeed;
    float currentTime;
    public float cTime;
    int colorInt;

    [Header("\n********* Rate Alert *********\n")]
    public Image rateAlert;
    public Text raTitleTxt;
    public Text raMessageTxt;
    public Button raOKButton;
    public Button raCancelButton;
    string RateAppStoreURL = "";
    int rateAlertCount;

    //-------------------------------------------
    // MARK - AWAKE
    //-------------------------------------------
    void Awake() {   

        #if UNITY_IOS
            _adUnitId = "Rewarded_iOS";
            RateAppStoreURL = "https://apps.apple.com/app/idXXXXXXXXXX";
        #elif UNITY_ANDROID
            _adUnitId = "Rewarded_Android";
            RateAppStoreURL = "https://play.google.com/store/apps/details?id=com.yourname.gamename";
        #endif

        LoadAd();

        foreach(GameObject p in players){ p.SetActive(false); }
        playerInt = PlayerPrefs.GetInt("player", 0);
        players[playerInt].SetActive(true);

    }

    // Start is called before the first frame update
    void Start() {

        // Init audioSource
		audioSource = GetComponent<AudioSource>();
        musicOff = PlayerPrefs.GetInt("musicOff", 0);
        soundOff = PlayerPrefs.GetInt("soundOff", 0);
        if(musicOff == 1) { audioSource.Stop(); } else { audioSource.Play(); }
        
        // Load IAPmade --------------------
        IAPmade = PlayerPrefs.GetInt("IAPmade", 0);
        print("IAP MADE: " + IAPmade);

        // Load data
        totalCoins = PlayerPrefs.GetInt("totalCoins", 0);
        coinsTxt.text = coinsCount.ToString();

        // Load challenges
        for(int i=0;i<challengesMade.Length;i++){ challengesMade[i] = PlayerPrefs.GetInt("c"+i.ToString(), 0); }

        // Init buttons and Texts
        homeButton.onClick.AddListener(() => homeButt());
        resumeButton.onClick.AddListener(() => resumeButt());
        resumeButton.GetComponentInChildren<Text>().text = Lang.resumeStr();
        exitButton.onClick.AddListener(() => exitButt());
        exitButton.GetComponentInChildren<Text>().text = Lang.exitStr();
        goExitButton.onClick.AddListener(() => exitButt());
        goContinueButton.onClick.AddListener(() => goContinueButt());
        pauseButton.onClick.AddListener(() => pauseButt());
        watchAdButton.onClick.AddListener(() => showRewardAd());

        // Hide Watch Ad button
        if(IAPmade == 1){ watchAdButton.gameObject.SetActive(false); }

        pauseTxt.text = Lang.pausedStr();
        gameOverTxt.text = Lang.gameOverStr();

        // Rate Alert
        raTitleTxt.text = Lang.rateTitleStr();
        raMessageTxt.text = Lang.rateMessageStr();
        raOKButton.GetComponentInChildren<Text>().text = Lang.rateButtonStr();
        raOKButton.onClick.AddListener(() => rateButt());
        raCancelButton.GetComponentInChildren<Text>().text = Lang.maybeLaterStr();
        raCancelButton.onClick.AddListener(() => cancelButt());


        particles[playerInt].Play();
        gameScene.GetComponent<Animation>().Play("startAnim");

        StartCoroutine(enableTouch());

        startGame();
        
    } //./ Start()


    //-------------------------------------------
    // MARK - START GAME
    //-------------------------------------------
    void startGame() {
        StartCoroutine(spawnObjects(1.5f));
        StartCoroutine(updateSteps(0.3f));
        gameOverView.gameObject.SetActive(false);
        isGameOver = false;
    }


    //-------------------------------------------
     // MARK - SPAWN OBJECTS
     //------------------------------------------- 
    IEnumerator spawnObjects(float time){ 
        yield return new WaitForSeconds(time);

        int obsNr = Random.Range(0, 2);
        int spwNr = Random.Range(0, 2);
        if(!isGamePaused){    
            Instantiate(obstaclesPrefabs[obsNr], spawnPoints[spwNr].transform.position, obstaclesPrefabs[obsNr].transform.rotation);
            StartCoroutine(spawnObjects(spawnSpeed));
        }

    } 

    //-------------------------------------------
    // MARK - UPDATE STEPS
    //-------------------------------------------
    IEnumerator updateSteps(float time){ 
        yield return new WaitForSeconds(time);

        if(!isGamePaused){
            stepsInt += 1;
            stepsTxt.text = stepsInt.ToString();
            StartCoroutine(updateSteps(0.3f));

            if( stepsInt == (bestDistance-3) ){ Instantiate(bestTxtPrefab, bestSpawnPoint.transform.position, bestTxtPrefab.transform.rotation); }

            // Check challenges reached
            switch(stepsInt){
                case 10:
                    if(challengesMade[0] == 0){
                        challengeTxt.text = Lang.cTxt0();
                        showChallengeBadge(0);
                    }
                break;
                case 200:
                    if(challengesMade[1] == 0){
                        challengeTxt.text = Lang.cTxt1();
                        showChallengeBadge(1);
                    }
                break;
                case 500:
                    if(challengesMade[4] == 0){
                        challengeTxt.text = Lang.cTxt4();
                        showChallengeBadge(4);
                    }
                break;
                case 1000:
                    if(challengesMade[7] == 0){
                        challengeTxt.text = Lang.cTxt7();
                        showChallengeBadge(7);
                    }
                break;

            } // ./ swicth


        }// IF gamePause
    }

    //-------------------------------------------
    // MARK - UPDATE COINS
    //-------------------------------------------
    public void updateCoins() {
        if(!isGameOver){
            if(soundOff == 0) { audioSource.PlayOneShot(coinSND, 0.8f); }
            totalCoins += 1;
            coinsCount += 1;
            coinsTxt.text = coinsCount.ToString();
            coinImg.GetComponent<Animation>().Play("coinGot");

            switch(coinsCount){
                case 50:
                    if(challengesMade[2] == 0){
                        challengeTxt.text = Lang.cTxt2();
                        showChallengeBadge(2);
                    }
                break;
                case 200:
                    if(challengesMade[5] == 0){
                        challengeTxt.text = Lang.cTxt5();
                        showChallengeBadge(5);
                    }
                break;
                case 500:
                    if(challengesMade[8] == 0){
                        challengeTxt.text = Lang.cTxt8();
                        showChallengeBadge(8);
                    }
                break;
                case 1000:
                    if(challengesMade[10] == 0){
                        challengeTxt.text = Lang.cTxt10();
                        showChallengeBadge(10);
                    }
                break;
                

            }// ./ switch
        }
    }

    //-------------------------------------------
    // MARK - SHOW CHALLENGE BADGE AND SAVE
    //-------------------------------------------
    void showChallengeBadge(int challengeNr) {
        challengeIcon.sprite = chImages[challengeNr]; 
        PlayerPrefs.SetInt("c"+challengeNr.ToString(), 1);
        challengeBadge.GetComponent<Animation>().Play("challengeBadge");
        audioSource.PlayOneShot(challengeSND, 1.0f);
    }


    // Update is called once per frame
    void Update() {
		
    	//-------------------------------------------
    	// Touch Down
    	//-------------------------------------------
        if (Input.GetMouseButtonDown(0)) { if (EventSystem.current.IsPointerOverGameObject()) return;

            // JUMP!
            if(isTouchEnabled){
                if(soundOff == 0) { audioSource.PlayOneShot(jumpSND, 1.0f); }
                
                jumpsCount += 1;
                switch(jumpsCount){
                    case 50:
                        if(challengesMade[3] == 0){
                            challengeTxt.text = Lang.cTxt3();
                            showChallengeBadge(3);
                        }
                    break;
                    case 500:
                        if(challengesMade[9] == 0){
                            challengeTxt.text = Lang.cTxt9();
                            showChallengeBadge(9);
                        }
                    break;
                    case 1000:
                        if(challengesMade[11] == 0){
                            challengeTxt.text = Lang.cTxt11();
                            showChallengeBadge(11);
                        }
                    break;
                }// ./ switch

                jumpInt += 1;
                if(jumpInt == 2) { jumpInt = 0; }
                players[playerInt].GetComponent<Animation>().Play("jumpAnim"+jumpInt.ToString());
            }

        } // ./ Touch Down

        
        //-------------------------------------------
    	// Touch Up
    	//-------------------------------------------
        if (Input.GetMouseButtonUp (0)) {

            
		} //./ Touch Up

        changeColor();
        colorChangeTime();

    } //./ Update


    //-------------------------------------------
    // MARK - GAME OVER
    //-------------------------------------------
    public void gameOver() {
        if(soundOff == 0) { audioSource.PlayOneShot(deathSND, 1.0f); }
        bestDistance = PlayerPrefs.GetInt("bestDistance", 0);
        
        isGameOver = true;
        isGamePaused = true;
        isTouchEnabled = false;
        players[playerInt].GetComponent<Animation>().Play("deathAnim");
        StartCoroutine(showGameOverView());
        PlayerPrefs.SetInt("totalCoins", totalCoins);

        lastCoinsTxt.text = totalCoins.ToString();
        lastDistanceTxt.text = Lang.distanceStr() + stepsInt.ToString();
        bestDistanceTxt.text = Lang.bestStr() + bestDistance.ToString();

        if(bestDistance < stepsInt){ PlayerPrefs.SetInt("bestDistance", stepsInt);  }

        wantToContinueTxt.text = Lang.continueStr();

        // Show Rate Alert
        rateAlertCount += 1;
        if(rateAlertCount == 3){ rateAlert.gameObject.SetActive(true); rateAlertCount = 0; }
    }
    IEnumerator showGameOverView(){ 
        yield return new WaitForSeconds(1.0f);
        gameOverView.gameObject.SetActive(true);
    } 

    //-------------------------------------------
    // MARK - GO CONTINUE BUTTON
    //-------------------------------------------
    void goContinueButt(){
        if(totalCoins >= 50){
            totalCoins = totalCoins - 50;

            PlayerPrefs.SetInt("totalCoins", totalCoins);
            coinsTxt.text = coinsCount.ToString();

            resumeButt();
            players[playerInt].GetComponent<Animation>().Play("jumpAnim0");
            jumpInt = 0;
        } else {
            wantToContinueTxt.text = Lang.noEnoughCoinsStr2();
        }
    }


    //-------------------------------------------
    // MARK - EXIT BUTTON
    //-------------------------------------------
    void exitButt(){
        if(soundOff == 0) { audioSource.PlayOneShot(clickSND, 1.0f); }
        
        exits = PlayerPrefs.GetInt("exits", 0);
        exits += 1;
        print("exists: "+exits);
        PlayerPrefs.SetInt("exits", exits);
        StartCoroutine(changeScene(0.3f, "Home"));
    }

    //-------------------------------------------
    // MARK - PAUSE GAME BUTTON
    //-------------------------------------------
    void pauseButt(){
        if(soundOff == 0) { audioSource.PlayOneShot(clickSND, 1.0f); }
        isGamePaused = true;
        isTouchEnabled = false;
        players[playerInt].GetComponent<BoxCollider>().enabled = false;
        pauseView.gameObject.SetActive(true);
    }

    //-------------------------------------------
    // MARK - RESUME BUTTON
    //-------------------------------------------
    void resumeButt(){
        if(soundOff == 0) { audioSource.PlayOneShot(clickSND, 1.0f); }
        isGamePaused = false;
        isTouchEnabled = true;
        isGameOver = false;
        pauseView.gameObject.SetActive(false);
        gameOverView.gameObject.SetActive(false);
        StartCoroutine(spawnObjects(1.0f));
        StartCoroutine(updateSteps(0.5f));
        StartCoroutine(enablePlayerBoxCollider());
    }

    
    IEnumerator enablePlayerBoxCollider(){ 
        yield return new WaitForSeconds(1.0f);
        players[playerInt].GetComponent<BoxCollider>().enabled = true;
    } 

    //-------------------------------------------
    // MARK - HOME BUTTON
    //-------------------------------------------
    public void homeButt() { 
        audioSource.PlayOneShot(clickSND, 0.6f);
        StartCoroutine(changeScene(0.3f, "Home")); 
    }


    // Change Scene
    IEnumerator changeScene(float time, String sceneName){ 
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

    // Enable touch   
    IEnumerator enableTouch(){ 
        yield return new WaitForSeconds(1.0f);
        isTouchEnabled = true;
    } 

    //-------------------------------------------
    // MARK - GET CLICKED OBJECT
    //-------------------------------------------
    GameObject getClickedObject (out RaycastHit hit){
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
            target = hit.collider.gameObject;
        }
        return target;
    }


    //-------------------------------------------
    // MARK - CHANGE BKG COLORS
    //-------------------------------------------
    void changeColor() {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, colors[colorInt], colorSpeed * Time.deltaTime);
    }
    void colorChangeTime() {
        if(currentTime <= 0){
            colorInt += 1;
            if(colorInt >= colors.Length){ colorInt = 0; }
            currentTime = cTime;
        } else { currentTime -= Time.deltaTime; }
    }


    void rateButt() {
        rateAlert.gameObject.SetActive(false);
        Application.OpenURL(RateAppStoreURL);
    }

    void cancelButt() {
        rateAlert.gameObject.SetActive(false);
    }

    //-------------------------------------------
    // SHOW REWARD AD
    //-------------------------------------------
    public void showRewardAd() {
        Advertisement.Show(_adUnitId, this);
    }
    
    //-------------------------------------------
    // MARK - UNITY ADS CALLBACKS
    //-------------------------------------------
    // Load content to the Ad Unit:
    public void LoadAd() {
        print("Unity Ads: Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
 
    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId) {
        print("UnityAds: Ad Loaded: " + adUnitId);
    }
 
    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)) {
            print("Unity Ads: Rewarded Ad Completed");
            // Load another ad:
            LoadAd();

            //-------------------------------------------
            // MARK - GRANT THE REWARD!
            //-------------------------------------------
            resumeButt();
            players[playerInt].GetComponent<Animation>().Play("jumpAnim0");
            jumpInt = 0;
        }
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

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

} //./ end
