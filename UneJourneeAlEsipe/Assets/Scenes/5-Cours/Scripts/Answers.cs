using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

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
            StartCoroutine("CorrectTimer", 2);
        } else
        {
            Debug.Log("Wrong answer");
            StartCoroutine("WrongTimer", 2);
        }
    }
}
