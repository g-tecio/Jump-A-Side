using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GooglePlayGames;


public class GameManager : MonoBehaviour {

    public GameObject panelMainMenu, panelGameScene, panelMissios, PanelGameover, panelStore, panelHasBeenBought;
    public GameObject showTutorial, buttonTapToPlay, buttonStore, buttonNoAds, buttonSound, buttonLeaderboard, buttonRestorePurchase, closeTutorialButton, titleGame;
    public GameObject playerObj, tilesGeneratorObj, gradient6Obj;

    int NumGame;

    public bool gameHasBegun, Adfree, isDead;

    public long score;
    public LeaderboardManager leaderboardScript;

    void Start ()
    {
        PlayerPrefs.GetInt("NumGame");

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
    }
	
	void Update ()
    {
        Adfree = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().Adfree;

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

        GameObject gamePlayer= GameObject.Find("Player");
        GameObject gameTilesGenerator = GameObject.Find("TilesGenerator");
        GameObject gameMainCamera = GameObject.Find("Main Camera");

        gamePlayer.GetComponent<Player>().enabled = true;
        gameTilesGenerator.GetComponent<Generator>().enabled = true;
        gameMainCamera.GetComponent<CameraFollow>().enabled = true;

    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        NumGame = NumGame + 1;
        PanelGameover.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("NumGame", NumGame);


        if (NumGame % 3 == 0 && Adfree == false)
        {
            Advertisement.Show();

        }
    }


    public void ShowMissions()
    {
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

        titleGame.gameObject.SetActive(true);
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

    public void GameOver()
    {

    #if UNITY_ANDROID
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            // Note: make sure to add 'using GooglePlayGames'
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
        ReportScore(score,"55969983");
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
