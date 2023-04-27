using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

   // �޸Ĺ���
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

// �û�
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
    // ��ʼ������
    void GenerateData()
    {

        // ��ͨ
        PeashooterToos = new PlantsToos();
        PeashooterToos.PlantHealth = 1; // ֲ��Ѫ������
        PeashooterToos.PlantBulletDamage = 5; // �ӵ��˺�
        PeashooterToos.PlantSunNum = 150;  // ��������
        PeashooterToos.PlantBulletSpeed = 1; // �ӵ��ٶ�
        PeashooterToos.ZombieTime = 7; //���ɽ�ʬʱ��
        PeashooterToos.PlantCardTime = false; // ��Ƭ��CD
        PeashooterToos.PlantisRoot = false;

    }

    // �û��л�
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

    // ��������
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

    // ��������
    public void OnButton()
    {
        list.plantsToos.Add(PeashooterToos);
        SaveData();
    }

    // ���ݶ�ȡ
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
            // ��������

        }
        else
        {
            GenerateData();
        }
    }

}
