using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MiniCards : MonoBehaviour
{
    public GameObject objectPrefab;
    private GameObject curGameObject;

    private GameObject darkBg;
    private GameObject progressBar;
    public float waitTime;
    public int useSun;  // 卡片太阳数量
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        darkBg = transform.Find("dark").gameObject;
        progressBar = transform.Find("Progress").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateProgress();
        UpdateDarkBg();
    }

    void UpdateProgress()
    {
        // 范围,min,max
        float per = Mathf.Clamp(timer / waitTime, 0, 1);
        // 更新Image 进度
        progressBar.GetComponent<Image>().fillAmount = 1 - per;
    }

    // 是否压黑
    void UpdateDarkBg()
    {
        if (progressBar.GetComponent<Image>().fillAmount == 0 && SunUI.CurrentSuning >= useSun)
        {
            darkBg.SetActive(false);
        }
        else
        {
            darkBg.SetActive(true);
        }
    }
    // 点击开始
    public void OnBeginDrag(BaseEventData data)
    {
        // 判断是否可以种植, 压黑存在则无法种植
        if (darkBg.activeSelf)
        {
            return;
        }
        // 可以种植
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject = Instantiate(objectPrefab);
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);
    }

    // 拖拽过程
    public void OnDrag(BaseEventData data)
    {
        if (curGameObject == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);

    }
    // 拖拽结束
    public void OnEndDrag(BaseEventData data)
    {
        if (curGameObject == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        Collider2D[] col = Physics2D.OverlapPointAll(TranlateScreenToWorld(pointerEventData.position));

        foreach (Collider2D c in col)
        {
            // 种植完成
            if (c.tag == "Land")
            {
                curGameObject.transform.position = c.transform.position;

                curGameObject.GetComponent<MiniPlantWallNut>().SetPlantStart(); // 调用植物父类启用方法
                curGameObject = null;

                timer = 0; // 重置计时器

                break;
            }
        }
        if (curGameObject != null)
        {
            Destroy(curGameObject);
            curGameObject = null;
        }

    }

    // 世界坐标转化
    public static Vector3 TranlateScreenToWorld(Vector3 position)
    {
        Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(cameraTranslatePos.x, cameraTranslatePos.y, 0);
    }
}
