using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GameObject TilePrefab;
    private float xDiff = 1.1f;
    private float yDiffSmall = 0.5f;
    private float yDiffeBig = 1.4f;
    private float xPos = -2.5f;
    private float xPosLeft = -1.0f;
    private float xPosRight = 0.1f;
    private float yPos = -4.5f;
    public int random2;
    //-2.5f;
    //-4.5f;

    private string smallTag = "smallTile";
    private string bigTag = "bigTile";

    public bool side = false;
    //false = left
    //true = right
    public bool firstJump = true;

    void Start()
    {

        for (int i = 0; i < 2; i++)
        {
            GenerateTiles();
        }

    }//End Start

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
                    if (random2 <= 2)
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


                    if (random2 <= 2)
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

                    if (random2 <= 2)
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


                    if (random2 <= 2)
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
                side = false;
            }
            else
            {
                side = true;
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
        print(xPosRight);

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
