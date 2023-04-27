using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNut : Plants
{
    private float HealthWallNut;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        HealthWallNut = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 重写父类方法
    public override void DamegePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        // 动画切换
        animator.SetFloat("WallHead", health / HealthWallNut);

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
