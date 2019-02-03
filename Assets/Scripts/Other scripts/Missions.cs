using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Missions : MonoBehaviour
{
    int score, score2;
    int actualCurrency;
    public bool mission01, mission02, mission03, mission04;
    public bool claimedR1, claimedR2, claimedR3, claimedR4;
    public GameObject panelMissions, panelGameOver, currentScore;
    public GameObject buttonClaimReward01, buttonClaimReward03;
    public GameObject buttonClaimReward02, buttonClaimReward04;

    public TextMeshProUGUI textButtonMission01, textButtonMission02, textButtonMission03, textButtonMission04;

    public TextMeshProUGUI currencyTexto;
    public TextMeshProUGUI mission01Text, mission03Text;
    public TextMeshProUGUI mission02Text, mission04Text;

    public bool Adfree;

    int scoreStored, scoreStored2;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        scoreStored = GameObject.Find("GameManager").GetComponent<ScoreManager>().scoreStored;
        scoreStored2 = GameObject.Find("GameManager").GetComponent<ScoreManager>().scoreStored2;

        scoreStored = GameObject.Find("GameManager").GetComponent<ScoreManager>().scoreAcumlated;
        scoreStored2 = GameObject.Find("GameManager").GetComponent<ScoreManager>().scoreAcumlated2;

        mission01 = Convert.ToBoolean(PlayerPrefs.GetInt("mission01"));
        mission02 = Convert.ToBoolean(PlayerPrefs.GetInt("mission02"));
        mission03 = Convert.ToBoolean(PlayerPrefs.GetInt("mission03"));
        mission04 = Convert.ToBoolean(PlayerPrefs.GetInt("mission04"));

        claimedR1 = Convert.ToBoolean(PlayerPrefs.GetInt("claimedR1"));
        claimedR2 = Convert.ToBoolean(PlayerPrefs.GetInt("claimedR2"));
        claimedR3 = Convert.ToBoolean(PlayerPrefs.GetInt("claimedR3"));
        claimedR4 = Convert.ToBoolean(PlayerPrefs.GetInt("claimedR4"));

        if (mission01)
        {
            buttonClaimReward01.gameObject.SetActive(true);
            //  print("SE RECUPERO LO DE LA MISION01");
        }


        if (mission02)
        {

            buttonClaimReward02.gameObject.SetActive(true);
            //  print("SE RECUPERO LO DE LA MISION02");
        }


        if (!mission02)
        {

            buttonClaimReward02.gameObject.SetActive(false);
            //  print("SE RECUPERO LO DE LA MISION02");
        }

        if (mission03)
        {

            buttonClaimReward03.gameObject.SetActive(true);

            // print("SE RECUPERO LO DE LA MISION03");
        }


        if (mission04)
        {

            buttonClaimReward04.gameObject.SetActive(true);

            //  print("SE RECUPERO LO DE LA MISION04");
        }


        if (mission01 == true && mission03 == true && claimedR1 == true && claimedR3 == true)
        {
            /*
            // print("YA SE RESETEARON LOS VALORES DE LA MISSION 01 Y MISSION 03 START");
            mission01 = false;
            mission03 = false;
            claimedR1 = false;
            claimedR3 = false;

            PlayerPrefs.SetInt("mission01", Convert.ToInt32(mission01));
            PlayerPrefs.SetInt("mission02", Convert.ToInt32(mission03));

            PlayerPrefs.SetInt("claimedR1", Convert.ToInt32(claimedR1));
            PlayerPrefs.SetInt("claimedR3", Convert.ToInt32(claimedR3));
            */
            mission01Text.gameObject.SetActive(true);
            buttonClaimReward03.gameObject.SetActive(false);
            mission03Text.gameObject.SetActive(false);
            PlayerPrefs.DeleteKey("mission01");
            PlayerPrefs.DeleteKey("mission03");

            PlayerPrefs.DeleteKey("claimedR1");
            PlayerPrefs.DeleteKey("claimedR3");
        }


        if (mission02 == true && mission04 == true && claimedR2 == true && claimedR4 == true)
        {
            /*
            // print("YA SE RESETEARON LOS VALORES DE LA MISSION 02 Y MISSION 04 START");
            mission02 = false;
            mission04 = false;
            claimedR2 = false;
            claimedR4 = false;

            PlayerPrefs.SetInt("mission02", Convert.ToInt32(mission02));
            PlayerPrefs.SetInt("mission04", Convert.ToInt32(mission04));

            PlayerPrefs.SetInt("claimedR2", Convert.ToInt32(claimedR2));
            PlayerPrefs.SetInt("claimedR4", Convert.ToInt32(claimedR4));
            */
            mission02Text.gameObject.SetActive(true);
            buttonClaimReward04.gameObject.SetActive(false);
            mission04Text.gameObject.SetActive(false);

            PlayerPrefs.DeleteKey("mission02");
            PlayerPrefs.DeleteKey("mission04");

            PlayerPrefs.DeleteKey("claimedR2");
            PlayerPrefs.DeleteKey("claimedR4");
        }

    }


    void Update()
    {
         Adfree = GameObject.Find("RemoveAds").GetComponent<PurchaserManager>().Adfree;
        //print("ADFREE UPDATE " + Adfree);

        if (Adfree == true)
        {
            textButtonMission01.text = "+4";
            textButtonMission02.text = "+8";
            textButtonMission03.text = "+8";
            textButtonMission04.text = "+16";
        }
        score = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore;
        score2 = GameObject.Find("GameManager").GetComponent<ScoreManager>().currentScore2;
        scoreStored = GameObject.Find("GameManager").GetComponent<ScoreManager>().scoreAcumlated;
        scoreStored2 = GameObject.Find("GameManager").GetComponent<ScoreManager>().scoreAcumlated2;

        scoreStored = GameObject.Find("GameManager").GetComponent<ScoreManager>().scoreStored;
        scoreStored2 = GameObject.Find("GameManager").GetComponent<ScoreManager>().scoreStored2;

        Mission01();
        Mission02();
        Mission03();
        Mission04();

        currencyTexto = GameObject.Find("GameManager").GetComponent<ScoreManager>().currencyText;
        actualCurrency = GameObject.Find("GameManager").GetComponent<ScoreManager>().saveCurrency;


        if (actualCurrency >= 999)
        {
            currencyTexto.text = "999";
        }


        /*
        if (scoreStored2 == 0)
        {
            print("el puntaje es cero");
        }
*/

        if (mission01 == true && mission03 == true && claimedR1 == true && claimedR3 == true)
        {
            /*
            //print("YA SE RESETEARON LOS VALORES DE LA MISSION 01 Y MISSION 03 UPDATE");
            mission01 = false;
            mission03 = false;
            claimedR1 = false;
            claimedR3 = false;

            PlayerPrefs.SetInt("mission01", Convert.ToInt32(mission01));
            PlayerPrefs.SetInt("mission02", Convert.ToInt32(mission03));

            PlayerPrefs.SetInt("claimedR1", Convert.ToInt32(claimedR1));
            PlayerPrefs.SetInt("claimedR3", Convert.ToInt32(claimedR3));
            */
            mission01Text.gameObject.SetActive(true);
            buttonClaimReward03.gameObject.SetActive(false);
            mission03Text.gameObject.SetActive(false);

            PlayerPrefs.DeleteKey("mission01");
            PlayerPrefs.DeleteKey("mission03");

            PlayerPrefs.DeleteKey("claimedR1");
            PlayerPrefs.DeleteKey("claimedR3");

        }

        if (mission02 == true && mission04 == true && claimedR2 == true && claimedR4 == true)
        {
            /*
            // print("YA SE RESETEARON LOS VALORES DE LA MISSION 02 Y MISSION 04 UPDATE");
            mission02 = false;
            mission04 = false;
            claimedR2 = false;
            claimedR4 = false;

            PlayerPrefs.SetInt("mission02", Convert.ToInt32(mission02));
            PlayerPrefs.SetInt("mission04", Convert.ToInt32(mission04));

            PlayerPrefs.SetInt("claimedR2", Convert.ToInt32(claimedR2));
            PlayerPrefs.SetInt("claimedR4", Convert.ToInt32(claimedR4));
            */
            mission02Text.gameObject.SetActive(true);
            buttonClaimReward04.gameObject.SetActive(false);
            mission04Text.gameObject.SetActive(false);

            PlayerPrefs.DeleteKey("mission02");
            PlayerPrefs.DeleteKey("mission04");

            PlayerPrefs.DeleteKey("claimedR2");
            PlayerPrefs.DeleteKey("claimedR4");
        }

        if (panelMissions.gameObject.activeInHierarchy == true)
        {
            panelGameOver.gameObject.SetActive(false);
            currentScore.gameObject.SetActive(false);
        }
        else
        {
            currentScore.gameObject.SetActive(true);
        }


        mission02Text.text = "Score [ " + scoreStored + " / 100 ]";

        if (scoreStored >= 100)
        {
            mission02Text.text = "Score [ 100 / 100 ]";
        }

        mission04Text.text = "Score [ " + scoreStored2 + " / 500 ]";

        if (scoreStored2 >= 500)
        {
            mission04Text.text = "Score [ 500 / 500 ]";
        }

        if (mission01 == true && claimedR1 == true)
        {
            mission01Text.gameObject.SetActive(false);
            buttonClaimReward01.gameObject.SetActive(false);

            mission03Text.gameObject.SetActive(true);
        }

        if (mission01 == true && mission03 && claimedR1 == true && claimedR3 == true)
        {
            mission03Text.gameObject.SetActive(false);
            buttonClaimReward03.gameObject.SetActive(false);

            mission01Text.gameObject.SetActive(true);
        }


        if (mission02 == true && claimedR2 == true)
        {
            mission02Text.gameObject.SetActive(false);
            buttonClaimReward02.gameObject.SetActive(false);

            mission04Text.gameObject.SetActive(true);
        }

        if (mission02 == true && mission04 && claimedR2 == true && claimedR4 == true)
        {
            mission04Text.gameObject.SetActive(false);
            buttonClaimReward04.gameObject.SetActive(false);
            buttonClaimReward02.gameObject.SetActive(false);

            mission02Text.gameObject.SetActive(true);

        }

    }

    public void Mission01()
    {
        // SCORE 20 IN A SINGLE GAME
        if (score == 20)
        {
            mission01 = true;
            //print("SE CUMPLIO LA MISSION 1");
            if (mission01 == true && score == 20)
            {
                buttonClaimReward01.gameObject.SetActive(true);
            }


            PlayerPrefs.SetInt("mission01", Convert.ToInt32(mission01));
        }
    }

    public void Mission02()
    {
        // SCORE [100/100]
        if (scoreStored >= 100)
        {
            mission02 = true;


            buttonClaimReward02.gameObject.SetActive(true);

            PlayerPrefs.SetInt("mission02", Convert.ToInt32(mission02));
        }
    }

    public void Mission03()
    {
        // SCORE 40 IN A SINGLE GAME
        if (score2 >= 40)
        {
            mission03 = true;
            //print("SE CUMPLIO LA MISSION 3");

            buttonClaimReward03.gameObject.SetActive(true);

            PlayerPrefs.SetInt("mission03", Convert.ToInt32(mission03));
        }

    }

    public void Mission04()
    {
        // SCORE [500/500]
        if (scoreStored2 >= 500)
        {
            mission04 = true;

            buttonClaimReward04.gameObject.SetActive(true);

            PlayerPrefs.SetInt("mission04", Convert.ToInt32(mission04));
        }
    }

    public void claimReward()
    {
        // actualCurrency = actualCurrency + 2;

        claimedR1 = true;

        if (Adfree == true)
        {
            actualCurrency = PlayerPrefs.GetInt("Currency", actualCurrency) + 4;

        }
        else
        {
            actualCurrency = PlayerPrefs.GetInt("Currency", actualCurrency) + 2;
        }

        currencyTexto.text = actualCurrency.ToString();

        PlayerPrefs.SetInt("claimedR1", Convert.ToInt32(claimedR1));
        PlayerPrefs.SetInt("Currency", actualCurrency);
        currencyTexto.text = PlayerPrefs.GetInt("Currency", actualCurrency).ToString();
    }

    public void claimReward2()
    {
        //actualCurrency = actualCurrency + 4;
        claimedR2 = true;
        if (Adfree == true)
        {
            actualCurrency = PlayerPrefs.GetInt("Currency", actualCurrency) + 8;

        }
        else
        {
            actualCurrency = PlayerPrefs.GetInt("Currency", actualCurrency) + 4;

        }

        PlayerPrefs.SetInt("claimedR2", Convert.ToInt32(claimedR2));
        PlayerPrefs.SetInt("Currency", actualCurrency);
        currencyTexto.text = PlayerPrefs.GetInt("Currency", actualCurrency).ToString();
    }

    public void claimReward03()
    {
        //  actualCurrency = actualCurrency + 4;
        claimedR3 = true;
        if (Adfree == true)
        {
            actualCurrency = PlayerPrefs.GetInt("Currency", actualCurrency) + 8;

        }
        else
        {
            actualCurrency = PlayerPrefs.GetInt("Currency", actualCurrency) + 4;
        }


        PlayerPrefs.SetInt("claimedR3", Convert.ToInt32(claimedR3));
        PlayerPrefs.SetInt("Currency", actualCurrency);
        currencyTexto.text = PlayerPrefs.GetInt("Currency", actualCurrency).ToString();
    }

    public void claimReward04()
    {
        //actualCurrency = actualCurrency + 8;
        claimedR4 = true;
        if (Adfree == true)
        {
            actualCurrency = PlayerPrefs.GetInt("Currency", actualCurrency) + 16;
            mission01Text.text = "+4";
        }
        else
        {

            actualCurrency = PlayerPrefs.GetInt("Currency", actualCurrency) + 8;
        }


        buttonClaimReward04.gameObject.SetActive(false);
        PlayerPrefs.SetInt("claimedR4", Convert.ToInt32(claimedR3));
        PlayerPrefs.SetInt("Currency", actualCurrency);
        currencyTexto.text = PlayerPrefs.GetInt("Currency", actualCurrency).ToString();

        PlayerPrefs.DeleteKey("mission02");
        PlayerPrefs.DeleteKey("mission04");

        PlayerPrefs.DeleteKey("claimedR2");
        PlayerPrefs.DeleteKey("claimedR4");
    }

}