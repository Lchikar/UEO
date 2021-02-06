﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour
{
    public GameObject displayBox;
    public GameObject m_passBox;
    public int m_QTGen;
    public int m_waitingKey;
    public int m_correctKey;
    public int m_countingDown;

    // Update is called once per frame
    void Update()
    {
        if(m_waitingKey == 0)
        {
            m_QTGen = Random.Range(1, 4);
            m_countingDown = 1;
            StartCoroutine(CountDown());
            switch(m_QTGen)
            {
                case 1:
                    m_waitingKey = 1;
                    displayBox.GetComponent<Text>().text = "[E]";
                    break;
                case 2:
                    m_waitingKey = 1;
                    displayBox.GetComponent<Text>().text = "[R]";
                    break;
                case 3:
                    m_waitingKey = 1;
                    displayBox.GetComponent<Text>().text = "[T]";
                    break;
                default:
                    break;
            }
        }

        if(m_QTGen == 1)
        {
            if(Input.anyKeyDown)
            {
                if(Input.GetButtonDown("EKey"))
                {
                    m_correctKey = 1;
                    StartCoroutine(KeyPressing());
                } else
                {
                    m_correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (m_QTGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("RKey"))
                {
                    m_correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    m_correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (m_QTGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("TKey"))
                {
                    m_correctKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    m_correctKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        m_QTGen = 4;
        m_countingDown = 2;
        
        if (m_correctKey == 1)
        {
            m_passBox.GetComponent<Text>().text = "PASS";
            
        }
        else if (m_correctKey == 2)
        {
            m_passBox.GetComponent<Text>().text = "FAIL";
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
        yield return new WaitForSeconds(3f);
        if(m_countingDown == 1)
        {
            m_QTGen = 4;
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