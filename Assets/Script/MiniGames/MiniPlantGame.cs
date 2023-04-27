using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlantGame : MonoBehaviour
{
    protected bool start;
    protected Animator animator;
    protected BoxCollider2D box2D;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        start = false;
        animator = GetComponent<Animator>();
        box2D = GetComponent<BoxCollider2D>();
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
}
