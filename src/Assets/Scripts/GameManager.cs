using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Publicas
    public string[] scenesInOrder;          //Array de las escenas ordenadas

    //Privadas
    private int lives = 3;                  //Numero de vidas del jugador
    private int levelScore = 0;             //Puntuacion del nivel actual del jugador
    private int totalScore = 0;             //Puntuación total del jugador
    private int stage = 1;                  //Determina la escena actual
    private int enemiesInLevel;             //Enemigos en el nivel actual
    private static GameManager instance;    //Singleton del GameManager
    private UIManager ui_manager;           //Script asocaido al  canvas
    private PlayerController playerC;       //Referencia a PlayerController
    private GameObject enemies;             //Referencia a los enemigos del nivel

    //Para obtener el singleton desde otro script
    public static GameManager getInstance()
    {
        return instance;
    }

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

    //Referencia el UIManager
    public void SetUIManager(UIManager uim)
    {
        ui_manager = uim;
        ui_manager.Init(lives, enemiesInLevel);
    }

    //Para cambiar a la escena "sceneName"
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Devuelve true si el jugador mueres, false en caso contrario
    public bool PlayerDestroyed()
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

    //Suma puntos del enemigo a la puntuación y elimina al enemigo.
    public void EnemyDestroyed(int destructionPoints)
    {
        levelScore += destructionPoints;
        totalScore += destructionPoints;
        enemiesInLevel--;
        ui_manager.RemoveEnemy();
    }

    //Añade un enemigo al contador de enemigos cuando éste es creado
    public void AddEnemy()
    {
        enemiesInLevel++;
    }

    //Gestiona el final del nivel en caso de ganar o perder
    public void FinishLevel(bool playerWon)
    {
        //Desactiva los enemigos al finalizar el nivel
        if (enemiesInLevel > 0)
        {
            enemies = GameObject.Find("Enemies");
            enemies.SetActive(false);
        }
        //Desactiva la funcionalidad del player para que no se mueva al finalizar el nivel
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        playerC.enabled = false;

        ui_manager.Score(levelScore, totalScore, stage, playerWon);
    }

    //Gestiona la información necesaria para pasar al siguiente nivel
    public void NextLevel()
    {
        stage++;
        if (stage >= scenesInOrder.Length)
        {
            GameOver();
            ChangeScene(scenesInOrder[stage]);
            stage = 1;
        }
        else
        {
            levelScore = 0;
            lives = 3;
            enemiesInLevel = 0;
            ChangeScene(scenesInOrder[stage]);
        }
    }

    //Resetea el juego en caso de perder
    public void GameOver()
    {
        Time.timeScale = 1;
        lives = 3;
        levelScore = 0;
        enemiesInLevel = 0;
        stage = 0;
        levelScore = 0;
        totalScore = 0;
    }

    // Cierra la aplicacion
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }
}
