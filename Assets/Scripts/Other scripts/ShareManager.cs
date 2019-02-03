using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareManager : MonoBehaviour
{
    int score;
    private string ANDROID_RATE_URL = "market://details?id=com.games.cartwheelgalaxy.leftyrighty";
    private string IOS_RATE_URL = "itms-apps://itunes.apple.com/app/APPIDIOS";


    void Start()
    {

    }

    void Update()
    {
        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;


    }

    public void startShare()
    {
        StartCoroutine(TakeSSAndShare());
    }



    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = System.IO.Path.Combine(Application.temporaryCachePath, "shared img.png");
        System.IO.File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

#if UNITY_ANDROID
        new NativeShare().AddFile(filePath).SetSubject("Subject goes here").SetText("I got " + score + " in Fiesta Balloon, can you beat me?  https://play.google.com/store/apps/details?id=com.games.cartwheelgalaxy.leftyRigty").Share();
#elif UNITY_IPHONE
        new NativeShare().AddFile(filePath).SetSubject("Subject goes here").SetText("I got " + score + " in Fiesta Balloon, can you beat me?  https://itunes.apple.com/developer/cartwheel-galaxy-inc/id412798912").Share();
#endif


        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
    }

    public void RateApp()
    {
        #if UNITY_ANDROID
            Application.OpenURL(ANDROID_RATE_URL);
        #elif UNITY_IPHONE
            Application.OpenURL(IOS_RATE_URL);
        #endif
    }
}
