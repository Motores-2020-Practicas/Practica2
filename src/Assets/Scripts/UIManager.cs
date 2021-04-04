using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase que gestiona la lógica del UI
/// </summary>
public class UIManager : MonoBehaviour
{
    //Publcias
    //Icono de los enemigos restantes
    public Image enemyIconPrefab;
    //Transform referente al panel de enemigos
    public RectTransform enemyPanel;
    //Componentes de texto
    public Text
        //Muestra el número de vidas que quedan
        livesText,
        //Muestra el nivel actual en la pantalla de información al ganar o perder
        stageText,
        //Muestra la puntuación obtenida en el nivel al ganar o perder
        levelScoreText,
        //Muestra la puntuación total obtenida entre todos los niveles superados al ganar o perder
        sessionScoreText;
    //GameObjects
    public GameObject
        //GO referente al panel de información mostrado al ganar o perder
        infoPanel,
        //GO referente al panel de GAME OVER que se muestra al perder
        gameOverPanel;

    //Privadas
    //Número de enemigos que quedan vivos
    private int enemiesLeft;
    //Singleton del GameManager
    private GameManager instance;

    void Start()
    {
        instance = GameManager.getInstance();
        instance.SetUIManager(this);
    }

    /// <summary>
    /// Inicializa el Canvas
    /// </summary>
    /// <param name="numLives">
    /// Número de vidas del jugador
    /// </param>
    /// <param name="numEnemies">
    /// Número de enemigos totales
    /// </param>
    public void Init(int numLives, int numEnemies)
    {
        for (int i = 0; i < numEnemies; i++)
        {
            Image icon = Instantiate(enemyIconPrefab);

            icon.rectTransform.SetParent(enemyPanel);
        }

        enemiesLeft = numEnemies - 1;

        livesText.text = numLives.ToString();
    }

    /// <summary>
    /// ACtualiza las vidas que quedan
    /// </summary>
    public void UpdateLives(int numLives)
    {
        livesText.text = numLives.ToString();
    }

    /// <summary>
    /// Elimina un enemigo del panel
    /// </summary>
    public void RemoveEnemy()
    {
        if (enemiesLeft >= 0)
        {
            if (enemyPanel != null)
            {
                enemyPanel.GetChild(enemiesLeft).gameObject.SetActive(false);
            }
            enemiesLeft--;
        }
    }

    /// <summary>
    /// Gestiona el panel de información al ganar o perder
    /// </summary>
    /// <param name="levelScore">
    /// Puntos conseguidos en el nivel
    /// </param>
    /// <param name="sessionScore">
    /// Puntos totales conseguidos
    /// </param>
    /// <param name="level">
    /// Nivel actual superado
    /// </param>
    /// <param name="playing">
    /// Para saber si el jugador ha ganado o ha perdido
    /// </param>
    public void Score(int levelScore, int sessionScore, int level, bool playing)
    {
        stageText.text = level.ToString();
        levelScoreText.text = levelScore.ToString();
        sessionScoreText.text = sessionScore.ToString();
        infoPanel.SetActive(true);

        if (!playing)
        {
            Invoke("GameOver", 5);
        }
    }

    /// <summary>
    /// Muestra panel Game Over
    /// </summary>
    void GameOver()
    {
        infoPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
