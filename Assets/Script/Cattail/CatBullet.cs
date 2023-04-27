using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBullet : MonoBehaviour
{
    public float Speed;
    public Vector3 Vector;
    private int damage = 10;
    private float timer;
    private DateSaveManager dateTool;
    // Start is called before the first frame update
    void Start()
    {

        dateTool = GameObject.Find("Manger").GetComponent<DateSaveManager>();
        damage += dateTool.PeashooterToos.PlantBulletDamage;
        Speed += dateTool.PeashooterToos.PlantBulletSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += Vector * Speed * Time.deltaTime;
        if (timer >=6)
        {
            Destroy(gameObject);
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

    }

}
