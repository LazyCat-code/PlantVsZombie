using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnCleaner : MonoBehaviour
{
    public float Speed;
    private int damage = 1000;
    private bool isZombie;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        isZombie = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isZombie)
        {
            transform.position += direction * Speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            ZombieSoundTool.instance.PlantCCBGM();
            collision.GetComponent<ZombieEnemy>().DamegeEnemy(damage);
            isZombie = true;
            Destroy(gameObject, 5);
        }
    }
}
