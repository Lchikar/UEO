using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLidsAnimation : MonoBehaviour
{
    public Animator topLid;
    public Animator bottomLid;

    private float time;
    public float freqBlink;

    void Stard()
    {
        time = 0;
    }

    private void Blink()
    {
        topLid.Play("topLid");
        bottomLid.Play("bottomLid");

        topLid.Play("Default");
        bottomLid.Play("Default");
    }

    void  Update()
    {
        time += Time.deltaTime;
        while(time >= freqBlink)
        {
            Blink();
            time -= freqBlink;
        }
    }

    
    //void Update()
    //{
    //    if (Input.anyKeyDown)
    //    {
    //        topLid.Play("topLid");
    //        bottomLid.Play("bottomLid");

    //        topLid.Play("Default");
    //        bottomLid.Play("Default");
    //    }
    //}
}
