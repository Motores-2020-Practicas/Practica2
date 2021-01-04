using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int lives = 3;
    private int score = 0;
    private static GameManager instance;

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

    public bool playerDestroyed()
    {
        lives--;
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

}
