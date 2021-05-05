using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Publicas
    //Array de las escenas ordenadas
    public string[] scenesInOrder;

    //Privadas
    //Numero de vidas del jugador
    private int lives = 3;
    //Puntuacion del nivel actual del jugador
    private int levelScore = 0;
    //Puntuación total del jugador
    private int totalScore = 0;
    //Determina la escena actual
    private int stage;
    //Enemigos en el nivel actual
    private int enemiesInLevel = 0;
    //Singleton del GameManager
    private static GameManager instance;
    //Script asocaido al  canvas
    private UIManager ui_manager;
    // Cantidad de segundos a esperar para pasar de nivel
    const float waitSeconds = 8;

    /// <summary>
    /// DEvuelve el singleton creado de GM
    /// </summary>
    public static GameManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    //Referencia el UIManager
    /// <summary>
    /// Asigna el nuevo UIManager
    /// </summary>
    public void SetUIManager(UIManager uim)
    {
        ui_manager = uim;
        ui_manager.Init(lives, enemiesInLevel);
    }

    /// <summary>
    /// Cambia de escenas en funcion de un nombre
    /// </summary>
    /// <param name="sceneName">
    /// Nombe de la escena nueva
    /// </param>
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Gestiona la muerte del jugador
    /// </summary>
    /// <returns>
    /// En caso de que muera y le quede vidan al player devuelve false
    /// si no, devuelve true
    /// </returns>
    public bool PlayerDestroyed()
    {
        lives--;
        //ui_manager.UpdateLives(lives);
        if (lives <= 0)
        {
            FinishLevel(false);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gestiona la suma de puntos al morir un enemigo
    /// </summary>
    public void EnemyDestroyed(int destructionPoints)
    {
        levelScore += destructionPoints;
        totalScore += destructionPoints;
        enemiesInLevel--;
        if (ui_manager)
        {
            ui_manager.RemoveEnemy();
        }
    }

    /// <summary>
    /// Añade un enemigo al contador cuando se crea uno nuevo
    /// </summary>
    public void AddEnemy()
    {
        enemiesInLevel++;
    }

    //Gestiona el final del nivel en caso de ganar o perder
    /// <summary>
    /// Gestiona el final del nivel.
    /// </summary>
    public void FinishLevel(bool playerWon)
    {
        if (ui_manager)
        {
            ui_manager.Score(levelScore, totalScore, stage, playerWon);

            //Si el jugador pierde o si ya no quedan mas escenas
            //se vuelve al main menu
            if (!playerWon || stage >= scenesInOrder.Length - 1)
            {
                Invoke("GameOver", waitSeconds);
            }
            else
            {
                Invoke("NextLevel", waitSeconds);
            }
        }
    }

    /// <summary>
    /// Cambia de nivel
    /// </summary>
    public void NextLevel()
    {
        stage++;
        levelScore = 0;
        enemiesInLevel = 0;
        ChangeScene(scenesInOrder[stage]);
    }

    /// <summary>
    /// Reinicia las variables necesarias
    /// cuando se pierde
    /// </summary>
    private void GameOver()
    {
        Time.timeScale = 1;
        lives = 3;
        enemiesInLevel = 0;
        stage = 0;
        levelScore = 0;
        totalScore = 0;

        ChangeScene(scenesInOrder[stage]);
    }

    /// <summary>
    /// Cierra el juego
    /// </summary>
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }
}
