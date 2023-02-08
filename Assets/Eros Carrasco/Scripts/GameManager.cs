using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public event Action OnTutorial;
    public event Action OnScan;
    public event Action OnLevelSelect;
    public event Action OnSnake;
    public event Action OnGameOver;
    public event Action OnRestartSnake;


    public event Action OnLevelCreated;
    public event Action OnLevelPlaced;
    public event Action OnLevelRemoved;

    public event Action OnLvl1Selected;
    public event Action OnLvl2Selected;
    public event Action OnLvl3Selected;

    public event Action OnARPosition;

    public static GameManager instance;

    public int score;
    public bool mapPlaced = false;

    //public UnityAction ARPosition { get; internal set; }

    private void Awake()
    {
        if (instance!=null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void ARPosition()
    {
        OnARPosition?.Invoke();
        Debug.Log("ARPosition Activated");
    }
    public void Tutorial()
    {
        OnTutorial?.Invoke();
        Debug.Log("Tutorial Activated");
        score = 0;
        mapPlaced = false;
    }

    public void StartScan()
    {
        OnScan?.Invoke();
        Debug.Log("Scanning Activated");
        mapPlaced = false;
    }

    public void LevelSelect()
    {
        OnLevelSelect?.Invoke();
        Debug.Log("Placing Levels Activated");
    }
    public void StartSnake()
    {
        OnSnake?.Invoke();
        Debug.Log("Scanning Activated");
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        Debug.Log("GameOver Activated");
    }

    public void RestartGame()
    {
        OnRestartSnake?.Invoke();
        Debug.Log("Restarting SnakeGame");
        score = 0;
    }

    public void Lvl1Selected()
    {
        OnLvl1Selected?.Invoke();
        Debug.Log("Lvl 1 Selected");
        OnScan?.Invoke();
    }
    public void Lvl2Selected()
    {
        OnLvl2Selected?.Invoke();
        Debug.Log("Lvl 2 Selected");
        OnScan?.Invoke();
    }
    public void Lvl3Selected()
    {
        OnLvl3Selected?.Invoke();
        Debug.Log("Lvl 3 Selected");
        OnScan?.Invoke();
    }
    public void LevelCreated()
    {
        OnLevelCreated?.Invoke();
        Debug.Log("Level Selected");
    }

    public void LevelPlaced()
    {
        OnLevelPlaced?.Invoke();
        Debug.Log("Level Placed");
    }
    public void LevelRemoved()
    {
        OnLevelRemoved?.Invoke();
        Debug.Log("Level Removed");
    }
    public void ExitApp()
    {
        Debug.Log("Exiting App");
        Application.Quit();
    }
}
