using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(keyToPress)){
            if (canBePressed)
            {
                gameObject.SetActive(false);
                
                if(-4.4f <= transform.position.y && transform.position.y <= -3.6f)
                    GameManager.instance.NoteHit(1);
                else
                    GameManager.instance.NoteHit(0);
            }
            GameManager.instance.NoteMissed();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Activator"){
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Activator"){
            canBePressed = false;

            GameManager.instance.NoteMissed();
        }
    }
}
