using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialPlayer : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    private bool skinSpring, skinNormal;

    public BoxCollider2D m_Collider;
    float m_ScaleX, m_ScaleY, m_ScaleZ;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        skinNormal = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNormal;
        skinSpring = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinSpring;
        print("SKIN NORMAL EN MATERIAL: " + skinNormal);
        print("SKIN SPRING EN MATERIAL: " + skinSpring);

        if (skinNormal == true || skinSpring == false)
        {
            rend.sharedMaterial = material[0];
            transform.position = new Vector3(-1.4f, 5.72f, 0f);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);


            m_Collider = GetComponent<BoxCollider2D>();
            m_ScaleX = 1.0f;
            m_ScaleY = 1.0f;
            m_Collider.size = new Vector2(m_ScaleX, m_ScaleY);
        }
        else
        {
            rend.sharedMaterial = material[1];
            transform.position = new Vector3(-0.053f, 5.72f, 0f);
            transform.localScale = new Vector3(0.91875f, 0.91875f, 0.5f);


            // size.GetComponent<Transform>();
            // print("SIZE: " + size.GetComponent<Transform>());

            // transform.localScale.x = 5f;

            m_Collider = GetComponent<BoxCollider2D>();
            m_ScaleX = 0.54f;
            m_ScaleY = 0.54f;
            m_Collider.size = new Vector2(m_ScaleX, m_ScaleY);

        }

    }

    // Update is called once per frame
    void Update()
    {
        skinNormal = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinNormal;
        skinSpring = GameObject.Find("SkinManager").GetComponent<SkinManager>().skinSpring;

        if (skinSpring == false)
        {
            rend.sharedMaterial = material[0];
        }
        else
        {
            rend.sharedMaterial = material[1];

        }
    }
}
