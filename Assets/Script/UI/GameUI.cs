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
        // 获取子物体
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
        // 图片进度条
        Progress.GetComponent<Image>().fillAmount = per;
        // 进度条最右边的位置（初始位置）
        float originPosX = Bg.GetComponent<RectTransform>().position.x + Bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        // 进度条宽度
        float width = Bg.GetComponent<RectTransform>().sizeDelta.x;
        // 这个是自定义参数，用来做偏移，调整到自己认为合适的位置
        float offset = 0;
        // 设置头的x轴位置：最右边的位置 - 进度条宽度的一半 + 自定义的偏移
        ProgressHead.GetComponent<RectTransform>().position = new Vector2(originPosX - per * width + offset, ProgressHead.GetComponent<RectTransform>().position.y);
    }

    public void SetFlagPercent(float per)
    {
        Flag.SetActive(false);
        // 进度条最右边的位置（初始位置）
        float originPosX = Bg.GetComponent<RectTransform>().position.x + Bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        // 进度条宽度
        float width = Bg.GetComponent<RectTransform>().sizeDelta.x;
        // 这个是自定义参数，用来做偏移，调整到自己认为合适的位置
        float offset = 10;
        // 创建新的旗子
        GameObject newFlag = Instantiate(FlagPrefab);
        newFlag.transform.SetParent(gameObject.transform, false);
        newFlag.GetComponent<RectTransform>().position = Flag.GetComponent<RectTransform>().position;
        // 设置位置
        newFlag.GetComponent<RectTransform>().position = new Vector2(originPosX - per * width + offset, newFlag.GetComponent<RectTransform>().position.y);

        ProgressHead.transform.SetAsLastSibling();
    }

}
