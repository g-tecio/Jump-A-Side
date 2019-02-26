using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GooglePlayGames;
using GoogleMobileAds.Api;


public class GameManager : MonoBehaviour
{

    public GameObject panelMainMenu, panelGameScene, panelMissios, PanelGameover, panelStore, panelHasBeenBought;
    public GameObject showTutorial, buttonTapToPlay, buttonStore, buttonNoAds, buttonSound, buttonLeaderboard, buttonRestorePurchase, closeTutorialButton, titleGame, titleGameBee;
    public GameObject playerObj, tilesGeneratorObj, gradient6Obj;

    int NumGame;

    public bool gameHasBegun, Adfree, isDead;

    public long score;
    public LeaderboardManager leaderboardScript;
    System.Action<bool> callback;
    private InterstitialAd interstitial;

    private bool skinSpring, skinNormal;

    void Start()
    {

        Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 1;

#if UNITY_IOS
            SignIn(callback);
#endif

        RequestInterstitial();
        NumGame = PlayerPrefs.GetInt("NumGame");
        print("NUMERO DE JUEGO " + NumGame);

        if (PlayerPrefs.HasKey("select"))
        {
            if (PlayerPrefs.GetInt("select") == 1)
            {
                buttonSound.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
                AudioListener.volume = 0f;
            }
            else
            {
                buttonSound.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
                AudioListener.volume = 1f;
            }
        }


        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            Debug.Log("First Time Opening");

            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            //Do your stuff here
            print("YA ABRISTE LA APP POR PRIMERA VEZ JIJI");
            ShowInterstitial();

        }
        else
        {
            Debug.Log("NOT First Time Opening");

            //Do your stuff here
            print("UH ESE MEN");
        }


    }
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        PlayerPrefs.DeleteKey("FIRSTTIMEOPENING");
    }

    void Update()
    {
        Adfree = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().Adfree;
        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;

        skinNormal = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNormal;
        skinSpring = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinSpring;
        print("SkinNormal" + skinNormal);
        print("skinSpring:" + skinSpring);

        // print("SCORE EN GAME MANAGER:" + score);

        if (buttonSound.GetComponent<UnityEngine.UI.Toggle>().isOn == true)
        {
            //print("THE SOUND IS MUTED");
            PlayerPrefs.SetInt("select", 1);
            AudioListener.volume = 0f;
        }
        else
        {
            // print("THE SOUND IS TURNED ON");
            PlayerPrefs.SetInt("select", 0);
            AudioListener.volume = 1f;
        }

        isDead = GameObject.Find("Player").GetComponent<Player>().isDead;


        if (isDead == true)
        {
            GameOver();
        }

    }

    public void GameBegin()
    {
        gameHasBegun = true;
        panelMainMenu.gameObject.SetActive(false);
        panelGameScene.gameObject.SetActive(true);



        playerObj.gameObject.SetActive(true);
        tilesGeneratorObj.gameObject.SetActive(true);

        GameObject gamePlayer = GameObject.Find("Player");
        GameObject gameTilesGenerator = GameObject.Find("TilesGenerator");
        GameObject gameMainCamera = GameObject.Find("Main Camera");
        GameObject backgroundBee = GameObject.Find("PanelImageBackgroundBee");

        gamePlayer.GetComponent<Player>().enabled = true;
        gameTilesGenerator.GetComponent<Generator>().enabled = true;
        gameMainCamera.GetComponent<CameraFollow>().enabled = true;

        //  backgroundBee.GetComponent<BackgroundMove>().enabled = true;




    }

    public void ReloadGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        NumGame = NumGame + 1;
        PanelGameover.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("NumGame", NumGame);
        // ShowInterstitial();

        if (NumGame % 3 == 0 && Adfree == false)
        {
            Advertisement.Show();

        }
    }


    public void ShowMissions()
    {
        GameObject deathSound = GameObject.Find("PanelGameOver");
        deathSound.GetComponent<AudioSource>().enabled = false;
        panelMissios.gameObject.SetActive(true);
        PanelGameover.gameObject.SetActive(false);

    }


    public void CloseMissions()
    {

        panelMissios.gameObject.SetActive(false);
        PanelGameover.gameObject.SetActive(true);

    }

    public void ShowStore()
    {
        panelStore.gameObject.SetActive(true);
        panelMainMenu.gameObject.SetActive(false);

    }

    public void CloseStore()
    {
        panelStore.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);

    }

    public void CloseHasBeenBought()
    {
        panelHasBeenBought.gameObject.SetActive(false);
    }

    public void ShowTutorial()
    {
        showTutorial.gameObject.SetActive(true);
        closeTutorialButton.gameObject.SetActive(true);


        titleGame.gameObject.SetActive(false);
        titleGameBee.gameObject.SetActive(false);


        buttonTapToPlay.gameObject.SetActive(false);
        buttonStore.gameObject.SetActive(false);
        buttonNoAds.gameObject.SetActive(false);
        buttonSound.gameObject.SetActive(false);
        buttonLeaderboard.gameObject.SetActive(false);

#if UNITY_ANDROID
        buttonRestorePurchase.gameObject.SetActive(false);
#elif UNITY_IPHONE
            buttonRestorePurchase.gameObject.SetActive(true);
#endif
    }

    public void CloseTutorial()
    {
        showTutorial.gameObject.SetActive(false);
        closeTutorialButton.gameObject.SetActive(false);




        if (skinNormal == true || skinSpring == false)
        {
            titleGame.gameObject.SetActive(true);
        }

        if (skinSpring == true)
        {
            titleGameBee.gameObject.SetActive(true);
        }
        buttonTapToPlay.gameObject.SetActive(true);
        buttonStore.gameObject.SetActive(true);
        buttonNoAds.gameObject.SetActive(true);
        buttonSound.gameObject.SetActive(true);
        buttonLeaderboard.gameObject.SetActive(true);

#if UNITY_ANDROID
        buttonRestorePurchase.gameObject.SetActive(false);
#elif UNITY_IPHONE
            buttonRestorePurchase.gameObject.SetActive(false);
#endif
    }


    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5267056163100832/6554786361";
#elif UNITY_IPHONE
             string adUnitId = "ca-app-pub-5267056163100832/8171120365";
#else
             string adUnitId = "unexpected_platform";
#endif

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);
        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    // Returns an ad request
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void GameOver()
    {

#if UNITY_ANDROID
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            // Note: make sure to add 'using GooglePlayGames'
            print("QUIERO MI ONEPLUS");
            PlayGamesPlatform.Instance.ReportScore(score,
                GPGSIds.leaderboard_top_players,
                (bool success) =>
                {
                    Debug.Log("(Lollygagger) Leaderboard update success: " + success);
                    Debug.Log("Score mandado " + score);
                });
        }
#endif

#if UNITY_IOS
        ReportScore(score,"JumpAsideleaderboard");
#endif

    }

    public void SignInCallback(bool success)
    {

        if (success)
        {
            Debug.Log("(Lollygagger) Signed in!");

            // Change sign-in button text
            print("Sign out");

            // Show the user's name
            print("Signed in as: " + Social.localUser.userName);
        }
        else
        {
            Debug.Log("(Lollygagger) Sign-in failed...");
#if UNITY_ANDROID
            LoginAndroid();
#endif
#if UNITY_IPHONE

#endif
            // Show failure message
            print("Sign in");
            print("Sign-in failed");
        }

    }
    public void LoginAndroid()
    {
#if UNITY_ANDROID
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            print("Sign In");

        }
#endif

    }
    void ReportScore(long score, string leaderboardID)
    {
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success =>
        {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    public static bool IsGCUseLoggedIn
    {
        get
        {
            Debug.Log("LOGGEDIN " + Social.localUser.authenticated);
            return Social.localUser.authenticated;

        }
    }
    public static string GCUsername
    {
        get
        {
            return Social.Active.localUser.userName;
        }
    }
    public static void SignIn(System.Action<bool> callback)
    {
        Social.localUser.Authenticate(callback);
        Debug.Log("CALLBACK " + callback);
    }


    public static void UpdateLeaderboard(string id, long score)
    {
        if (IsGCUseLoggedIn)
        {
            Social.ReportScore(score, id, null);
        }

    }
}