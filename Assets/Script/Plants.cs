using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public int health = 100;
    // �Ƿ�ʼ��ֲֲ��
    protected bool start;
    protected Animator animator;

    protected BoxCollider2D box2D;
    protected DateSaveManager dateTool;
    protected SpriteRenderer PlantsRenderer;
    protected virtual void Start()
    {
        start = false;
        dateTool = GameObject.Find("Manger").GetComponent<DateSaveManager>();
        health = health * dateTool.PeashooterToos.PlantHealth;
        animator = GetComponent<Animator>();
        box2D = GetComponent<BoxCollider2D>();
        PlantsRenderer = GetComponent<SpriteRenderer>();
        animator.speed = 0; // ��ͣ����
        box2D.enabled = false; //û����ֲ�����Box
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �Ƿ�����ֲ��
    public void SetPlantStart()
    {
        start = true;
        animator.speed = 1; // ���ö���
        box2D.enabled = true; // ����Box
    }

    // ��Ѫ
    public virtual void DamegePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    // ��ǰѪ��
    public virtual int CurrentHealth()
    {
        return health;
    }


    // �ı���ɫ
    public virtual IEnumerator PlantChangeColor()
    {
        PlantsRenderer.color = new Color32(255, 114, 114, 255);
        yield return new WaitForSeconds(0.2f);
        PlantsRenderer.color = new Color32(255, 255, 255, 255);
    }


}
