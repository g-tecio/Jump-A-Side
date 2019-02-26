using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    float yPos;
    Generator _Generator;

    void Start()
    {

        yPos = transform.position.y;
        _Generator = GameObject.Find("TilesGenerator").GetComponent<Generator>();

    }//End Start

    void Update()
    {

        if (gameObject.tag == "smallTile")
        {
            //transform.position.y < yPos - 10
            if (transform.position.y < yPos - .75) //.75
            {
                Destroy(this.gameObject);
                _Generator.GenerateTiles();
            }
        }
        if (gameObject.tag == "bigTile")
        {
            //transform.position.y < yPos - 10
            if (transform.position.y < yPos - 1.5) //1.5
            {
                Destroy(this.gameObject);
                _Generator.GenerateTiles();
            }
        }

    }//End Update
}
