using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class QTE : MonoBehaviour
{
    [SerializeField] GameObject displayBox;
    [SerializeField] GameObject m_passBox;
    [SerializeField] GameHandler gameHandler;
    [SerializeField] AudioClip goodAnswer;
    [SerializeField] AudioClip wrongAnswer;
    AudioSource audioSource;

    private int m_QTGen;
    private int m_waitingKey;
    private int m_correctKey;
    private int m_countingDown;
    private int m_score = 0;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (m_waitingKey == 0)
        {
            m_QTGen = Random.Range(1, 5);
            m_countingDown = 1;
            StartCoroutine(CountDown());
            switch (m_QTGen)
            {
                case 1:
                    m_waitingKey = 1;
                    displayBox.GetComponent<Text>().text = "[E]";
                    break;
                case 2:
                    m_waitingKey = 2;
                    displayBox.GetComponent<Text>().text = "[S]";
                    break;
                case 3:
                    m_waitingKey = 3;
                    displayBox.GetComponent<Text>().text = "[I]";
                    break;
                case 4:
                    m_waitingKey = 4;
                    displayBox.GetComponent<Text>().text = "[P]";
                    break;
                default:
                    break;
            }
        }

        if(m_QTGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    m_correctKey = 1;
                   
                }
                StartCoroutine(KeyPressing());
            }
        }
        if (m_QTGen == 2)
        {

            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    m_correctKey = 1;
                   
                }
                StartCoroutine(KeyPressing());
            }
        }
        if (m_QTGen == 3)
        {

            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.I))
                {
                    m_correctKey = 1;
                }
                StartCoroutine(KeyPressing());
            }
        }
        if (m_QTGen == 4)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    m_correctKey = 1;
                }
                StartCoroutine(KeyPressing());
            }
        }

        if(m_score == 5)
        {
            gameHandler.LoadLevel("Petit-dejeuner");
        }
    }

    IEnumerator KeyPressing()
    {
        m_QTGen = 5;
        if (m_correctKey == 1)
        {
            m_countingDown = 2;
            m_passBox.GetComponent<Text>().text = "PASS";
            audioSource.clip = goodAnswer;
            audioSource.Play(0);
            m_score += 1;
            
        }
        else if (m_correctKey != 1)
        {
            m_passBox.GetComponent<Text>().text = "FAIL";
            audioSource.clip = wrongAnswer;
            audioSource.Play(0);
        }

        yield return new WaitForSeconds(1.5f);
        m_correctKey = 0;
        m_passBox.GetComponent<Text>().text = "";
        displayBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1.5f);
        m_waitingKey = 0;
        m_countingDown = 1;
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3.0f);
        if(m_countingDown == 1)
        {
            m_QTGen = 5;
            m_countingDown = 2;
            m_passBox.GetComponent<Text>().text = "FAIL";
            yield return new WaitForSeconds(1.5f);
            m_correctKey = 0;
            m_passBox.GetComponent<Text>().text = "";
            displayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            m_waitingKey = 0;
            m_countingDown = 1;
        } 
    }


}
