using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    public Ball ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ball.stopBall();
        if (ball.ammunition <= 0)
        {
            SceneManager.LoadScene("EndGame");
        }
    }

}
