using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloomerang : MonoBehaviour
{

    public float Speed;  // ÒÆ¶¯ËÙ¶È
    public Vector3 direction;
    public float SpeedMove;
    public int damage;
    public float DestroyTime;
    // Start is called before the first frame update

    void Start()
    {
        Destroy(gameObject, DestroyTime);

    }

    // Update is called once per frame
    void Update()
    {
        Sickleing();
    }

    void Sickleing()
    {
        transform.Rotate(new Vector3(0, 0, -Speed * Time.deltaTime));
        transform.position += direction * SpeedMove * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Sun")
        {
            collision.GetComponent<SunFlower>().DamegePlayer(damage);
        }

        if (collision.tag == "pea")
        {
            collision.GetComponent<Peashooter>().DamegePlayer(damage);
        }

        if (collision.tag == "WallNut")
        {
            collision.GetComponent<WallNut>().DamegePlayer(damage);
        }

        if (collision.tag == "Torchwood")
        {
            collision.GetComponent<Torchwoods>().DamegePlayer(damage);
        }

        if (collision.tag == "Cattail")
        {
            collision.GetComponent<PlantCat>().DamegePlayer(damage);
        }

        if (collision.tag == "GatlingPea")
        {
            collision.GetComponent<GatlingPea>().DamegePlayer(damage);
        }
    }

}
