using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    [SerializeField] float respawnDelay = 3f;
    [SerializeField] float duration = 1.5f;
    [SerializeField] bool isBreaking;
    [SerializeField] bool isRespawned = true;

    [SerializeField] Transform target;

    float timeToDestroy;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        timeToDestroy = duration;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        target = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        spriteRenderer.color = new Color(1, 1, 1, timeToDestroy / duration);

        if (isBreaking)
        {
            BreakingMovement();
        }
        else if (isRespawned)
        {
            timeToDestroy = duration;
        }
    }

    Vector3 finalPos;
    float moveSpeed;

    private void BreakingMovement()
    {
        timeToDestroy -= Time.deltaTime;

        target.localPosition = Vector3.Lerp(target.localPosition, finalPos, moveSpeed);

        if (Vector3.Distance(target.localPosition, finalPos) < 0.05f || finalPos == null)
        {
            finalPos = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
            moveSpeed = Random.Range(0.01f, 0.03f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isRespawned && !isBreaking)
        {
            timeToDestroy = duration;
            isBreaking = true;
            Invoke("DestroyPlatform", duration);
            Invoke("RespawnPlatform", respawnDelay);
        }
    }
    void DestroyPlatform()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        isBreaking = false;
        isRespawned = false;
    }
    void RespawnPlatform ()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        isRespawned = true;
    }
}
