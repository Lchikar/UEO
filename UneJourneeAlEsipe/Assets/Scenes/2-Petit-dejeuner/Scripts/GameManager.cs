using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 50;
    public int scorePerPerfectNote = 100;
    public GameHandler gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        startPlaying = false;

        instance = this;

        currentScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying) {
            if (true)//Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }

        GameObject.Find("ScoreText").GetComponent<UnityEngine.UI.Text>().text = "Score : " + currentScore;

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
