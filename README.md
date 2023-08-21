# Stumble Jump

Hi there, I've built this game as a side project, and I'm sharing it for you to learn how to make games in Unity.

You can download the files and open the entire project in Unity (use the latest version available).

This game includes the necessary code to handle Unity Ads and an In-App Purchase to remove Ads, so you need to perform a few edits in some of its C# scripts:

## Home.cs
You need to set the links to your main website and a landing page of your game (if you have it):

``` 
void moreGamesButt() { 
      audioSource.PlayOneShot(clickSND, 1.0f);
      Application.OpenURL("https://your-website");
}

void feedbackButt() { 
  audioSource.PlayOneShot(clickSND, 1.0f);
  Application.OpenURL("https://your-game-landing-page");
}
```

## GameScene.cs
Set the link to your game's Play and App Store page, in order to make people able to rate your game:

```
#if UNITY_IOS
    _adUnitId = "Rewarded_iOS";
    RateAppStoreURL = "https://apps.apple.com/app/idXXXXXXXXXX";
#elif UNITY_ANDROID
    _adUnitId = "Rewarded_Android";
    RateAppStoreURL = "https://play.google.com/store/apps/details?id=com.yourname.gamename";
#endif
```

## AddsManager.cs
Change the Unity IDs to the ones you'll create in your Unity Monetization Portal:
```
public static string _androidGameId = "5206339";
public static string _iOSGameId = "5206338";
```
## Purchaser.cs
Change the Product Identifier with the one you created in your App and Play Console game's page - In-App Purchase section:
```
public static string kProductIDNonConsumable = "com.stumblejump.removeads";
```
# NOTE:
You're free to change sprites and 3D objects as well, experiment with your own graphics, reskin this game and make it yours, you're free to publish it on your App Store and Google Play accounts (obviously you must change its name and app icon ;)
