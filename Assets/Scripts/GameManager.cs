using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TMP_Text scoreText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "Score : " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;

        if(score < 0)
            score = 0;

        scoreText.text = "Score : " + score;
    }
}