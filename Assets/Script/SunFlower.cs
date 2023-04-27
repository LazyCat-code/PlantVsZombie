using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : Plants
{
    public GameObject SunPrefab;
    public float readyTime;
    private float timer;
    private int sunNum;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 是否启用植物
        if (!start)
            return;

        timer += Time.deltaTime;
        if (timer >= readyTime)
        {
            animator.SetBool("Ready", true);
        }
    }

    public void BornSunOver()
    {
        BornSun();
        animator.SetBool("Ready", false);
        timer = 0;
    }

    private void BornSun()
    {
        GameObject sunNew = Instantiate(SunPrefab);
        sunNum += 1;
        float randomX;
        if(sunNum %2 == 1)
        {
            randomX = Random.Range(transform.position.x - 30, transform.position.x - 20);
        }
        else
        {
            randomX = Random.Range(transform.position.x + 20, transform.position.x + 30);
        }
        float randomY = Random.Range(transform.position.y - 20, transform.position.y + 20);
        sunNew.transform.position = new Vector2(randomX, randomY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 受击反馈
        if (collision.tag == "Bloomerang")
        {
            StartCoroutine(PlantChangeColor());
        }
    }

}
