using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public KeyCode keyToPress;
    public float rescale;
    SpriteRenderer spriteRenderer;
    public Sprite mainSprite;
    public Sprite newSprite;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
           transform.localScale *= rescale;
            spriteRenderer.sprite = newSprite;
        }

        if(Input.GetKeyUp(keyToPress)){
           transform.localScale /= rescale;
           spriteRenderer.sprite = mainSprite;
        }
    }
}
