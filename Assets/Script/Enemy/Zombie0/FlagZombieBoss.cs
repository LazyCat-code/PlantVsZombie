using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagZombieBoss : ZombieEnemy
{
    public Vector3 direction = new Vector3(-1, 0, 0);
    private bool isWalk;
    private Animator animator;

    public float damageInterval = 0.5f;

    private float damageTimer;  // �������ʱ��
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        isWalk = true; //�Ƿ�����ƶ�
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isWalk)
        {
            transform.position += direction * Speed * Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ı���ɫ
        if (collision.tag == "FireBullet" && collision.GetType().ToString() == "UnityEngine.BoxCollider2D" || 
            collision.tag == "Bullet" && collision.GetType().ToString() == "UnityEngine.BoxCollider2D" || 
            collision.tag == "CatBullet" && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            StartCoroutine(ChangeColor());
        }

        if (collision.tag == "Sun" || collision.tag == "pea" || collision.tag == "WallNut" || collision.tag == "Torchwood"|| 
            collision.tag == "GatlingPea" || collision.tag == "Cattail")
        {
            isWalk = false;
            animator.SetBool("Walk", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Sun")
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                // ��SunFlower ʵ�����ٵ��ÿ�Ѫ
                collision.GetComponent<SunFlower>().DamegePlayer(damage);
                // ��ȡֲ��ĵ�ǰѪ��
                int CurrentPlayerhealth = collision.GetComponent<SunFlower>().CurrentHealth();
                if (CurrentPlayerhealth <= 0)
                {
                    // ��ʼ�ƶ�
                    isWalk = true;
                    animator.SetBool("Walk", true);
                }
            }
        }

        if (collision.tag == "pea")
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                // ��ֲ�� ʵ�����ٵ��ÿ�Ѫ
                collision.GetComponent<Peashooter>().DamegePlayer(damage);
                // ��ȡֲ��ĵ�ǰѪ��
                int CurrentPlayerhealth = collision.GetComponent<Peashooter>().CurrentHealth();
                if (CurrentPlayerhealth <= 0)
                {
                    // ��ʼ�ƶ�
                    isWalk = true;
                    animator.SetBool("Walk", true);
                }
            }
        }
        if (collision.tag == "WallNut")
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                // ��ֲ�� ʵ�����ٵ��ÿ�Ѫ
                collision.GetComponent<WallNut>().DamegePlayer(damage);
                // ��ȡֲ��ĵ�ǰѪ��
                int CurrentPlayerhealth = collision.GetComponent<WallNut>().CurrentHealth();
                if (CurrentPlayerhealth <= 0)
                {
                    // ��ʼ�ƶ�
                    isWalk = true;
                    animator.SetBool("Walk", true);
                }
            }
        }
        if (collision.tag == "Torchwood")
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                // ��ֲ�� ʵ�����ٵ��ÿ�Ѫ
                collision.GetComponent<Torchwoods>().DamegePlayer(damage);
                // ��ȡֲ��ĵ�ǰѪ��
                int CurrentPlayerhealth = collision.GetComponent<Torchwoods>().CurrentHealth();
                if (CurrentPlayerhealth <= 0)
                {
                    // ��ʼ�ƶ�
                    isWalk = true;
                    animator.SetBool("Walk", true);
                }
            }
        }
        if (collision.tag == "Cattail")
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                // ��ֲ�� ʵ�����ٵ��ÿ�Ѫ
                collision.GetComponent<PlantCat>().DamegePlayer(damage);
                // ��ȡֲ��ĵ�ǰѪ��
                int CurrentPlayerhealth = collision.GetComponent<PlantCat>().CurrentHealth();
                if (CurrentPlayerhealth <= 0)
                {
                    // ��ʼ�ƶ�
                    isWalk = true;
                    animator.SetBool("Walk", true);
                }
            }
        }
        if (collision.tag == "GatlingPea")
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                // ��ֲ�� ʵ�����ٵ��ÿ�Ѫ
                collision.GetComponent<GatlingPea>().DamegePlayer(damage);
                // ��ȡֲ��ĵ�ǰѪ��
                int CurrentPlayerhealth = collision.GetComponent<GatlingPea>().CurrentHealth();
                if (CurrentPlayerhealth <= 0)
                {
                    // ��ʼ�ƶ�
                    isWalk = true;
                    animator.SetBool("Walk", true);
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sun" || collision.tag == "pea" || collision.tag == "WallNut" || collision.tag == "Torchwood"||
            collision.tag == "GatlingPea" || collision.tag == "Cattail")
        {
            // �뿪ֲ�����ֲ�ﱻ�����ˣ������ƶ�
            isWalk = true;
            animator.SetBool("Walk", true);
        }

    }
}