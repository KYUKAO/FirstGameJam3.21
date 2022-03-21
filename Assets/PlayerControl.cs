using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    public float IncreaseRate;
    public float DecreaseRate;

    float currentHealth = 100;
    float maxHealth = 100f;

    float currentXP = 0;
    public float LevelXP;
    public float LevelUpRate;
    int level = 1;

    public GameObject LoseCondition;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        #region MOVEMENT
        Vector3 ms = Input.mousePosition;
            ms = Camera.main.ScreenToWorldPoint(ms);//获取鼠标相对位置
                                                    //对象的位置
            Vector3 gunPos = this.transform.position;
            float fireangle;//发射角度
                            //计算鼠标位置与对象位置之间的角度
            Vector2 targetDir = ms - gunPos;
            fireangle = Vector2.Angle(targetDir, Vector3.up);
            if (ms.x > gunPos.x)
            {
                fireangle = -fireangle;
            }
            this.transform.eulerAngles = new Vector3(0, 0, fireangle);
            Vector2 direction = ms.normalized;
            rb.velocity = direction * Speed;
        if (Input.GetMouseButton(0))
        {
            rb.velocity = direction * Speed * (1 + IncreaseRate);
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = direction * Speed * (1 - DecreaseRate);
        }
        #endregion

        #region HealthSystem
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        #endregion

        #region LevelUp

        if (currentXP >= LevelXP)
        {
            currentXP = 0;
            LevelXP *= LevelUpRate;
            level++;
        }
        #endregion
    }
    void Die()
    {
        Debug.Log("Dead");
        LoseCondition.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<FoodComponent>() != null)
        {
            var addXP = collision.gameObject.GetComponent<FoodComponent>().AddXP;
            currentXP=currentXP+ addXP;
            Debug.Log(currentXP);
            Destroy(collision.gameObject);
        }
    }
}