using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    private bool startPlaying = false;

    public BeatScroller theBS;
    public GameObject notes;

    public static GameManager instance;

    public Text score;
    public int currentScore;
    public int scorePerNote = 50;
    public int scorePerPerfectNote = 100;
    public GameHandler gameHandler;

    // Start is called before the first frame update
    public void startGame()
    {
        startPlaying = true;

        instance = this;

        currentScore = 0;

    }


    // Update is called once per frame
    void Update()
    {
        if(notes.transform.position.y <= -31f)
        {
            Debug.Log("\tTry again");

            notes.transform.position = new Vector3(0, 5.3f, -2.8f);
            for (int i = 0; i < notes.transform.childCount; i++)
            {
                notes.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        if (startPlaying) {
            if (true)//Input.anyKeyDown)
            {
                startPlaying = false;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }

        score.text = "Score : " + currentScore;

        if (currentScore >= 1000)
        {
            gameHandler.LoadLevel("Level3");
        }
    }

    public void NoteHit(int quality)
    {

        if (quality == 0)
        {
            currentScore += scorePerNote;
            Debug.Log("\tHit");
        }
        else { 
            currentScore += scorePerPerfectNote;
            Debug.Log("\tHit Perfect");
        }
        
    }

    public void NoteMissed()
    {
        Debug.Log("\tMissed note");

    }
}
