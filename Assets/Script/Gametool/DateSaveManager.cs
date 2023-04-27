using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

   // 修改工具
[System.Serializable]
public class PlantsToos
{
    public bool PlantisRoot;
    public int PlantHealth;
    public int PlantBulletDamage;
    public int PlantSunNum;
    public int PlantBulletSpeed;
    public float ZombieTime;
    public bool PlantCardTime;
}

// 用户
public class PlantsToosList
{
    public List<PlantsToos> plantsToos = new List<PlantsToos>();
}
public class DateSaveManager : MonoBehaviour
{
    public PlantsToosList list = new PlantsToosList();
    public PlantsToos PeashooterToos;
    public bool isRootGame;
    // Start is called before the first frame update
    void Awake()
    {
        LoadData();
    }
    void Start()
    {
        isRootGame = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // 初始化数据
    void GenerateData()
    {

        // 普通
        PeashooterToos = new PlantsToos();
        PeashooterToos.PlantHealth = 1; // 植物血量倍数
        PeashooterToos.PlantBulletDamage = 5; // 子弹伤害
        PeashooterToos.PlantSunNum = 150;  // 阳光数量
        PeashooterToos.PlantBulletSpeed = 1; // 子弹速度
        PeashooterToos.ZombieTime = 7; //生成僵尸时间
        PeashooterToos.PlantCardTime = false; // 卡片无CD
        PeashooterToos.PlantisRoot = false;

    }

    // 用户切换
    public void UserSwitching()
    {
        if (!isRootGame)
        {
            isRootGame = true;
        }
        else
        {
            isRootGame = false;
        }

    }

    // 保存数据
    void SaveData()
    {
        string json = JsonUtility.ToJson(list,true);
       // string filepath = Application.streamingAssetsPath + "/PlantsToosListjson";
        string filepath = Application.persistentDataPath + "/PlantsToosListjson";

        using (StreamWriter sw = new StreamWriter(filepath))
        {
            sw.WriteLine(json);
            sw.Close();
            sw.Dispose();
        }
    }

    // 保存数据
    public void OnButton()
    {
        list.plantsToos.Add(PeashooterToos);
        SaveData();
    }

    // 数据读取
    public void LoadData()
    {
        string json;
       // string filepath = Application.streamingAssetsPath + "/PlantsToosListjson";
        string filepath = Application.persistentDataPath + "/PlantsToosListjson";
        if (File.Exists(filepath))
        {
            using (StreamReader sr = new StreamReader(filepath))
            {
                json = sr.ReadToEnd();
                sr.Close();
                
            }


            list = JsonUtility.FromJson<PlantsToosList>(json);
            PeashooterToos = list.plantsToos[list.plantsToos.Count-1];
            // 更新数据

        }
        else
        {
            GenerateData();
        }
    }

}
