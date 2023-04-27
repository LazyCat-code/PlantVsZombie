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
    public int useSun;  // ��Ƭ̫������
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
        // ��Χ,min,max
        float per = Mathf.Clamp(timer / waitTime, 0, 1);
        // ����Image ����
        progressBar.GetComponent<Image>().fillAmount = 1 - per;
    }

    // �Ƿ�ѹ��
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
    // �����ʼ
    public void OnBeginDrag(BaseEventData data)
    {
        // �ж��Ƿ������ֲ, ѹ�ڴ������޷���ֲ
        if (darkBg.activeSelf)
        {
            return;
        }
        // ������ֲ
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject = Instantiate(objectPrefab);
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);
    }

    // ��ק����
    public void OnDrag(BaseEventData data)
    {
        if (curGameObject == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);

    }
    // ��ק����
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
            // ��ֲ���
            if (c.tag == "Land")
            {
                curGameObject.transform.position = c.transform.position;

                curGameObject.GetComponent<MiniPlantWallNut>().SetPlantStart(); // ����ֲ�︸�����÷���
                curGameObject = null;

                timer = 0; // ���ü�ʱ��

                break;
            }
        }
        if (curGameObject != null)
        {
            Destroy(curGameObject);
            curGameObject = null;
        }

    }

    // ��������ת��
    public static Vector3 TranlateScreenToWorld(Vector3 position)
    {
        Vector3 cameraTranslatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(cameraTranslatePos.x, cameraTranslatePos.y, 0);
    }
}
