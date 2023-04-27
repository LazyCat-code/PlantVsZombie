using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCat : Plants
{
    public GameObject CatBulletObject;
    public Transform BulletPos;
    public float TimeBullet;
    // Start is called before the first frame update
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
    }

    public void CatBullet()
    {
        Instantiate(CatBulletObject, BulletPos.position, Quaternion.identity);
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
