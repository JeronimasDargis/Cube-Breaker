using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI ammunition;
    [SerializeField] Ball ball;

    // state vars
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()

    {
        ammunition.text = "AMMO: " + ball.ammunition.ToString();
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()

    {
        ammunition.text = "AMMO: " + ball.ammunition.ToString();
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
        StaticControls.balance = StaticControls.balance + pointsPerBlock;
    }

    public void ResetScore()
    {

        Destroy(gameObject);
    }
}
