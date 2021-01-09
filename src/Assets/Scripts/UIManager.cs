using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image enemyIconPrefab;
    public RectTransform enemyPanel;
    public Text livesText;

    private int enemiesLeft;
    private GameManager instance;

    void Start()
    {
        instance = GameManager.getInstance();
        instance.SetUIManager(this);
    }

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

    public void UpdateLives(int numLives)
    {
        livesText.text = numLives.ToString();
    }

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
}
