using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingPea : Plants
{
    public float interval;
    public float timer;
    public GameObject bullet;
    public Transform bulletPos;
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        // 是否启用植物
       if (!start)
            return;
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            StartCoroutine(BulletPlants());
            timer = 0;
        }

    }
    IEnumerator BulletPlants()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
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
