using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    public Vector3 direction;
    public float Speed;

    private float timer;  //¼ÆÊýÆ÷

    private int damage = 0;
    public DateSaveManager dateTool;
    // Start is called before the first frame update
    void Start()
    {
        dateTool = GameObject.Find("Manger").GetComponent<DateSaveManager>();
        damage = dateTool.PeashooterToos.PlantBulletDamage;
        Speed += dateTool.PeashooterToos.PlantBulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += direction * Speed * Time.deltaTime;
        if (timer >=4.6f)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zombie" && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            collision.GetComponent<ZombieEnemy>().DamegeEnemy(damage);
            Destroy(gameObject, 0.1f);
            GameMusicSound.instance.PlantsAttackBGM();
        }
        if (collision.tag == "Torchwood")
        {
            Destroy(gameObject,0.1f);
        }
        // ÌúÃÅ½©Ê¬ 
        if (collision.tag == "IronGates" && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            ZombieSoundTool.instance.ZombieTmBGM();
            direction = new Vector3(-1, 0, 0);
            Destroy(gameObject,2.5f);
        }
    }
}
