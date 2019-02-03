using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeShareButton : MonoBehaviour
{

    public Button ShareButton;

    public Sprite ShareIconIOS;
    public Sprite ShareIconAndroid;


    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        ShareButton.GetComponent<Image>().sprite = ShareIconAndroid;
        ShareButton.image.rectTransform.sizeDelta = new Vector2(100, 110);

        //this.gameObject.GetComponent<SpriteRenderer>().sprite = ShareIconIOS;

#elif UNITY_IPHONE
            ShareButton.GetComponent<Image>().sprite = ShareIconIOS;
            ShareButton.image.rectTransform.sizeDelta = new Vector2(100, 100);
       
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = ShareIconAndroid;
#endif
    }

    void Update()
    {

    }
}
