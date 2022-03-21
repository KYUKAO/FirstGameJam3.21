using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : BaseUnit
{
    Rigidbody2D rb;
    public float Speed;
    public float IncreaseRate;
    public float DecreaseRate;

    public float CurrentHealth = 100;
    public float MaxHealth = 100f;

    public float CurrentXP = 0;
    public float LevelXP;
    public float LevelUpRate;


    public GameObject LoseCondition;

    public Slider HealthBar;
    public Slider EXBar;
    public Text LevelText;
    public GameObject EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = CurrentHealth / MaxHealth;
        EXBar.value = CurrentXP / LevelXP;
        LevelText.text="LEVEL :"+Level;
        #region MOVEMENT
        Vector3 ms = Input.mousePosition;
        //ms = Camera.main.ScreenToWorldPoint(ms);//获取鼠标相对位置
        //                                        //对象的位置
        //Vector3 gunPos = this.transform.position;
        //float fireangle;//发射角度
        //                //计算鼠标位置与对象位置之间的角度
        //Vector2 targetDir = ms - gunPos;
        //fireangle = Vector2.Angle(targetDir, Vector3.up);
        //if (ms.x > gunPos.x)
        //{
        //    fireangle = -fireangle;
        //}
        Vector3 targetPos = Camera.main.WorldToScreenPoint(this.transform.position);
        float fireangle;
        Vector2 targetDir = ms - targetPos;
        fireangle = Vector2.Angle(targetDir, Vector3.up);
        if (ms.x > targetPos.x)
        {
            fireangle = -fireangle;
        }
        this.transform.eulerAngles = new Vector3(0, 0, fireangle);
            Vector2 direction = targetDir.normalized;
            rb.velocity = direction * Speed;
        if (Input.GetMouseButton(0))
        {
            rb.velocity = direction * Speed * (1 + IncreaseRate);
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = direction * Speed;
        }
        #endregion

        #region HealthSystem
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
        #endregion

  
        #region LevelUp

        if (CurrentXP >= LevelXP)
        {
            CurrentXP = 0;
            LevelXP *= LevelUpRate;
            Level++;
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
            CurrentXP=CurrentXP+ addXP;
            EventSystem.GetComponent<ElementInstantiator>().CurrentNumOfFood--;
            Destroy(collision.gameObject);
        }
    }
}