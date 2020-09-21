using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public Ball ball;
    public Animator animator;
    // private Rigidbody2D rb;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    // Start is called before the first frame update
    bool animationPlayed = false;


    private void animationFinished()
    {
        animationPlayed = false;
    }

    void rotateLeft()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);

    }
    void rotateRight()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);
            if (touch.position.x < Screen.width / 2 && touch.position.y < Screen.height / 2)
            {
                Debug.Log("touch input left");
                paddlePos.x = paddlePos.x - 0.1f;
                transform.position = paddlePos;
                if (animationPlayed == false)
                {
                    ball.xVelocity = -1f;
                    rotateLeft();
                    animator.Play("PlayerWalk", 0, 0f);
                    animationPlayed = true;
                }
            }
            else if (touch.position.x > Screen.width / 2 && touch.position.y < Screen.height / 2)
            {
                Debug.Log("touch input right");
                paddlePos.x = paddlePos.x + 0.1f;
                transform.position = paddlePos;
                if (animationPlayed == false)
                {
                    ball.xVelocity = 1f;
                    rotateRight();
                    animator.Play("PlayerWalk", 0, 0f);
                    animationPlayed = true;
                }
            }
        }

        // float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        // Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        // paddlePos.x = Mathf.Clamp(mousePos, minX, maxX);
        // transform.position = paddlePos;
        // float mouseX = Input.GetAxis("Mouse X");



        // if (mouseX < 0)
        // {
        //     if (animationPlayed == false)
        //     {
        //         ball.xVelocity = -1f;
        //         rotateLeft();
        //         animator.Play("PlayerWalk", 0, 0f);
        //         animationPlayed = true;
        //     }


        // }
        // if (mouseX > 0)
        // {

        //     if (animationPlayed == false)
        //     {
        //         ball.xVelocity = 1f;
        //         rotateRight();
        //         animator.Play("PlayerWalk", 0, 0f);
        //         animationPlayed = true;
        //     }

        // }



    }
}
