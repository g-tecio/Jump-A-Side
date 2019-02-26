using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    //Gameplay
    public GameObject pp;
    private Rigidbody2D rb;
    public float fallMultiplier = 14.5f;
    public bool Grounded = false;
    private Animator anim;
    public GameObject dustParticle;
    private bool firstJump = true;
    private float prevYpos = -1000;
    public bool isDead = false;
    private bool locaSide = true;
    //UI
    public GameObject gameOverScreen, panelGameScene, tile, clickDetector;

    //public GameObject deadEffectPrefab;

    //Score Text
    public TextMeshProUGUI scoreText;

    //Change Color
    Color[] standColor = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };
    private char lastJump = 'N';
    int colorIndex;
    int Acheivemnt = 2;

    private bool skinSpring, skinNormal;

    //Sounds
    private AudioSource audiJump;
    private AudioSource audiLose;

    void Start()
    {
        audiJump = GetComponent<AudioSource>();
        audiLose = gameOverScreen.GetComponent<AudioSource>();

        Time.timeScale = 1.5f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Grounded = true;

    }//End Start

    void Update()
    {

        skinNormal = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNormal;
        skinSpring = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinSpring;

        //  print("GROUNDED: " + Grounded);

        if (isDead == true)
        {
            print("MUERTO POR JUGARLE AL VALIENTE");
        }


        if (GameObject.Find("Tile(Clone)") && isDead == true)
        {
            //print("MUERTO POR JUGARLE AL VALIENTE");

            Destroy(GameObject.Find("Tile(Clone)"));
        }


        /*
    if (gameOverScreen.gameObject.activeInHierarchy == true)
    {
        GameObject gameTile = GameObject.Find("Tile(Clone)");
        gameTile.GetComponent<Animator>().enabled = true;
    }
    */
        //(transform.position.y + 5f < prevYpos)
        //print("CUBE POSITION AT THE BEGINING: " + transform.position.y);
        //print("CUBE POSITION AT THE BEGINING: " + transform.position.y);
        //print("PREVIOUS CUBE POSITION: " + prevYpos);

        if (transform.position.y + 0.01f < prevYpos)
        {
            print("CAN'T APPLY ANY FORCE TO THE CUBE");
            //print("CUBE POSITION: " + transform.position.y);
            //print("PREV POSITION: " + prevYpos);

        }

        if (transform.position.y + 0.2f < prevYpos)
        {
            clickDetector.gameObject.SetActive(false);
            rb.AddForce(new Vector2(0f * 0f, 0f * 0f));
            if (!isDead)
            {

                GameObject playerBoxCollider = GameObject.Find("Player");
                playerBoxCollider.GetComponent<BoxCollider2D>().enabled = false;

                Death();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            lastJump = 'S';
            Jump(true);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            lastJump = 'B';
            Jump(false);

        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        }

    }// End Update

    public void Jump(bool smallJump)
    {

        firstJump = false;
        anim.enabled = true;

        if (!Grounded)
        {
            print(Grounded);
            return;

        }

        //Play animation
        anim.SetTrigger("Jump");

        Grounded = false;

        if (smallJump == true)
        {
            print(locaSide);
            lastJump = 'S';
            if (locaSide == false)
            {
                jumpSmallLeft();
                print("Hola 1");
            }
            else
            {
                jumpSmallRight();
                print("Hola 2");
            }
        }
        else
        {
            lastJump = 'B';
            if (locaSide == false)
            {
                StartCoroutine(longJumpLeft());
                print("Hola 3");
            }
            else
            {
                StartCoroutine(longJumpRight());
                print("Hola 4");
            }

        }

        if (locaSide == true)
        {
            locaSide = false;
        }
        else
        {
            locaSide = true;
        }

    }//End Jump

    public void jumpSmallLeft()
    {
        firstJump = false;


        if (!Grounded)
        {
            print(Grounded);
            return;

        }

        //Play animation
        anim.SetTrigger("Jump");
        GameObject cube = GameObject.Find("Player");
        Vector3 newScale = cube.transform.localScale;

        if (skinSpring == false)
        {

        }
        else
        {
            newScale.x = -0.91875f;
            cube.transform.localScale = newScale;
        }


        Grounded = false;
        lastJump = 'S';

        //rb.AddForce(new Vector2(9.8f * 12f, 9.8f * 20f));


        if (skinSpring == false)
        {
            rb.AddForce(new Vector2(-(9.5f * 10f), 9.8f * 21.5f));
        }
        else
        {
            rb.AddForce(new Vector2(-(20.5f * 10f), 9.8f * 21.5f));
        }



    }//End jumpSmall

    IEnumerator longJumpLeft()
    {

        //rb.AddForce(new Vector2(0,9.8f * 32 o 29f));
        //yield return new WaitForSeconds(0.15f);
        rb.AddForce(new Vector2(0, 9.8f * 29f));
        yield return new WaitForSeconds(0.25f);


        if (skinSpring == false)
        {
            rb.AddForce(new Vector2(-(9.8f * 14f), 0));
        }
        else
        {
            rb.AddForce(new Vector2(-(12.8f * 24f), 0));
        }


    }//End longJump


    public void jumpLongLeft()
    {
        firstJump = false;


        if (!Grounded)
        {
            print(Grounded);
            return;
        }

        //Play animation
        anim.SetTrigger("Jump");
        GameObject cube = GameObject.Find("Player");
        Vector3 newScale = cube.transform.localScale;

        if (skinSpring == false)
        {

        }
        else
        {
            newScale.x = -0.91875f;
            cube.transform.localScale = newScale;
        }


        Grounded = false;

        lastJump = 'B';
        StartCoroutine(longJumpLeft());


    }//End jumpLong



    public void jumpSmallRight()
    {
        firstJump = false;


        if (!Grounded)
        {
            print(Grounded);
            return;
        }

        //Play animation
        anim.SetTrigger("Jump");
        GameObject cube = GameObject.Find("Player");
        Vector3 newScale = cube.transform.localScale;

        if (skinSpring == false)
        {

        }
        else
        {
            newScale.x = 0.91875f;
            cube.transform.localScale = newScale;
        }
        Grounded = false;

        lastJump = 'S';

        //   rb.AddForce(new Vector2(9.8f * 12f, 9.8f * 20f));
        //  rb.AddForce(new Vector2(9.8f * 12f, 9.8f * 21.5f));


        if (skinSpring == false)
        {
            rb.AddForce(new Vector2(9.5f * 10f, 9.8f * 21.5f));
        }
        else
        {
            rb.AddForce(new Vector2(20.5f * 10f, 9.8f * 21.5f));
        }


    }//End jumpSmall

    IEnumerator longJumpRight()
    {

        //rb.AddForce(new Vector2(0,9.8f * 32 o 29f));
        //yield return new WaitForSeconds(0.15f);
        rb.AddForce(new Vector2(0, 9.8f * 29f));
        yield return new WaitForSeconds(0.25f);


        if (skinSpring == false)
        {
            rb.AddForce(new Vector2(9.8f * 14f, 0));
        }
        else
        {
            rb.AddForce(new Vector2(12.8f * 24f, 0));
        }


    }//End longJump


    public void jumpLongRight()
    {
        firstJump = false;


        if (!Grounded)
        {
            return;
        }

        //Play animation
        anim.SetTrigger("Jump");
        GameObject cube = GameObject.Find("Player");
        Vector3 newScale = cube.transform.localScale;

        if (skinSpring == false)
        {

        }
        else
        {
            newScale.x = 0.91875f;
            cube.transform.localScale = newScale;
        }
        Grounded = false;
        lastJump = 'B';

        StartCoroutine(longJumpRight());


    }//End jumplong

    private void OnCollisionEnter2D(Collision2D col)
    {
        // print("CUBE POSITION ON COLLISION: " + transform.position.y);
        rb.velocity = Vector3.zero;

        if (lastJump == 'S' && col.gameObject.tag == "smallTile")
        {

        }
        else if (lastJump == 'B' && col.gameObject.tag == "bigTile")
        {

        }
        else if (lastJump == 'N')
        {

        }
        else
        {
            print("Wrong Jump - Game Over!");

            isDead = true;
            gameOverScreen.SetActive(true);
            panelGameScene.gameObject.SetActive(false);

            if (gameOverScreen == false)
            {
                audiLose.Play();
            }


            if (GameObject.Find("Tile(Clone)") != null)
            {
                Destroy(GameObject.Find("Tile(Clone)"));
                Destroy(GameObject.FindWithTag("smallTile"));
                Destroy(GameObject.FindWithTag("BigTile"));
            }



            GameObject gameTile = GameObject.Find("Tile(Clone)");
            gameTile.GetComponent<Animator>().enabled = true;




            if (skinSpring == true)
            {
                print("DESTRUIR BACKGROUND DE ABEJAS");
                GameObject backgroundBee = GameObject.Find("PanelImageBackgroundBee");
                backgroundBee.GetComponent<BackgroundMove>().enabled = false;
            }
            else
            {
                GameObject gradientbackground = GameObject.Find("PanelImageBackground");
                gradientbackground.GetComponent<BackgroundMove>().enabled = false;
            }


            Destroy(pp);
        }

        //Random Color
        colorIndex = Random.Range(0, 3);

        if (col.gameObject.tag.Contains("Tile"))
        {

            if (!isDead)
            {
                //UpdateScore
                // scoreText.text = (int.Parse(scoreText.text) + 1).ToString();

                GameObject.Find("GameManager").GetComponent<ScoreManager>().AddScore();

                //Play Sound
                audiJump.Play();

                //Change Color
                GameObject cube = col.gameObject;
                Renderer cr = cube.GetComponent<Renderer>();


                if (skinNormal == true || skinSpring == false)
                {
                    cr.material.SetColor("_Color", Color.black);
                }

                if (skinSpring == true)
                {
                    cr.material.SetColor("_Color", Color.magenta);
                }

            }
            else
            {

                //Change Color
                GameObject cube = col.gameObject;
                Renderer cr = cube.GetComponent<Renderer>();
                if (skinNormal == true || skinSpring == false)
                {
                    cr.material.SetColor("_Color", Color.black);
                }

                if (skinSpring == true)
                {
                    cr.material.SetColor("_Color", Color.magenta);
                }

            }

            prevYpos = transform.position.y;

            GameObject temp = Instantiate(dustParticle, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), dustParticle.transform.rotation);
            Destroy(temp, 1.5f);

            Grounded = true;

            //transform.position = new Vector3(col.gameObject.transform.position.x-0.2f , transform.position.y, transform.position.z);
            transform.position = new Vector3(col.gameObject.transform.position.x, transform.position.y, transform.position.z);

            if (firstJump)
            {
                StartCoroutine(FallTile(col.gameObject, 2.1f));

            }
            else
            {
                StartCoroutine(FallTile(col.gameObject, 2.8f));

            }
        }

        //Make a Color Path 
        //AcheivementAcheived();

    }// End OnCollisionEnter2D

    void AcheivementAcheived()
    {

        if (int.Parse(scoreText.text) == Acheivemnt)
        {
            if (colorIndex >= standColor.Length - 1)
            {
                colorIndex = 0;
            }
            else
            {
                colorIndex++;
            }
            Acheivemnt = Acheivemnt * 2;
        }

    }//End AcheivementAcheived

    private void OnCollisionExit2D(Collision2D col)
    {

        if (col.gameObject.tag == "Tile")
        {

            //  Destroy(col.gameObject);
        }

    }//End CollisionExit2D

    IEnumerator FallTile(GameObject col, float fall)
    {

        if (isDead == true)
        {

            yield return new WaitForSeconds(2.8f);
            if (col.gameObject != null)
                col.AddComponent<Rigidbody2D>();

            print("PLATAFORMA DESTRUIDA");
            // Destroy(col.gameObject);
        }
        /* 
        else
        {
            print("PLATAFORMA DESTRUIDA");
            yield return new WaitForSeconds(2f);
            //yield return new WaitForSeconds(fall);
            if (col.gameObject != null)
                col.AddComponent<Rigidbody2D>();
        }
*/

        if (Grounded == true || fall > 2.8f)
        {
            print("FALL VALUE: " + fall);
            yield return new WaitForSeconds(fall);
            if (col.gameObject != null)
                col.AddComponent<Rigidbody2D>();
        }



    }//End FalTile

    void Death()
    {
        if (gameOverScreen == false)
        {
            audiLose.Play();
        }



        if (skinSpring == true)
        {
            GameObject backgroundBee = GameObject.Find("PanelImageBackgroundBee");
            backgroundBee.GetComponent<BackgroundMove>().enabled = false;
        }
        else
        {
            GameObject gradientbackground = GameObject.Find("PanelImageBackground");
            gradientbackground.GetComponent<BackgroundMove>().enabled = false;
        }



        GameObject gameMainCamera = GameObject.Find("Main Camera");
        gameMainCamera.GetComponent<CameraFollow>().enabled = false;

        panelGameScene.SetActive(false);
        //Destroy(pp);
        Destroy(GameObject.Find("Tile(Clone)"));

        if (GameObject.Find("Tile(Clone)") != null)
        {
            Destroy(GameObject.Find("Tile(Clone)"));
            Destroy(GameObject.FindWithTag("smallTile"));
            Destroy(GameObject.FindWithTag("BigTile"));
        }

        gameOverScreen.SetActive(true);

        GameObject playerBoxCollider = GameObject.Find("Player");
        playerBoxCollider.GetComponent<BoxCollider2D>().enabled = false;

        //  Destroy(Instantiate(deadEffectPrefab, transform.position, Quaternion.identity), 1.0f);

        panelGameScene.gameObject.SetActive(false);

        print("Player die");
        isDead = true;
        Destroy(pp);
    }//End Death
}
