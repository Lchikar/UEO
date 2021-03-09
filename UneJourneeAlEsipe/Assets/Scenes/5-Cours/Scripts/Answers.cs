using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public AudioClip audioWin;
    public AudioClip audioLoose;
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    IEnumerator CorrectTimer(float seconds)
    {
        GetComponent<Image>().color = Color.green;
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(seconds);
        quizManager.correct();
    }

    IEnumerator WrongTimer(float seconds)
    {
        GetComponent<Image>().color = Color.red;
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(seconds);
        quizManager.wrong();
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct answer");
            audioSource.clip = audioWin;
            audioSource.Play(0);
            StartCoroutine("CorrectTimer", 1);
        } else
        {
            Debug.Log("Wrong answer");
            audioSource.clip = audioLoose;
            audioSource.Play(0);
            StartCoroutine("WrongTimer", 1);
        }
    }
}
