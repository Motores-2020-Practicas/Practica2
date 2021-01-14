using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Imagen referente a los enemigos que quedan
    public Image enemyIconPrefab;
    //Transform referente al panel de enemigos
    public RectTransform enemyPanel;
    
    public Text
        livesText,  //Muestra el número de vidas que quedan
        stageText,  //Muestra el nivel actual en la pantalla de información al ganar o perder
        levelScoreText, //Muestra la puntuación obtenida en el nivel al ganar o perder
        sessionScoreText;   //Muestra la puntuación total obtenida entre todos los niveles superados al ganar o perder
    //Número de enemigos que quedan vivos
    private int enemiesLeft;
    //Singleton del GameManager
    private GameManager instance;
    
    public GameObject
        infoPanel,  //GO referente al panel de información mostrado al ganar o perder
        gameOverPanel;  //GO referente al panel de GAME OVER que se muestra al perder

    void Start()
    {
        instance = GameManager.getInstance();
        instance.SetUIManager(this);
    }

    //Inicializa el Canvas con el número de vidas "numLives" y el número de enemigos "numEnemies"
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

    //Actualiza las vidas que quedan
    public void UpdateLives(int numLives)
    {
        livesText.text = numLives.ToString();
    }

    //Elimina un enemigo del panel de enemigos
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

    //Gestiona el panel de información al ganar o perder
    //Muestra la pntuación del nivel "levelScore", los puntos totales "sessionScore" y el nivel actual "level"
    //Dependiendo de playing se pasará al siguiente nivel si es true o se pierde si es false
    public void Score(int levelScore, int sessionScore, int level, bool playing)
    {
        stageText.text = level.ToString();
        levelScoreText.text = levelScore.ToString();
        sessionScoreText.text = sessionScore.ToString();
        infoPanel.SetActive(true);

        if (playing)
        {
            instance.NextLevel();
        }
        else {
            gameOverPanel.SetActive(true);
            instance.GameOver();
        }
    }
}
