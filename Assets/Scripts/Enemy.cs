using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int damage;

    private float stopTime;
    public float startStopTime;
    private float normalSpeed;
    private ManController player;
    private Animator anim;

    public void TakeDamage(int damage)
    {
        health -= damage;
        stopTime = startStopTime;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<ManController>();
        normalSpeed = speed;
        timeBtwAttack = startTimeBtwAttack;
    }

    // Update is called once per frame
    private void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("attackKusKus");
                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void onEnemyAttack()
    {
        player.health -= damage;
    }
}
