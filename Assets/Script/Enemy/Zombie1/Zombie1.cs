using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : ZombieEnemy
{
    public Vector3 direction = new Vector3(-1, 0, 0);
    private bool isWalk;
    private Animator animator;
    public float damageInterval = 0.5f;
    public GameObject BloomerangObject;
    public Transform BloomerangPos;
    private float tiemr;
    public float TimeBloome;
    public GameObject Bloomerang;
    public GameObject CatObject;
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
        tiemr += Time.deltaTime;
        Move();
        DieAnimator();
        BulletObject();
    }

    private void Move()
    {
        if (isWalk)
        {
            transform.position += direction * Speed * Time.deltaTime;
        }
    }

    private void BulletObject()
    {
        if (tiemr >= TimeBloome)
        {

            Instantiate(BloomerangObject, BloomerangPos.position, Quaternion.identity);
            tiemr = 0;
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

        if (collision.tag == "Sun" || collision.tag == "pea" || collision.tag == "WallNut" || collision.tag == "Torchwood" ||
            collision.tag == "Cattail"|| collision.tag == "GatlingPea")
        {
            tiemr = 0;
            isWalk = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Sun" || collision.tag == "pea" || collision.tag == "WallNut" || collision.tag == "Torchwood" ||
            collision.tag == "Cattail"|| collision.tag == "GatlingPea")
        {
            ZombieSoundTool.instance.PlantsAttackBGM();
            isWalk = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Sun" || collision.tag == "pea" || collision.tag == "WallNut" || collision.tag == "Torchwood" ||
            collision.tag == "Cattail"|| collision.tag == "GatlingPea")
        {
            tiemr = 0;
            // �뿪ֲ�����ֲ�ﱻ�����ˣ������ƶ�
            isWalk = true;
        }

    }


    void DieAnimator()
    {
        if (health <= 0)
        {
            isWalk = false;
            animator.SetTrigger("Die");
            Bloomerang.SetActive(false);
            CatObject.SetActive(false);
        }
    }

    // ���ö�ͷ����
    public void DieHeadTime()
    {
        ZombieHead.SetActive(true);
    }

}
