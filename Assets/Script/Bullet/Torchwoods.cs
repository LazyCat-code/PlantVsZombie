using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchwoods : Plants
{
    public Transform[] BulletsPos;
    public GameObject FireBullet;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BulletsPos = GetComponentsInChildren<Transform>(); // 获取子对象
    }

    // Update is called once per frame
    void Update()
    {
        // 是否启用植物
        if (!start)
            return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Instantiate(FireBullet, BulletsPos[1].position, Quaternion.identity);
        }
        // 受击反馈
        if (collision.tag == "Bloomerang")
        {
            StartCoroutine(PlantChangeColor());
        }
    }

}
