using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverPanel;
    public GameObject winPanel;

    private void Awake()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}