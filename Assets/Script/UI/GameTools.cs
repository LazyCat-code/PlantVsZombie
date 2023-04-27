using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTools : MonoBehaviour
{
    public Text[] ToolNum;
    private DateSaveManager saveManager;
    // ����
    public static int CurrentSuningTool;
    private bool isAddSun;
    private int PlanHealthNum;
    private int BulletDamage;
    private int BulletSpeed;
    private float ZombiesTime;
    private bool isCardTime;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("Root").GetComponent<DateSaveManager>();
        CurrentSuningTool = saveManager.PeashooterToos.PlantSunNum; // ������
        PlanHealthNum = saveManager.PeashooterToos.PlantHealth; // Ѫ������
        BulletDamage = saveManager.PeashooterToos.PlantBulletDamage; //�ӵ��˺�
        BulletSpeed = saveManager.PeashooterToos.PlantBulletSpeed; // �ӵ��ٶ�
        ZombiesTime = saveManager.PeashooterToos.ZombieTime;  // ��ʬʱ��
        isCardTime = saveManager.PeashooterToos.PlantCardTime;  //��Ƭ��CD
    }

    // Update is called once per frame
    void Update()
    {
        // ����
        ToolNum[0].text = CurrentSuningTool.ToString();
        ToolNum[1].text = PlanHealthNum.ToString();
        ToolNum[2].text = BulletDamage.ToString();
        ToolNum[3].text = BulletSpeed.ToString();
        ToolNum[4].text = ZombiesTime.ToString();
        ToolNum[5].text = isCardTime.ToString();
        AddSunRoot();
        MinusTool();
    }

    // ��ֹ����Ϊ����
    void MinusTool()
    {
        if (saveManager.PeashooterToos.PlantSunNum <=0)
        {
            saveManager.PeashooterToos.PlantSunNum = 1;
        }

        if (saveManager.PeashooterToos.PlantHealth <= 0)
        {
            saveManager.PeashooterToos.PlantHealth = 1;
        }

        if (saveManager.PeashooterToos.PlantBulletDamage <= 0)
        {
            saveManager.PeashooterToos.PlantBulletDamage = 1;
        }

        if (saveManager.PeashooterToos.PlantBulletSpeed <= 0)
        {
            saveManager.PeashooterToos.PlantBulletSpeed = 1;
        }

        if (saveManager.PeashooterToos.ZombieTime <= 0)
        {
            saveManager.PeashooterToos.ZombieTime = 1;
        }
    }

    void AddSunRoot()
    {
        if (isAddSun == true)
        {
            // ��������
            saveManager.PeashooterToos.PlantSunNum = CurrentSuningTool;
            saveManager.PeashooterToos.PlantHealth = PlanHealthNum;
            saveManager.PeashooterToos.PlantBulletDamage = BulletDamage;
            saveManager.PeashooterToos.PlantBulletSpeed = BulletSpeed;
            saveManager.PeashooterToos.ZombieTime = ZombiesTime;
            saveManager.PeashooterToos.PlantCardTime = isCardTime;
            isAddSun = false;

            saveManager.PeashooterToos.PlantisRoot = true;
        }
    }
    public void SunNumadd()
    {
        CurrentSuningTool += 25;
        isAddSun = true;
    }

    public void minusSunNumadd()
    {
        CurrentSuningTool -= 25;
        isAddSun = true;
    }

    public void PlantHealthToool()
    {
        PlanHealthNum += 1;
        isAddSun = true;
    }
    public void minusPlantHealthToool()
    {
        PlanHealthNum -= 1;
        isAddSun = true;
    }

    public void BulletDamageTool()
    {
        BulletDamage += 5;
        isAddSun = true;
    }

    public void minusBulletDamageTool()
    {
        BulletDamage -= 5;
        isAddSun = true;
    }

    public void BulletSpeedTool()
    {
        BulletSpeed += 50;
        isAddSun = true;
    }
    public void minusBulletSpeedTool()
    {
        BulletSpeed -= 50;
        isAddSun = true;
    }

    public void ZombieTimeTool()
    {
        ZombiesTime += 1;
        isAddSun = true;
    }
    public void minusZombieTimeTool()
    {
        ZombiesTime -= 1;
        isAddSun = true;
    }

    public void PlantCardCD()
    {
        isCardTime = true;
        isAddSun = true;
    }

    public void MinusPlantCardCD()
    {
        isCardTime = false;
        isAddSun = true;
    }

}
