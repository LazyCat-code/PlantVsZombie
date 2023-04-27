using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletS : MonoBehaviour
{
    public Vector3 direction;
    public float Speed;

    private float timer;  //计数器

    public int damage = 15;
    private DateSaveManager dateTool;
    private SpriteRenderer Firerenderer;
    void Start()
    {
        Firerenderer = GetComponent<SpriteRenderer>();
        dateTool = GameObject.Find("Manger").GetComponent<DateSaveManager>();
        damage += dateTool.PeashooterToos.PlantBulletDamage;
        Speed += dateTool.PeashooterToos.PlantBulletSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position += direction * Speed * Time.deltaTime;
        if (timer >= 4f)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie")
        {
            GameMusicSound.instance.PlantsAttackBGM();
            collision.GetComponent<ZombieEnemy>().DamegeEnemy(damage);
            Destroy(gameObject, 0.1f);
        }
        if (collision.tag == "Torchwood")
        {
            damage += 10; // 变红加强
            Firerenderer.color = new Color32(221, 101, 93, 255);
        }
    }
}
