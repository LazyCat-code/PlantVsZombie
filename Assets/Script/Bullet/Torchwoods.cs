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
        BulletsPos = GetComponentsInChildren<Transform>(); // ��ȡ�Ӷ���
    }

    // Update is called once per frame
    void Update()
    {
        // �Ƿ�����ֲ��
        if (!start)
            return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Instantiate(FireBullet, BulletsPos[1].position, Quaternion.identity);
        }
        // �ܻ�����
        if (collision.tag == "Bloomerang")
        {
            StartCoroutine(PlantChangeColor());
        }
    }

}
