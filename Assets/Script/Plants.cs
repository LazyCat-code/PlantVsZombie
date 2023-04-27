using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    public int health = 100;
    // 是否开始种植植物
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
        animator.speed = 0; // 暂停动画
        box2D.enabled = false; //没启用植物禁用Box
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 是否启用植物
    public void SetPlantStart()
    {
        start = true;
        animator.speed = 1; // 启用动画
        box2D.enabled = true; // 启用Box
    }

    // 扣血
    public virtual void DamegePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    // 当前血量
    public virtual int CurrentHealth()
    {
        return health;
    }


    // 改变颜色
    public virtual IEnumerator PlantChangeColor()
    {
        PlantsRenderer.color = new Color32(255, 114, 114, 255);
        yield return new WaitForSeconds(0.2f);
        PlantsRenderer.color = new Color32(255, 255, 255, 255);
    }


}
