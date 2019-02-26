using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public Image UIBackground;
    public GameObject titleGameMenuNormal, titleGameMenuSpring, titleGameStoreNormal, titleGameStoreSpring, backgroundNormal, backgroundBee;
    int randomBackground;

    public GameObject lockIconSpring;
    bool gamehasBegun;
    public bool skinNormal, skinSpring;
    public bool skinOwnedNormal, skinOwnedSpring;
    private int actualCurrency = 0;
    int priceSpring = 100;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        skinSpring = Convert.ToBoolean(PlayerPrefs.GetInt("skinSpring"));
        skinNormal = Convert.ToBoolean(PlayerPrefs.GetInt("skinNormal"));
        skinOwnedSpring = Convert.ToBoolean(PlayerPrefs.GetInt("skinOwnedSpring"));
        priceSpring = PlayerPrefs.GetInt("priceSpring");


        if (skinNormal == false && skinSpring == false)
        {
            ChangeBackground1();
            backgroundNormal.gameObject.gameObject.SetActive(true);
            backgroundBee.gameObject.gameObject.SetActive(false);
        }

        if (skinNormal == true)
        {
            ChangeBackground1();
            backgroundNormal.gameObject.gameObject.SetActive(true);
            backgroundBee.gameObject.gameObject.SetActive(false);
        }

        if (skinSpring == true)
        {
            backgroundNormal.gameObject.gameObject.SetActive(false);
            backgroundBee.gameObject.gameObject.SetActive(true);
        }

        if (skinOwnedSpring == true)
        {
            lockIconSpring.gameObject.gameObject.SetActive(false);
            priceSpring = 0;
        }
        else
        {
            priceSpring = 100;
        }

        if (skinNormal == true)
        {


            titleGameMenuNormal.gameObject.SetActive(true);
            titleGameMenuSpring.gameObject.SetActive(false);

            titleGameStoreNormal.gameObject.SetActive(true);
            titleGameStoreSpring.gameObject.SetActive(false);

        }

        if (skinSpring == true)
        {
            titleGameMenuNormal.gameObject.SetActive(false);
            titleGameMenuSpring.gameObject.SetActive(true);

            titleGameStoreNormal.gameObject.SetActive(false);
            titleGameStoreSpring.gameObject.SetActive(true);
        }
    }


    public void SkinNormalSelected()
    {
        skinNormal = true;
        skinSpring = false;
        PlayerPrefs.SetInt("skinSpring", Convert.ToInt32(skinSpring));
        PlayerPrefs.SetInt("skinNormal", Convert.ToInt32(skinNormal));

        titleGameMenuNormal.gameObject.SetActive(true);
        titleGameMenuSpring.gameObject.SetActive(false);

        titleGameStoreNormal.gameObject.SetActive(true);
        titleGameStoreSpring.gameObject.SetActive(false);

        backgroundNormal.gameObject.gameObject.SetActive(true);
        backgroundBee.gameObject.gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }


    public void SkinSpringSelected()
    {

        if (actualCurrency >= priceSpring)
        {

            actualCurrency = actualCurrency - priceSpring;
            priceSpring = 0;

            PlayerPrefs.SetInt("priceSpring", priceSpring);

            PlayerPrefs.SetInt("Currency", actualCurrency);

            lockIconSpring.gameObject.SetActive(false);

            skinSpring = true;
            skinNormal = false;
            PlayerPrefs.SetInt("skinSpring", Convert.ToInt32(skinSpring));
            PlayerPrefs.SetInt("skinNormal", Convert.ToInt32(skinNormal));

            skinOwnedSpring = true;
            PlayerPrefs.SetInt("skinOwnedSpring", Convert.ToInt32(skinOwnedSpring));

            titleGameMenuNormal.gameObject.SetActive(false);
            titleGameMenuSpring.gameObject.SetActive(true);

            titleGameStoreNormal.gameObject.SetActive(false);
            titleGameStoreSpring.gameObject.SetActive(true);

            backgroundNormal.gameObject.gameObject.SetActive(false);
            backgroundBee.gameObject.gameObject.SetActive(true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else
        {
            print("You don't have enough currency");
        }

    }

    void Update()
    {
        actualCurrency = GameObject.Find("GameManager").GetComponent<ScoreManager>().saveCurrency;

    }


    void ChangeBackground1()
    {
        UIBackground = GameObject.Find("PanelImageBackground").GetComponent<Image>();
        randomBackground = UnityEngine.Random.Range(1, 8);
        //  print("RANDOM NORMAL: " + randomBackground);
        switch (randomBackground)
        {
            case 1:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient1");
                break;
            case 2:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient2");
                break;
            case 3:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient3");
                break;
            case 4:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient4");
                break;
            case 5:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient5");
                break;
            case 6:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient6");
                break;
            case 7:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient7");
                break;
        }
    }

    void ChangeBackground2()
    {
        UIBackground = GameObject.Find("PanelImageBackground").GetComponent<Image>();
        randomBackground = UnityEngine.Random.Range(1, 4);
        switch (randomBackground)
        {
            case 1:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient6");
                break;
            case 2:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient8");
                break;
            case 3:
                UIBackground.sprite = Resources.Load<Sprite>("Backgrounds/gradient9");
                break;

        }
    }


}
