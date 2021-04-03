using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<Database> m_database;
    public GameObject[] m_options;
    public int m_currentQuestion;
    public Text m_questionText;
    public Text m_scoreText;
    public GameObject m_quizPanel;
    public GameObject m_gameObjectPanel;

    private int m_totalQuestions = 0;
    private int m_score;

    public void StartGame()
    {
        m_totalQuestions = m_database.Count;
        m_gameObjectPanel.SetActive(false);
        GenerateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        m_quizPanel.SetActive(false);
        m_gameObjectPanel.SetActive(true);
        m_scoreText.text = m_score.ToString() + '/' + m_totalQuestions.ToString();
    }


    public void correct()
    {
        m_score += 1;
        m_database.RemoveAt(m_currentQuestion);
        GenerateQuestion();
    }
    public void wrong()
    {
        m_database.RemoveAt(m_currentQuestion);
        GenerateQuestion();
    }

    void SetAnswers()
    {
        for(int i = 0; i < m_options.Length; i++)
        {
            m_options[i].GetComponent<Image>().color = Color.white;
            m_options[i].GetComponent<Button>().interactable = true;
            m_options[i].transform.GetChild(0).GetComponent<Text>().text = m_database[m_currentQuestion].m_answers[i];
            if (m_database[m_currentQuestion].m_correctAnswer == i)
            {
                m_options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion() {
        if(m_database.Count > 0)
        {
            m_currentQuestion = Random.Range(0, m_database.Count);
            m_questionText.text = m_database[m_currentQuestion].m_questions;
            SetAnswers();
        } else
        {
            GameOver();
        }

    }
}
