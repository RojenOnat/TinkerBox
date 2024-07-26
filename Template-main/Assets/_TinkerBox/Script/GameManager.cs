using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int TotalLevelCount;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        InitLevel();
    }

    public void SuccesLoadLevel()
    {
        var current = GetSavedKey() + 1;
        if (current >= TotalLevelCount) current = 2;
        SaveLevelKey(current);
        LoadScene(current);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SuccesLoadLevel();
        }
    }

    public void FailLoadLevel()
    {
        var current = GetSavedKey();
        LoadScene(current);
    }
    public void InitLevel()
    {
        var count = GetSavedKey();
        if (count == 0)
        {
            count = 2;
            SaveLevelKey(2);
        }
        LoadScene(count);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SaveLevelKey(int key) => PlayerPrefs.SetInt("_SavedLevel", key);
    public int GetSavedKey() => PlayerPrefs.GetInt("_SavedLevel");
}