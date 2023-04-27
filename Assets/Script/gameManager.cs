using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject bornParent;
    public GameObject [] zombiePrefab;  //僵尸所有预制体
    public GameObject Sun2Prefan;
    public GameObject ZombieBoss;  // 旗帜僵尸
    public float createZombieTime; //生成僵尸时间
    public Transform CameraPosStart;   // 相机移动开始
    public Transform CameraPosExit;   // 相机移动结束
    private bool isGameGO;
    private bool isZombieBoss;
    public float Speed;
    public Vector3 direction;

    public float LevelTime;
    public float Timer;
    private DateSaveManager dateTool;
    private GameUI LeveluI; //卡关进度条
    public GameObject GameOverUI;
    private bool isGameOver;

    public int LevelNum;
    public float LevelUInum;  // 游戏进度
    public Text LevelText;
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        LevelNum = 1;
        isGameGO = false;
        isZombieBoss = true;
        isGameOver = false;
        LevelUInum = Random.Range(5, 10) * 0.1f; //随机进度
        dateTool = GameObject.Find("Manger").GetComponent<DateSaveManager>();
        createZombieTime = dateTool.PeashooterToos.ZombieTime;
        LeveluI = GameObject.Find("Level1").GetComponent<GameUI>();
        StartCoroutine(GameStart());
        CreateZombie();
        StartCoroutine(DalayCreateZombie());
        LeveluI.SetFlagPercent(LevelUInum);

    }

    // Update is called once per frame
    void Update()
    {
        GameOverOne();
        LevelText.text = LevelNum.ToString();
        Timer += Time.deltaTime;
        LeveluI.SetPercent(Timer / LevelTime); // 更新游戏进度UI
        if (Timer / LevelTime >=0.99)
        {
            LeveluI.SetPercent(1); // 进度条结束
        }
        // 开始游戏时
        if (isGameGO)
        {
            CameraPosStart.transform.position += direction * Speed * Time.deltaTime;
            if (CameraPosStart.transform.position.x <= CameraPosExit.transform.position.x)
            {
                ZombieSoundTool.instance.StartZombieBGM();
                Speed = 0;
            }
        }


    }


    private void GameOverOne()
    {
        if (Timer > LevelTime)
        {
            if (bornParent.transform.GetChild(0).childCount == 0 &&
                bornParent.transform.GetChild(1).childCount == 0 &&
                bornParent.transform.GetChild(2).childCount == 0 &&
                bornParent.transform.GetChild(3).childCount == 0 &&
                bornParent.transform.GetChild(4).childCount == 0)
            {
                isGameOver = true;
            }
        }
    }


    // 随机生成
    public void CreateZombie()
    {
        StartCoroutine(GenerateSun());
    }


    // 第一关
    IEnumerator DalayCreateZombie()
    {
        int Zombielevelnum = 0;
        // 僵尸生成位置优化
        while (true)
        {
            if (Zombielevelnum >= 4)
            {
                break;
            }
            if (Timer < LevelTime)
            {
                yield return new WaitForSeconds(createZombieTime);
                GameObject zombie = Instantiate(zombiePrefab[Random.Range(0, LevelNum)]); //获取僵尸对象并且重置属性 并且随机生成僵尸种类
                int index = Random.Range(0, 5);
                Transform zombieLine = bornParent.transform.Find("bom" + index.ToString());
                zombie.transform.parent = zombieLine;
                zombie.transform.localPosition = Vector3.zero;
            }
            // 进度放旗帜生成旗帜僵尸
            if (Timer / LevelTime > LevelUInum && isZombieBoss)
            {
                GameObject zombie = Instantiate(ZombieBoss);
                int index = Random.Range(0, 5);
                Transform zombieLine = bornParent.transform.Find("bom" + index.ToString());
                zombie.transform.parent = zombieLine;
                zombie.transform.localPosition = Vector3.zero;
                isZombieBoss = false;
                // 只生成一只
            }
            if (Timer / LevelTime > LevelUInum && Zombielevelnum <= 4)
            {
                if (bornParent.transform.GetChild(0).childCount <= 5) //第一排
                {
                    GameObject zombie = Instantiate(zombiePrefab[Random.Range(1, LevelNum)]); //获取僵尸对象并且重置属性 并且随机生成僵尸种类
                    Transform zombieLine = bornParent.transform.Find("bom0");
                    zombie.transform.parent = zombieLine;
                    zombie.transform.localPosition = Vector3.zero;
                }
                if (bornParent.transform.GetChild(1).childCount <= 5) //第二排
                {
                    GameObject zombie = Instantiate(zombiePrefab[Random.Range(1, LevelNum)]); //获取僵尸对象并且重置属性 并且随机生成僵尸种类
                    Transform zombieLine = bornParent.transform.Find("bom1");
                    zombie.transform.parent = zombieLine;
                    zombie.transform.localPosition = Vector3.zero;
                }
                if (bornParent.transform.GetChild(2).childCount <= 5) //第三排
                {
                    GameObject zombie = Instantiate(zombiePrefab[Random.Range(1, LevelNum)]); //获取僵尸对象并且重置属性 并且随机生成僵尸种类
                    Transform zombieLine = bornParent.transform.Find("bom2");
                    zombie.transform.parent = zombieLine;
                    zombie.transform.localPosition = Vector3.zero;
                }
                if (bornParent.transform.GetChild(3).childCount <= 5) //第四排
                {
                    GameObject zombie = Instantiate(zombiePrefab[Random.Range(1, LevelNum)]); //获取僵尸对象并且重置属性 并且随机生成僵尸种类
                    Transform zombieLine = bornParent.transform.Find("bom3");
                    zombie.transform.parent = zombieLine;
                    zombie.transform.localPosition = Vector3.zero;
                }
                if (bornParent.transform.GetChild(4).childCount <= 5) //第五排
                {
                    GameObject zombie = Instantiate(zombiePrefab[Random.Range(1, LevelNum)]); //获取僵尸对象并且重置属性 并且随机生成僵尸种类
                    Transform zombieLine = bornParent.transform.Find("bom4");
                    zombie.transform.parent = zombieLine;
                    zombie.transform.localPosition = Vector3.zero;
                }
                Zombielevelnum += 1;
                yield return new WaitForSeconds(2.5f);
            }
        }


    }

    // 生成太阳花
    IEnumerator GenerateSun()
    {
        yield return new WaitForSeconds(10);
        Instantiate(Sun2Prefan);


        if (!isGameOver)
        {
            StartCoroutine(GenerateSun());
        }
        
    }

    // 开始游戏
    IEnumerator GameStart()
    {

        yield return new WaitForSeconds(3);
        isGameGO = true;
    }

    // 游戏结束
    IEnumerator GameOver()
    {
        GameOverUI.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Image ExitGameOver = GameObject.Find("ExitGameOver").GetComponent<Image>();
        Image GameOverText = GameObject.Find("GameOverText").GetComponent<Image>();
        ZombieSoundTool.instance.GameOverBGM();
        if (ExitGameOver != null && GameOverText != null)
        {
            for (int i = 0;i <= 255; i++)
            {
                byte ColorNum = (byte)(0 + i);
                ExitGameOver.color = new Color32(0, 0, 0, ColorNum);
                GameOverText.color = new Color32(255, 255, 255, ColorNum);
                yield return new WaitForSeconds(0.02f);
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);  // 返回开始界面
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Zombie" && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            StartCoroutine(GameOver());
        }
    }

}
