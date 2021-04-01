using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] KeyCode keyToPress;
    [SerializeField] Sprite mainSprite;
    [SerializeField] GameObject newSpriteObj;
    [SerializeField] float rescale;
    [SerializeField]  GameObject spriteRendererHandler;

    SpriteRenderer spriteRenderer;
    Sprite newSprite;
    Vector3 posTemp;
    Vector3 pos;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        newSprite = newSpriteObj.GetComponent<SpriteRenderer>().sprite;
        pos = spriteRendererHandler.transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            transform.localScale *= rescale;
            posTemp = newSpriteObj.transform.position;
            spriteRendererHandler.transform.position = posTemp;
            spriteRenderer.sprite = newSprite;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            transform.localScale /= rescale;
            spriteRendererHandler.transform.position = pos;
            spriteRenderer.sprite = mainSprite;
        }
    }
}
