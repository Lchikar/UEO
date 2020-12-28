using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public KeyCode keyToPress;
    public float rescale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
           transform.localScale *= rescale;
        }

        if(Input.GetKeyUp(keyToPress)){
           transform.localScale /= rescale;
        }
    }
}
