using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badboy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float speed;
    public int health;
    private int maxHealth;
    public int damage;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    public playerControl player;
    Transform playertrans; // ГГ 
    private Animator anim;
    private Rigidbody2D rb;

    public int positionOfPatrol;
    public Transform point;
    bool moveingRight;
    private bool attack = false; 

    public float stoppingDistance;

    //bool chill = false;
    bool angry = false;
    //bool goBack = false;
    bool faceRight = true;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        player = FindObjectOfType<playerControl>();
        rb = GetComponent<Rigidbody2D>();
        normalSpeed = speed;
        playertrans = GameObject.FindGameObjectWithTag("Player").transform;
        maxHealth = health;
    }

    void Update()
    {
        //остановление при получения атаки
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
        }
        if(attack)
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("attack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }


        //if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        //{
        //    Debug.Log("c");
        //    chill = true;
        //}
        //if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance)
        //{
        //    angry = true;
        //    chill = false;
        //    goBack = false;
        //}
        //if (Vector2.Distance(transform.position, player.transform.position) > stoppingDistance)
        //{
        //    goBack = true;
        //    angry = false;
        //}
        //Т.к. в нашей игре мобам нет обходимости патрулировать то, была добавлена следующая строка
        angry = true;

        if (angry == true)
        {
            Angry();
        }
        //else if (chill == true)
        //{
        //    Chill();
        //}
        //else if (goBack == true)
        //{
        //    GoBack();
        //}

    }

    //void Chill()
    //{
    //    if (transform.position.x > point.position.x + positionOfPatrol)
    //    {
    //        moveingRight = false;
    //    }
    //    else if (transform.position.x < point.position.x + positionOfPatrol)
    //    {
    //        moveingRight = true;

    //    }
    //    if (moveingRight)
    //    {
    //        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    //    }
    //    else
    //    {
    //        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    //    }
    //}

    void flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 0);
        faceRight = !faceRight;

    }
    void Angry()
    {
        if(Mathf.Abs(transform.position.x - playertrans.position.x) > 2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playertrans.position, speed * Time.deltaTime);
            if ((transform.position.x - playertrans.position.x) > 0.1f && faceRight)
            {
                flip();
            }
            else if ((transform.position.x - playertrans.position.x) < 0.1f && !faceRight)
            {
                flip();
            }
            anim.SetBool("run", true);
        }
        else
        {
            anim.SetBool("run", false);

        }
        

    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -= damage;
        //anim.Play("hurt");
        rb.AddForce(transform.right * 1000 * player.faceRight());
        anim.SetTrigger("hurt");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attack = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attack = false;
        }
    }
    public void OnEnemyAttack()
    {
        print("attack GG");
        player.GetComponent<playerControl>().takeDamage(damage);
        timeBtwAttack = startTimeBtwAttack;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

}
