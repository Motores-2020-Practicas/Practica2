using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int lives = 3;
    private int score = 0;
    private int enemiesInLevel = 0;
    private static GameManager instance;
    private UIManager ui_manager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetUIManager(UIManager uim)
    {
        ui_manager = uim;
        ui_manager.Init(3, 2);
    }

    public bool playerDestroyed()
    {
        lives--;
        ui_manager.UpdateLives(lives);
        if (lives <= 0)
        {
            FinishLevel(false);
            return true;
        }

        return false;
    }

    public void EnemyDestroyed(int destructionPoints)
    {
        score += destructionPoints;
        enemiesInLevel--;
        ui_manager.RemoveEnemy();
    }

    public void FinishLevel(bool playerWon)
    {
        Debug.Log("Lvel finished: " + playerWon);
    }

    public static GameManager getInstance()
    {
        return instance;
    }

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void AddEnemy()
    {
        enemiesInLevel++;
    }
}
