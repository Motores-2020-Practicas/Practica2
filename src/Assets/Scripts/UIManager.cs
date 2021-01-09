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
    private float x;
    private float y;
    private GameManager instance;

    void Start()
    {
        instance = GameManager.getInstance();
        instance.SetUIManager(this);
    }

    public void Init(int numLives, int numEnemies)
    {
        x = 0.0f;
        y = 0.0f;
        for (int i = 0; i < numEnemies; i++)
        {
            Image icon = Instantiate(enemyIconPrefab, new Vector3(x, y, 0), Quaternion.identity);
            if (i % 2 == 0.0f)
            {
                x += enemyIconPrefab.transform.localScale.x;
            }
            else
            {
                x = 0.0f;
                y += enemyIconPrefab.transform.localScale.y;
            }

            icon.transform.SetParent(enemyPanel, true);
        }
        enemiesLeft = numEnemies;

        livesText.text = numLives.ToString();
    }

    public void UpdateLives(int numLives)
    {
        livesText.text = numLives.ToString();
    }

    public void RemoveEnemy()
    {
        if (enemiesLeft > 0)
        {
            if (enemyPanel != null)
            {
                enemyPanel.GetChild(enemiesLeft).gameObject.SetActive(false);
                enemiesLeft--;
            }
        }
    }
}
