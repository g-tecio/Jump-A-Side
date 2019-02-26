using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GameObject TilePrefab;
    private float xDiff = 2.5f; //1.1f; 
    private float yDiffSmall = 0.5f; //0.5f;    0.5 + 0.6 = 1.1
    private float yDiffeBig = 1.4f; //1.4f;
    private float xPos = -2.5f; //-2.5f;
    private float xPosLeft = -1.0f;  //-1.0f;
    private float xPosRight = 0.1f; //0.1f;
    private float yPos = -4.5f; //-4.5f;
    public int random2;
    //-2.5f;
    //-4.5f;

    private string smallTag = "smallTile";
    private string bigTag = "bigTile";

    public bool side = false;
    //false = left
    //true = right
    public bool firstJump = true;
    public bool Grounded;

    public bool skinSpring, skinNormal;


    void Start()
    {
        skinNormal = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNormal;
        skinSpring = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinSpring;

        if (skinSpring == false)
        {
            xDiff = 1.1f;

        }
        else
        {
            xDiff = 2.5f;
        }

        for (int i = 0; i < 2; i++)
        {
            GenerateTiles();
        }

        // Grounded = true;
        print("GROUNDED ON START" + Grounded);



    }//End Start

    void Update()
    {

        Grounded = GameObject.Find("Player").GetComponent<Player>().Grounded;
        //  print("GROUNDED IN GENERATOR " + Grounded);
        skinNormal = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNormal;
        skinSpring = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinSpring;

        if (skinSpring == false)
        {
            xDiff = 1.1f;

        }
        else
        {
            xDiff = 2.5f;
        }
    }
    public void GenerateTiles()
    {
        random2 = Random.Range(0, 5);
        if (firstJump == true)
        {
            GenerateSmallTileLeft();
            firstJump = false;
            side = true;
        }
        else
        {


            int random = Random.Range(0, 5);
            if (side == true && firstJump == false)
            {
                if (random <= 2)
                {
                    if (random2 <= 2 && Grounded == true)
                    {
                        GenerateSmallTileRight();
                    }
                    else
                    {
                        GenerateSmallTileLeft2();
                    }


                }
                else
                {


                    if (random2 <= 2 && Grounded == true)
                    {
                        GenerateBigTileRight();
                    }
                    else
                    {
                        GenerateBigTileLeft2();
                    }
                }


            }

            if (side == false && firstJump == false)
            {
                if (random <= 2)
                {

                    if (random2 <= 2 && Grounded == true)
                    {
                        GenerateSmallTileLeft();
                    }
                    else
                    {
                        GenerateSmallTileRight2();
                    }



                }
                else
                {


                    if (random2 <= 2 && Grounded == true)
                    {
                        GenerateBigTileLeft();
                    }
                    else
                    {
                        GenerateBigTileRight2();
                    }
                }
            }






            if (side == true)
            {
                if (Grounded == true)
                {
                    side = false;
                }

            }
            else
            {
                if (Grounded == true)
                {
                    side = true;
                }
            }

        }//End Else

    }//End GenerateTiles

    void GenerateSmallTileLeft()
    {

        yPos += yDiffSmall;
        xPos += xDiff;

        TilePrefab.tag = smallTag;
        Instantiate(TilePrefab, new Vector3(xPos, yPos, 0f), TilePrefab.transform.rotation);
        // print(xPosLeft);

    }//End GenerateSmallTile

    void GenerateBigTileLeft()
    {

        yPos += yDiffeBig;
        xPos += xDiff;

        TilePrefab.tag = bigTag;

        Instantiate(TilePrefab, new Vector3(xPos, yPos, 0f), TilePrefab.transform.rotation);

        // print(xPosLeft);

    }//End GenerateBigTile

    void GenerateSmallTileRight()
    {

        yPos += yDiffSmall;
        xPos += xDiff;

        TilePrefab.tag = smallTag;
        Instantiate(TilePrefab, new Vector3(xPos, yPos, 0f), TilePrefab.transform.rotation);
        //print(xPosRight);

    }//End GenerateSmallTile

    void GenerateBigTileRight()
    {

        yPos += yDiffeBig;
        xPos += xDiff;

        TilePrefab.tag = bigTag;

        Instantiate(TilePrefab, new Vector3(xPos, yPos, 0f), TilePrefab.transform.rotation);

        //  print(xPosRight);

    }//End GenerateBigTile


    void GenerateSmallTileLeft2()
    {

        yPos += yDiffSmall;
        xPos -= xDiff;

        TilePrefab.tag = smallTag;


        Instantiate(TilePrefab, new Vector3(xPos, yPos, 0f), TilePrefab.transform.rotation);

    }//End GenerateSmallTile

    void GenerateBigTileLeft2()
    {

        yPos += yDiffeBig;
        xPos -= xDiff;

        TilePrefab.tag = bigTag;
        Instantiate(TilePrefab, new Vector3(xPos, yPos, 0f), TilePrefab.transform.rotation);

    }//End GenerateBigTile

    void GenerateSmallTileRight2()
    {

        yPos += yDiffSmall;
        xPos -= xDiff;

        TilePrefab.tag = smallTag;
        Instantiate(TilePrefab, new Vector3(xPos, yPos, 0f), TilePrefab.transform.rotation);

    }//End GenerateSmallTile

    void GenerateBigTileRight2()
    {

        yPos += yDiffeBig;
        xPos -= xDiff;

        TilePrefab.tag = bigTag;
        Instantiate(TilePrefab, new Vector3(xPos, yPos, 0f), TilePrefab.transform.rotation);

    }//End GenerateBigTile

}
