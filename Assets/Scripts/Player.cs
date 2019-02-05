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
    private bool Grounded = false;
    private Animator anim;
    public GameObject dustParticle;
    private bool firstJump = true;
    private float prevYpos = -1000;
    public bool isDead = false;
    private bool locaSide = true;
    //false = left
    //true = right

    //UI
    public GameObject gameOverScreen, panelGameScene, tile;
    public GameObject bigButton;
    public GameObject smallButton;
    public GameObject bigButton2;
    public GameObject smallButton2;

    //public GameObject deadEffectPrefab;

    //Score Text
    public TextMeshProUGUI scoreText;

    //Change Color
    Color[] standColor = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };
    private char lastJump = 'N';
    int colorIndex;
    int Acheivemnt = 2;

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

    }//End Start

    void Update()
    {

        if (GameObject.Find("Tile(Clone)") && isDead == true)
        {
            // print("Ahí esta");

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
        if (transform.position.y + 2f < prevYpos)
        {
            if (!isDead)
            {
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

        Grounded = false;
        lastJump = 'S';

        //rb.AddForce(new Vector2(9.8f * 12f, 9.8f * 20f));
        rb.AddForce(new Vector2(-(9.7f * 10f), 9.8f * 21.5f));

    }//End jumpSmall

    IEnumerator longJumpLeft()
    {

        //rb.AddForce(new Vector2(0,9.8f * 32 o 29f));
        //yield return new WaitForSeconds(0.15f);
        rb.AddForce(new Vector2(0, 9.7f * 29f));
        yield return new WaitForSeconds(0.25f);
        rb.AddForce(new Vector2(-(9.7f * 14f), 0));

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

        Grounded = false;

        lastJump = 'S';

        //   rb.AddForce(new Vector2(9.8f * 12f, 9.8f * 20f));
        //  rb.AddForce(new Vector2(9.8f * 12f, 9.8f * 21.5f));
        rb.AddForce(new Vector2(9.7f * 10f, 9.8f * 21.5f));

    }//End jumpSmall

    IEnumerator longJumpRight()
    {

        //rb.AddForce(new Vector2(0,9.8f * 32 o 29f));
        //yield return new WaitForSeconds(0.15f);
        rb.AddForce(new Vector2(0, 9.7f * 29f));
        yield return new WaitForSeconds(0.25f);
        rb.AddForce(new Vector2(9.7f * 14f, 0));

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

        Grounded = false;
        lastJump = 'B';

        StartCoroutine(longJumpRight());

    }//End jumplong

    private void OnCollisionEnter2D(Collision2D col)
    {

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
            if (GameObject.Find("Tile(Clone)") != null)
            {

                Destroy(GameObject.Find("Tile(Clone)"));
                Destroy(GameObject.FindWithTag("smallTile"));
                Destroy(GameObject.FindWithTag("BigTile"));


            }
            isDead = true;
            if (gameOverScreen == false)
            {
                audiLose.Play();
            }
            gameOverScreen.SetActive(true);
            panelGameScene.gameObject.SetActive(false);

            GameObject gameTile = GameObject.Find("Tile(Clone)");
            gameTile.GetComponent<Animator>().enabled = true;


            // tile.gameObject.SetActive(false);





            GameObject gradientbackground = GameObject.Find("PanelImageBackground");
            gradientbackground.GetComponent<BackgroundMove>().enabled = false;


            //bigButton.SetActive(false);
            //smallButton.SetActive(false);
            // bigButton2.SetActive(false);
            // smallButton2.SetActive(false);
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
                cr.material.SetColor("_Color", Color.black);
            }
            else
            {

                //Change Color
                GameObject cube = col.gameObject;
                Renderer cr = cube.GetComponent<Renderer>();
                cr.material.SetColor("_Color", Color.black);

            }

            prevYpos = transform.position.y;

            GameObject temp = Instantiate(dustParticle, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), dustParticle.transform.rotation);
            Destroy(temp, 1.5f);

            Grounded = true;

            //transform.position = new Vector3(col.gameObject.transform.position.x-0.2f , transform.position.y, transform.position.z);
            transform.position = new Vector3(col.gameObject.transform.position.x, transform.position.y, transform.position.z);

            if (firstJump)
            {
                StartCoroutine(FallTile(col.gameObject, 2.35f));
                // rb.AddForce(new Vector2(10.7f * 30f, 9.8f * 21.5f));
                //return;
            }
            else
            {
                StartCoroutine(FallTile(col.gameObject, 2.35f));
                //   rb.AddForce(new Vector2(10.7f * 30f, 9.8f * 21.5f));
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
            //StartCoroutine(FallTile(col.gameObject));
            Destroy(col.gameObject);
        }

    }//End CollisionExit2D

    IEnumerator FallTile(GameObject col, float fall)
    {

        if (isDead == true)
        {

            yield return new WaitForSeconds(0.1f);
            if (col.gameObject != null)
                col.AddComponent<Rigidbody2D>();
            // rb.AddForce(new Vector2(80.7f * 80f, 9.8f * 21.5f));
            print("YA TE MORISTE MEN, NOMÁS NO TE HAN AVISADO");
            Destroy(col.gameObject);
        }
        else
        {

            //yield return new WaitForSeconds(1f)
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
        GameObject gradientbackground = GameObject.Find("PanelImageBackground");
        gradientbackground.GetComponent<BackgroundMove>().enabled = false;

        GameObject gameMainCamera = GameObject.Find("Main Camera");
        gameMainCamera.GetComponent<CameraFollow>().enabled = false;

        GameObject gameTile = GameObject.Find("Tile(Clone)");
        //gameTile.GetComponent<Animator>().enabled = true;
       
        panelGameScene.SetActive(false);

        Destroy(GameObject.Find("Tile(Clone)"));

        if (GameObject.Find("Tile(Clone)") != null)
        {
            Destroy(GameObject.Find("Tile(Clone)"));
            Destroy(GameObject.FindWithTag("smallTile"));
            Destroy(GameObject.FindWithTag("BigTile(Clone)"));
        }
        gameOverScreen.SetActive(true);


      //  Destroy(Instantiate(deadEffectPrefab, transform.position, Quaternion.identity), 1.0f);

        panelGameScene.gameObject.SetActive(false);
        // tile.gameObject.SetActive(false);
        // bigButton.SetActive(false);
        // smallButton.SetActive(false);
        //  bigButton2.SetActive(false);
        // smallButton2.SetActive(false);
        print("Player die");
        isDead = true;
        Destroy(pp);
    }//End Death
}
