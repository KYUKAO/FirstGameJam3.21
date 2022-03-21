using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : BaseUnit
{
    Rigidbody2D rb;
    public float m_rayLength;
    Vector2 direction = Vector2.zero;
    public float IdleSpeed;
    public float ChaseSpeed;
    public float FindFoodSpeed;
    GameObject player;
    float timer = 0;
    float timer2 = 0;
    public float IntervalIdleTime;
    public float IntervalChangeDirectionTime;
    int playerLevel;
    float damage;
    float nutrition;
    PlayerControl playerControl;
    public GameObject EventSystem;
    // Start is called before the first frame update
    void Start()
    {
        int randLevel = Random.Range(1, 9);
        Level = randLevel;
        ChageAppearance();
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        timer2 = 0;
        damage = 10;
        nutrition = Level*100* playerControl.LevelUpRate / 2;
    }
    public enum EnemyState
    {
        Idle,
        HeadForFood,
        HeadForPlayer,
    }
    public EnemyState CurrentState;
    // Update is called once per frame
    void Update()
    {
        //switch (CurrentState)
        //{  
        timer2 = timer2 += Time.deltaTime;
        //    case EnemyState.Idle:
        if (timer2 >= IntervalChangeDirectionTime)
        {
            timer2 = 0;
            float rand1 = Random.Range(-1, 1.1f);
            float rand2 = Random.Range(-1, 1.1f);
            direction = new Vector2(rand1, rand2);
            rb.velocity = direction * IdleSpeed;
        }

                
                //return;
            //case EnemyState.HeadForPlayer:
            //    timer += Time.deltaTime;
            //    direction = (player.transform.position - this.transform.position).normalized;
            //    rb.velocity = direction * ChaseSpeed;
            //    if (timer >= IntervalTime)
            //    {
            //        timer = 0;
            //        CurrentState = EnemyState.Idle;
            //    }
            //    return;
            //case EnemyState.HeadForFood:
            //    rb.velocity = direction * FindFoodSpeed;
            //    return;
        //}


        //if (CurrentState == EnemyState.Idle)
        //{
        //    if (Level >= playerLevel)
        //    {
        //        if (FindPlayer(Vector2.right, ref direction) || FindPlayer(-Vector2.right, ref direction) || FindPlayer(Vector2.up, ref direction) || FindPlayer(-Vector2.up, ref direction))

        //        {
        //            CurrentState = EnemyState.HeadForPlayer;
        //            Debug.Log("sdfsdf");
        //        }
        //    }
        //    else if (FindFood(Vector2.right, ref direction) || FindFood(-Vector2.right, ref direction) || FindFood(Vector2.up, ref direction) || FindFood(-Vector2.up, ref direction))
        //    {
        //        CurrentState = EnemyState.HeadForFood;
        //        Debug.Log("sdfsdf");
        //    }
        //}
    }
    bool FindFood(Vector2 rayDirection, ref Vector2 direction)
    {
        Vector2 rayStart = new Vector2(transform.position.x, transform.position.y);
        Debug.DrawRay(rayStart, rayDirection * m_rayLength);
        RaycastHit2D ray = Physics2D.Raycast(rayStart, rayDirection, m_rayLength);
        if (ray.collider != null)
        {
            if (ray.collider.GetComponent<FoodComponent>() != null)
            {
                direction = (ray.collider.transform.position - this.transform.position).normalized;
                Debug.Log("Hit");
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    bool FindPlayer(Vector2 rayDirection, ref Vector2 direction)
    {
        Vector2 rayStart = new Vector2(transform.position.x, transform.position.y);
        Debug.DrawRay(rayStart, rayDirection * m_rayLength);
        RaycastHit2D ray = Physics2D.Raycast(rayStart, rayDirection, m_rayLength);
        if (ray.collider != null)
        {
            if (ray.collider.GetComponent<PlayerControl>() != null)
            {
                direction = (ray.collider.transform.position - this.transform.position).normalized;
                Debug.Log("Hit");
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerLevel = player.GetComponent<PlayerControl>().Level;
        if (collision.gameObject.GetComponent<FoodComponent>() != null)
        {
            direction = Vector2.zero;
            ElementInstantiator.CurrentNumOfFood--;
            Destroy(collision.gameObject);
            //CurrentState = EnemyState.Idle;
        }
        else if(collision.gameObject.GetComponent<PlayerControl>() != null)
        {
            if (Level > playerLevel)
            {
                player.GetComponent<PlayerControl>().CurrentHealth -= damage;
            }
            else if (Level <= playerLevel)
            {
                player.GetComponent<PlayerControl>().CurrentXP += nutrition;
                ElementInstantiator.CurrentNumOfEnemy--;
                Destroy(this.gameObject);
            }
        }
        else
        {
            timer2 = IntervalChangeDirectionTime;
        }
    }
}
