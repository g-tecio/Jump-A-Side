using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetectorRight : MonoBehaviour {


    private float doubleClickTimeLimit = 0.35f;
    bool clickedOnce = false;
    public string singleTapMove;
    public string doubleTapMove;
    float count = 0f;

    public Player scriptPlayer;

    public void startClick()
    {
        StartCoroutine(ClickEvent());
    }

    public IEnumerator ClickEvent()
    {
        if (!clickedOnce && count < doubleClickTimeLimit)
        {
            clickedOnce = true;
        }
        else
        {
            clickedOnce = false;
            yield break;  //If the button is pressed twice, don't allow the second function call to fully execute.
        }
        yield return new WaitForEndOfFrame();

        while (count < doubleClickTimeLimit)
        {
            if (!clickedOnce)
            {
                DoubleClick();
                count = 0f;
                clickedOnce = false;
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
        SingleClick();
        count = 0f;
        clickedOnce = false;
    }
    private void SingleClick()
    {
        Debug.Log("Single Click");
        //Right Short Jump
        scriptPlayer.jumpSmallRight();
    }

    private void DoubleClick()
    {
        Debug.Log("Double Click");
        //Right Long Jump
        scriptPlayer.jumpLongRight();

    }
}
