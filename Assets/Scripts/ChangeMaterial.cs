using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    private bool skinSpring, skinNormal;
    private bool skinNormalOnce, skinSpringOnce;
    public BoxCollider2D m_Collider;
    float m_ScaleX, m_ScaleY;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //  rend.sharedMaterial = material[0];
        skinNormal = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNormal;
        skinSpring = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinSpring;
        skinSpringOnce = true;
        skinNormalOnce = true;

        if (skinNormal == true || skinSpring == false)
        {
            rend.sharedMaterial = material[0];
            transform.localScale = new Vector3(1.0F, 9.0875f, 1.0f);
            //Fetch the Collider from the GameObject
            m_Collider = GetComponent<BoxCollider2D>();
            //These are the starting sizes for the Collider component
            m_ScaleX = 1.0f;
            m_ScaleY = 1.0f;
            m_Collider.size = new Vector2(m_ScaleX, m_ScaleY);



        }
        else
        {
            rend.sharedMaterial = material[1];
            transform.localScale = new Vector3(2.4625F, 9.0875f, 1.0f);
            //Fetch the Collider from the GameObject
            m_Collider = GetComponent<BoxCollider2D>();
            //These are the starting sizes for the Collider component
            m_ScaleX = 0.4f;
            m_ScaleY = 1.0f;
            m_Collider.size = new Vector2(m_ScaleX, m_ScaleY);



        }
    }

    // Update is called once per frame
    void Update()
    {
        skinNormal = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNormal;
        skinSpring = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinSpring;

        if (skinNormal == true && skinNormalOnce == true)
        {
            rend.sharedMaterial = material[0];
            skinNormalOnce = false;
        }
        if (skinNormal == true && skinSpringOnce == true)
        {
            rend.sharedMaterial = material[0];
            skinSpringOnce = false;
        }
    }
}
