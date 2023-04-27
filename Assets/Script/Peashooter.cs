using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : Plants
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
        // �Ƿ�����ֲ��
        if (!start)
            return;
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0;
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �ܻ�����
        if (collision.tag == "Bloomerang")
        {
            StartCoroutine(PlantChangeColor());
        }
    }

}
