using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunUI : MonoBehaviour
{
    private int StarSuning = 0;
    public Text SunNum;

    public static int CurrentSuning;
    private DateSaveManager plantsToos; // 内存数据
    // Start is called before the first frame update
    void Start()
    {
        plantsToos = GameObject.Find("Manger").GetComponent<DateSaveManager>();
        StarSuning = plantsToos.PeashooterToos.PlantSunNum;   //把阳光数据赋值给阳光
        CurrentSuning = StarSuning;
    }

    // Update is called once per frame
    void Update()
    {
        SunNum.text = CurrentSuning.ToString();
    }
}
