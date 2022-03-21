using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 ms = Input.mousePosition;
            ms = Camera.main.ScreenToWorldPoint(ms);//��ȡ������λ��
                                                    //�����λ��
            Vector3 gunPos = this.transform.position;
            float fireangle;//����Ƕ�
                            //�������λ�������λ��֮��ĽǶ�
            Vector2 targetDir = ms - gunPos;
            fireangle = Vector2.Angle(targetDir, Vector3.up);
            if (ms.x > gunPos.x)
            {
                fireangle = -fireangle;
            }
            this.transform.eulerAngles = new Vector3(0, 0, fireangle);
            Vector2 direction = ms.normalized;
            rb.velocity = direction * Speed;
        }
    }
}