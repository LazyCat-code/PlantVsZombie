using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlantWallNut : MiniPlantGame
{
    public float Speed;
    public float SpeedMove;
    public Vector3 direction;
    public int Minidamage;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
            return;
        Move();
        Destroy(gameObject, 3.5f);
    }

    void Move()
    {
        transform.Rotate(new Vector3(0, 0, -Speed *Time.deltaTime));
        transform.position += direction * SpeedMove * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            collision.GetComponent<ZombieEnemy>().DamegeEnemy(Minidamage);
        }
    }

}
