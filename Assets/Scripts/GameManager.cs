using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    public GameObject panelMainMenu, panelGameScene, panelMissios, PanelGameover, panelStore, panelHasBeenBought;
    public GameObject showTutorial, buttonTapToPlay, buttonStore, buttonNoAds, buttonSound, buttonLeaderboard, buttonRestorePurchase, closeTutorialButton, titleGame;
    public GameObject playerObj, tilesGeneratorObj, gradient6Obj;

    int NumGame;

    public bool gameHasBegun, Adfree;

    void Start ()
    {
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
}
