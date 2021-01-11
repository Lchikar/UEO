﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int levelCount = 50; //how many level pieces to instantiate
    public new Camera camera = null;
    public GameObject guiGameOver = null;
    public LevelGenerator levelGenerator = null;
    private bool canPlay = false;

    private static Manager s_Instance;
    public static Manager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(Manager)) as Manager;
            }

            return s_Instance;
        }
    }

    void Start()
    {
        for (int i = 0; i < levelCount; i++)
        {
            levelGenerator.RandomGenerator();
        }
    }

    public bool CanPlay()
    {
        return canPlay;
    }

    public void StartPlay()
    {
        canPlay = true;
    }

    public void GameOver()
    {
        camera.GetComponent<CameraShake>().Shake();
        camera.GetComponent<CameraFollow>().enabled = false;

        GuiGameOver();
    }

    void GuiGameOver()
    {
        Debug.Log("Game over!");

        guiGameOver.SetActive(true);
    }

    public void PlayAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
