using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class LeaderboardManager : MonoBehaviour
{

    public bool success;
    public string mStatus;
    public long score;

    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
                .Build();
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
        Debug.Log("LOGIN");

#endif


        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Social.localUser.Authenticate(ProcessAuthentication);
            print("Iphone");
        }



    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
        Debug.Log("SCORE DE LEADERBOARMANAGER " + score);
    }

    void ProcessAuthentication(bool success)
    {
        if (success)
        {
            Debug.Log("Authenticated, checking achievements");
        }
        else
        {
            Debug.Log("Failed to authenticate");
        }
    }

    public void ReportScore(long score, string leaderboardID)
    {
#if UNITY_ANDROID
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success =>
        {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });

#endif
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
            Social.ReportScore(score, leaderboardID, success =>
            {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
        }
    }
    public void checkScoreboardButton()
    {
#if UNITY_ANDROID


        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            /* * PlayGamesPlatform.Instance.LoadScores(
             GPGSIds.leaderboard_top_players,
             LeaderboardStart.PlayerCentered,
             10,
             LeaderboardCollection.Public,
             LeaderboardTimeSpan.AllTime,
             (data) =>
             {
                 mStatus = "Leaderboard data valid: " + data.Valid;
                 mStatus += "\n approx:" + data.ApproximateCount + " have " + data.Scores.Length;
             });
             */
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }

#endif
        #if UNITY_IPHONE
            Social.ShowLeaderboardUI();
        #endif
    }
    public void Login()
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
            Login();
            // Show failure message
            print("Sign in");
            print("Sign-in failed");
        }
    }







}
