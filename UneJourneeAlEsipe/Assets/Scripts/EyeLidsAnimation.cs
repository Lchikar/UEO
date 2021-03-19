using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLidsAnimation : MonoBehaviour
{
    public Animator topLid;
    public Animator bottomLid;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            topLid.Play("topLid");
            bottomLid.Play("bottomLid");

            topLid.Play("Default");
            bottomLid.Play("Default");
        }
    }
}
