using UnityEngine;

public class Ball : MonoBehaviour
{


    [SerializeField] Weapon weapon;
    public int ammunition = 3;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    public float xVelocity;
    float yVelocity = StaticControls.yVelocity;
    Vector2 paddleToBallVector;
    public bool hasStarted = false;
    private Animation anim;

    // cached component refs
    AudioSource myAudioSource;
    private Rigidbody2D myRigidBody2D;

    GameObject usedBall;

    // Start is called before the first frame update

    void Start()
    {
        ammunition = ammunition + StaticControls.extraAmmo;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        paddleToBallVector = transform.position - weapon.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LaunchOnClick();
            LockToPaddle();
        }
    }

    private void LockToPaddle()

    {

        myRigidBody2D.isKinematic = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        Vector2 paddlePos = new Vector2(weapon.transform.position.x, weapon.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnClick()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.y > Screen.height / 2)
            {
                weapon.GetComponent<Animator>().Play("WeaponShot", -1, 0f);
                ammunition--;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                hasStarted = true;
                myRigidBody2D.velocity = new Vector2(xVelocity, yVelocity);

            }

        }
    }

    public void stopBall()
    {
        myRigidBody2D.velocity = new Vector2(0, 0);
        myRigidBody2D.isKinematic = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;

        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        Debug.Log(transform.position);

        usedBall = new GameObject("used ball");
        usedBall.AddComponent<SpriteRenderer>();

        // GameObject usedBall = new GameObject();
        usedBall.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        usedBall.transform.position = transform.position;
        usedBall.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        if (ammunition > 0)
        {
            hasStarted = false;
            LockToPaddle();
        }
    }



    private void OnCollisionEnter2D(Collision2D audio)
    {
        Vector2 velocityTweak = new Vector2
        (Random.Range(0f, randomFactor),
        Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
