using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour

{

    public Animator animator;
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    [SerializeField] Sprite[] hitSprites;
    // cached ref
    Level level;
    GameStatus status;

    // state vars
    [SerializeField] int timesHit;
    private void Start()
    {
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().enabled = false;
        }
        status = FindObjectOfType<GameStatus>();
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        TriggerSparklesVFX();
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            animator.SetBool("Destroyed", true);
            GetComponent<Animator>().enabled = true;

        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        animator.SetBool("MoreThanOneHit", true);

        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            Debug.Log("next sprite loaded");
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {

        Debug.Log("block Destroyed");
        PlayDestroySFX();
        status.AddToScore();

        Destroy(gameObject);


    }

    private void PlayDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.OnBlockDestroyed();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
