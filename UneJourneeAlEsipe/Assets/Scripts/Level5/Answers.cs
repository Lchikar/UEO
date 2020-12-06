using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct answer");
            /*var colors = quizManager.m_options[quizManager.m_indexAnswer].GetComponent<Button>().colors;
            colors.normalColor = Color.green;
            quizManager.m_options[quizManager.m_indexAnswer].GetComponent<Button>().colors = colors;*/
            quizManager.correct();
        } else
        {
            Debug.Log("Wrong answer");
            quizManager.wrong();
        }
    }
}
