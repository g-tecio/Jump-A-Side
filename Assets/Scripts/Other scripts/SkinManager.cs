using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour {


  //  public GameObject arrowRight, arrowLeft, balloonCenter, balloonLeft, balloonRight, balloonMenu, warningSign, lockIcon, heartGroup;
  //  public Sprite balloonHeartSprite, arrowHeartRightSprite, arrowHeartLeftSprite, warningSignRed;
  //  public Sprite balloonWhiteSprite, arrowWhiteRightSprite, arrowWhiteLeftSprite, warningSignWhite;
    public Image UIBackground;
    int randomBackground;
    bool gamehasBegun;

    public bool SkinNeon, SkinNormal;
    public bool SkinOwnedNeon, SkinOwnedNormal;

    
    private int actualCurrency = 0;

    int priceNeon = 100;

    void Start ()
    {
        //PlayerPrefs.DeleteAll();
        SkinNeon = Convert.ToBoolean(PlayerPrefs.GetInt("SkinNeon"));
        SkinNormal = Convert.ToBoolean(PlayerPrefs.GetInt("SkinNormal"));
        SkinOwnedNeon = Convert.ToBoolean(PlayerPrefs.GetInt("SkinOwnedNeon"));
        priceNeon = PlayerPrefs.GetInt("priceNeon");

        if (SkinNormal == false && SkinNeon == false)
        {
            ChangeBackground1();
        }

        if (SkinNormal == true)
        {
            ChangeBackground1();
        }

        if (SkinNeon == true)
        {
            ChangeBackground2();
        }
      


        if (SkinOwnedNeon == true)
        {
            priceNeon = 0;
        }
        else
        {
            priceNeon = 100;
        }

        if (SkinNormal == true)
        {
            /*
            //NORMAL SKIN
            squareWhiteSprite = Resources.Load<Sprite>("Normal/Square");
            squareObject.GetComponent<SpriteRenderer>().sprite = squareWhiteSprite;

            platformWhite = Resources.Load<Sprite>("Normal/Platform");
            platformObject.GetComponent<SpriteRenderer>().sprite = platformWhite;
            */

        }

        if (SkinNeon == true)
        {
            /*
            //VALENTINE'S SKIN
            squareNeonSprite = Resources.Load<Sprite>("Neon/SquareNeon");
            squareObject.GetComponent<SpriteRenderer>().sprite = squareWhiteSprite;

            platformNeon = Resources.Load<Sprite>("Neon/PlatformNeon");
            platformObject.GetComponent<SpriteRenderer>().sprite = platformWhite;
            */
        }
    }


    public void SkinNormalSelected()
    {
        SkinNormal = true;
        SkinNeon = false;
        PlayerPrefs.SetInt("SkinNeon", Convert.ToInt32(SkinNeon));
        PlayerPrefs.SetInt("SkinNormal", Convert.ToInt32(SkinNormal));

        /*
        //NORMAL SKIN
        squareWhiteSprite = Resources.Load<Sprite>("Normal/Square");
        squareObject.GetComponent<SpriteRenderer>().sprite = squareWhiteSprite;

        platformWhite = Resources.Load<Sprite>("Normal/Platform");
        platformObject.GetComponent<SpriteRenderer>().sprite = platformWhite;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        */

    }


    public void SkinNeonSelected()
    {

        if (actualCurrency >= priceNeon)
        {

            actualCurrency = actualCurrency - priceNeon;
            priceNeon = 0;

            PlayerPrefs.SetInt("priceNeon", priceNeon);
     
            PlayerPrefs.SetInt("Currency", actualCurrency);

           // lockIcon.gameObject.SetActive(false);

            SkinNeon = true;
            SkinNormal = false;
            PlayerPrefs.SetInt("SkinNeon", Convert.ToInt32(SkinNeon));
            PlayerPrefs.SetInt("SkinNormal", Convert.ToInt32(SkinNormal));

            SkinOwnedNeon = true;
            PlayerPrefs.SetInt("SkinOwnedNeon", Convert.ToInt32(SkinOwnedNeon));

            /*
            //NEON SKIN
            squareNeonSprite = Resources.Load<Sprite>("Neon/SquareNeon");
            squareObject.GetComponent<SpriteRenderer>().sprite = squareWhiteSprite;

            platformNeon = Resources.Load<Sprite>("Neon/PlatformNeon");
            platformObject.GetComponent<SpriteRenderer>().sprite = platformWhite;

    */
        }
        else
        {
         //   print("You don't have enough currency");
        }

    }

    void Update()
    {
        actualCurrency = GameObject.Find("GameManager").GetComponent<ScoreManager>().saveCurrency;
        print("CURRENCY AT THE START " + actualCurrency);
        gamehasBegun = GameObject.Find("GameManager").GetComponent<GameManager>().gameHasBegun;
        if (gamehasBegun == true)
        {
       //     wordLove.gameObject.SetActive(true);

        }
        else
        {
        //    wordLove.gameObject.SetActive(false);
        }
        
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
