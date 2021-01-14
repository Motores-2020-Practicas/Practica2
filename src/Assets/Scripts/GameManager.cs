using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Publicas
    //Array de las escenas ordenadas
    public string[] scenesInOrder;
    //Enemigos en el nivel actual
    private int enemiesInLevel;

    //Privadas
    //Numero de vidas del jugador
    private int lives = 3;
    //Puntuacion del nivel actual del jugador
    private int levelScore = 0;
    //Puntuación total del jugador
    private int totalScore = 0;
    //Determina la escena actual
    private int stage = 0;
    //Singleton del GameManager
    private static GameManager instance;
    //Script asocaido al  canvas
    private UIManager ui_manager;

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
        Debug.Log(enemiesInLevel + "\n");
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
        ui_manager.Score(levelScore, totalScore, stage, playerWon);
    }

    //Gestiona la información necesaria para pasar al siguiente nivel
    public void NextLevel()
    {
        stage++;
        if (stage >= scenesInOrder.Length) 
        {
            stage = 0;
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
        lives = 3;
        levelScore = 0;
        enemiesInLevel = 0;
        stage = 0;
        levelScore = 0;
        totalScore = 0;
        ChangeScene(scenesInOrder[stage]);
    }
}
