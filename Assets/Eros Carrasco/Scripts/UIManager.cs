using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private GameObject ScanCanvas;
    [SerializeField] private GameObject LvlSelectCanvas;
    [SerializeField] private GameObject SnakeCanvas;
    [SerializeField] private GameObject GameOverCanvas;
    void Start()
    {
        GameManager.instance.OnTutorial += ActivateTutorial;
        GameManager.instance.OnLevelCreated += ActivateLevelRelocation;

        GameManager.instance.OnScan += ActivateScan;
        GameManager.instance.OnLevelSelect += ActivateLevelMenu;
        GameManager.instance.OnSnake += ActivateSnake;
        GameManager.instance.OnRestartSnake += ActivateSnake;
        GameManager.instance.OnGameOver += ActivateGameOver;

        ActivateTutorial();
    }

    

    private void ActivateTutorial()
    {
        tutorialCanvas.SetActive(true); //true
        ScanCanvas.SetActive(false);
        LvlSelectCanvas.SetActive(false);
        SnakeCanvas.SetActive(false); //false
        GameOverCanvas.SetActive(false);
    }
    private void ActivateLevelRelocation()
    {
        tutorialCanvas.SetActive(false);
        LvlSelectCanvas.SetActive(false);
        ScanCanvas.SetActive(true);
        SnakeCanvas.SetActive(false); 
        GameOverCanvas.SetActive(false);
    }
    private void ActivateScan()
    {
        tutorialCanvas.SetActive(false);
        ScanCanvas.SetActive(true);
        LvlSelectCanvas.SetActive(false);
        SnakeCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
    }

    private void ActivateLevelMenu()
    {
        tutorialCanvas.SetActive(false);
        ScanCanvas.SetActive(false);
        LvlSelectCanvas.SetActive(true);
        SnakeCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
    }
    private void ActivateSnake()
    {
        tutorialCanvas.SetActive(false);
        ScanCanvas.SetActive(false);
        LvlSelectCanvas.SetActive(false);
        SnakeCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
    }
    private void ActivateGameOver()
    {
        tutorialCanvas.SetActive(false);
        ScanCanvas.SetActive(false);
        LvlSelectCanvas.SetActive(false);
        SnakeCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);
    }
}
