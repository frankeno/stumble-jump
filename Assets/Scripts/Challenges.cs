using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

[RequireComponent(typeof(AudioSource))]
public class Challenges : MonoBehaviour {

    public Text titleTxt;   
    public Text subtitleTxt;   
    public Text[] cTxts;
    public Image[] checkmarks;
    public Button[] shareButtons;
    public Button backButton;
    public int[] challengesMade;

    // Audio
    AudioSource audioSource;
    public AudioClip clickSND;

    //-------------------------------------------
    // MARK - START
    //-------------------------------------------
    void Start(){
        // Init audioSource
        audioSource = GetComponent<AudioSource>();

        backButton.onClick.AddListener(() => backButt());
        titleTxt.text = Lang.chTitleStr();
        subtitleTxt.text = Lang.chSubtitleStr();

        foreach(Button b in shareButtons){ b.gameObject.SetActive(false); }

        shareButtons[0].onClick.AddListener(() => shareAchievement(0));
        shareButtons[1].onClick.AddListener(() => shareAchievement(1));
        shareButtons[2].onClick.AddListener(() => shareAchievement(2));
        shareButtons[3].onClick.AddListener(() => shareAchievement(3));
        shareButtons[4].onClick.AddListener(() => shareAchievement(4));
        shareButtons[5].onClick.AddListener(() => shareAchievement(5));
        shareButtons[6].onClick.AddListener(() => shareAchievement(6));
        shareButtons[7].onClick.AddListener(() => shareAchievement(7));
        shareButtons[8].onClick.AddListener(() => shareAchievement(8));
        shareButtons[9].onClick.AddListener(() => shareAchievement(9));
        shareButtons[10].onClick.AddListener(() => shareAchievement(10));
        shareButtons[11].onClick.AddListener(() => shareAchievement(11));

        // Load challenges
        for(int i=0;i<challengesMade.Length;i++){ 
            challengesMade[i] = PlayerPrefs.GetInt("c"+i.ToString(), 0); 
            if(challengesMade[i] == 1){ 
                checkmarks[i].GetComponent<Image>().color = new Color(255f,255f,255f,1f);
                shareButtons[i].gameObject.SetActive(true);
            }
        }
        shareButtons[6].gameObject.SetActive(false);

        // Set Texts
        cTxts[0].text = Lang.cTxt0();
        cTxts[1].text = Lang.cTxt1();
        cTxts[2].text = Lang.cTxt2();
        cTxts[3].text = Lang.cTxt3();
        cTxts[4].text = Lang.cTxt4();
        cTxts[5].text = Lang.cTxt5();
        cTxts[6].text = Lang.cTxt6();
        cTxts[7].text = Lang.cTxt7();
        cTxts[8].text = Lang.cTxt8();
        cTxts[9].text = Lang.cTxt9();
        cTxts[10].text = Lang.cTxt10();
        cTxts[11].text = Lang.cTxt11();
        
    } //./ Start()

    // Share achievement
    void shareAchievement(int achInt) {
        new NativeShare().SetSubject( Lang.shareAchTitleStr() ).SetText(Lang.shareAchMessageStr() + cTxts[achInt].text.ToUpper())
        .SetUrl( "https://cutt.ly/sjump" )
        .SetCallback( ( result, shareTarget ) => print( "Share result: " + result + ", selected app: " + shareTarget ) )
        .Share();
        
        if(challengesMade[6] == 0){
            PlayerPrefs.SetInt("c6", 1);
            checkmarks[6].GetComponent<Image>().color = new Color(255f,255f,255f,1f);            
        }
    }

    //-------------------------------------------
    // MARK - BACK BUTTON
    //-------------------------------------------
    public void backButt() {
        audioSource.PlayOneShot(clickSND, 1.0f);
        StartCoroutine(changeScene(0.2f, "Home"));
    }

    //-------------------------------------------
    // MARK - CHANGE SCENE
    //-------------------------------------------
    IEnumerator changeScene(float time, string sceneName){ 
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

} // ./ end
