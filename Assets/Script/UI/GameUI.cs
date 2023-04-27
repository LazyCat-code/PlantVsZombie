using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private GameObject Progress;
    private GameObject ProgressHead;
    private GameObject Bg;
    public GameObject FlagPrefab;

    private GameObject Flag;
    // Start is called before the first frame update
    void Start()
    {
        // ��ȡ������
        Progress = GameObject.Find("ZombieProgress").gameObject;
        ProgressHead = GameObject.Find("ProgressHead").gameObject;
        Bg = GameObject.Find("Bg").gameObject;
        Flag = GameObject.Find("Flag").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPercent(float per)
    {
        // ͼƬ������
        Progress.GetComponent<Image>().fillAmount = per;
        // ���������ұߵ�λ�ã���ʼλ�ã�
        float originPosX = Bg.GetComponent<RectTransform>().position.x + Bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        // ���������
        float width = Bg.GetComponent<RectTransform>().sizeDelta.x;
        // ������Զ��������������ƫ�ƣ��������Լ���Ϊ���ʵ�λ��
        float offset = 0;
        // ����ͷ��x��λ�ã����ұߵ�λ�� - ��������ȵ�һ�� + �Զ����ƫ��
        ProgressHead.GetComponent<RectTransform>().position = new Vector2(originPosX - per * width + offset, ProgressHead.GetComponent<RectTransform>().position.y);
    }

    public void SetFlagPercent(float per)
    {
        Flag.SetActive(false);
        // ���������ұߵ�λ�ã���ʼλ�ã�
        float originPosX = Bg.GetComponent<RectTransform>().position.x + Bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        // ���������
        float width = Bg.GetComponent<RectTransform>().sizeDelta.x;
        // ������Զ��������������ƫ�ƣ��������Լ���Ϊ���ʵ�λ��
        float offset = 10;
        // �����µ�����
        GameObject newFlag = Instantiate(FlagPrefab);
        newFlag.transform.SetParent(gameObject.transform, false);
        newFlag.GetComponent<RectTransform>().position = Flag.GetComponent<RectTransform>().position;
        // ����λ��
        newFlag.GetComponent<RectTransform>().position = new Vector2(originPosX - per * width + offset, newFlag.GetComponent<RectTransform>().position.y);

        ProgressHead.transform.SetAsLastSibling();
    }

}
