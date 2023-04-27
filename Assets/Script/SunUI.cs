using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunUI : MonoBehaviour
{
    private int StarSuning = 0;
    public Text SunNum;

    public static int CurrentSuning;
    private DateSaveManager plantsToos; // �ڴ�����
    // Start is called before the first frame update
    void Start()
    {
        plantsToos = GameObject.Find("Manger").GetComponent<DateSaveManager>();
        StarSuning = plantsToos.PeashooterToos.PlantSunNum;   //���������ݸ�ֵ������
        CurrentSuning = StarSuning;
    }

    // Update is called once per frame
    void Update()
    {
        SunNum.text = CurrentSuning.ToString();
    }
}
