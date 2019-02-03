using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{

    public bool Adfree;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI YourScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI best;

    public int currentScore = 0;
    public int currentScore2 = 0;

    public Missions Script;
    //bool claimR1;

    public int scoreAcumlated, scoreStored, scoreAcumlated2, scoreStored2;

    //currentcy
    public int saveCurrency;
    public int currency;
    public TextMeshProUGUI currencyText;
    public TextMeshProUGUI currencyPlus;
    public GameObject currencyBonus;
    public GameObject currencyBonusDouble;
    private bool premium = false;

      void Start()
        {


        scoreStored = PlayerPrefs.GetInt("a");
        //  print("SCORE ACUMULADO START:" + scoreStored);

        scoreStored2 = PlayerPrefs.GetInt("b");
        // print("SCORE ACUMULADO SEGUNDO START:" + scoreStored2);

      
        //claimR1 = gameObject.GetComponent<Missions>().claimedR1;
        currentScoreText.text = currentScore.ToString();
        YourScoreText.text = currentScore.ToString();
        GetBestScore();



        //Currency
        getCurrency();
    }



    void Update()
    {
        saveCurrency = PlayerPrefs.GetInt("Currency", saveCurrency);
        premium = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().Adfree;
       // print("ADFREE UPDATE " + premium);

     

        scoreStored = PlayerPrefs.GetInt("a");
        // print("SCORE ACUMULADO START:" + scoreStored);

        scoreStored2 = PlayerPrefs.GetInt("b");
        // print("SCORE ACUMULADO SEGUNDO START:" + scoreStored2);

        Missions missions = gameObject.GetComponent<Missions>();
        if (missions.claimedR2 == true)
        {
            scoreAcumlated = 0;
            PlayerPrefs.SetInt("a", scoreAcumlated);
        }

        if (missions.claimedR4 == true)
        {
            scoreAcumlated2 = 0;
            PlayerPrefs.SetInt("b", scoreAcumlated2);
        }

        if (saveCurrency >= 999)
        {
            currencyText.text = "999";
        }
    }

    void GetBestScore()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    void getCurrency()
    {
        currencyText.text = PlayerPrefs.GetInt("Currency", 0).ToString();
    }


    public void AddScore()
    {
        Missions missions = gameObject.GetComponent<Missions>();

        currentScore++;
        currentScoreText.text = currentScore.ToString();
        YourScoreText.text = currentScore.ToString();

        if (currentScore > 0)
        {
            scoreAcumlated = PlayerPrefs.GetInt("a");
            scoreAcumlated = scoreAcumlated + 1;
            //  print("SCORE ACUMULADO TIEMPO REAL: " + scoreAcumlated);
            PlayerPrefs.SetInt("a", scoreAcumlated);
        }

        if (missions.claimedR2 == true)
        {
            //   print("Se cumplieron las condiciones");
            scoreAcumlated2 = PlayerPrefs.GetInt("b");
            scoreAcumlated2 = scoreAcumlated2 + 1;
            //   print("SCORE SEGUNDO: " + scoreAcumlated2);
            PlayerPrefs.SetInt("b", scoreAcumlated2);
        }


        if (missions.claimedR1 == true)
        {
            currentScore2++;
          //  print("Current score de la mission 2: " + currentScore2);
        }

        //Currency
        if (premium == false)
        {

            if (saveCurrency >= 999)
            {
                currencyText.text = "999";
            }

            if (currentScore % 10 == 0)
            {
                currency++;

                saveCurrency = PlayerPrefs.GetInt("Currency", saveCurrency) + 1;
                PlayerPrefs.SetInt("Currency", saveCurrency);
                currencyText.text = PlayerPrefs.GetInt("Currency", saveCurrency).ToString();

                currencyPlus.text = "+" + currency.ToString();
                StartCoroutine(showCurrency());
            }
        }
        else
        {
           // print("YEAH YOU GOT THE RIGHT VERSION BRO!");
            if (saveCurrency >= 999)
            {
                currencyText.text = "999";
            }

            if (currentScore % 10 == 0)
            {
                currency = currency + 2;
               // print("CURRENCYALDOBLE" + currency);
                saveCurrency = PlayerPrefs.GetInt("Currency", saveCurrency) + 2;
                PlayerPrefs.SetInt("Currency", saveCurrency);
                currencyText.text = PlayerPrefs.GetInt("Currency", saveCurrency).ToString();

                currencyPlus.text = "+" + currency.ToString();
                StartCoroutine(showCurrencyDouble());
            }
        }

        //End currency

        if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            bestScoreText.text = currentScore.ToString();
            PlayerPrefs.SetInt("BestScore", currentScore);
        }

    }

    //Show +1    
    IEnumerator showCurrency()
    {
        currencyBonus.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        currencyBonus.SetActive(false);
    }

    IEnumerator showCurrencyDouble()
    {
        currencyBonusDouble.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        currencyBonusDouble.SetActive(false);
    }
}
