using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    public int health = 100; // Ѫ��
    public int damage;  //��ʬ�˺�
    public GameObject ZombieHead;
    public float Speed;
    protected SpriteRenderer Zombierenderer;
    private ZombieNum zombieText;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Zombierenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void DamegeEnemy(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject,1.5f);
            zombieText =  GameObject.Find("ZombieNum").GetComponent<ZombieNum>();
            zombieText.TextZombieNum += 1;
        }

    }

    public virtual int ZombieCurrentHealth()
    {
        return health;
    }


    // �ı���ɫ
    public virtual IEnumerator ChangeColor()
    {
        Zombierenderer.color = new Color32(255, 114, 114, 255);
        yield return new WaitForSeconds(0.2f);
        Zombierenderer.color = new Color32(255, 255, 255, 255);
    }

}
