using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndlessGameManger : MonoBehaviour
{   public GameObject bornParent;
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
    private float Timer;
    private DateSaveManager dateTool;
    private GameUI LeveluI; //卡关进度条
    public GameObject GameOverUI;
    private bool isGameOver;
    public int LevelNum;
    private float LevelUInum;
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
        LevelUInum = Random.Range(5,10) * 0.1f;
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
        LevelText.text = LevelNum.ToString();
        Timer += Time.deltaTime;
        LeveluI.SetPercent(Timer / LevelTime); // 更新游戏进度UI
        if (Timer / LevelTime >=0.99 && !isGameOver)
        {
            LeveluI.SetPercent(1); // 进度条结束
        }
        // 开始游戏时
        if (isGameGO)
        {
            CameraPosStart.transform.position += direction * Speed * Time.deltaTime;
            if (CameraPosStart.transform.position.x <= CameraPosExit.transform.position.x)
            {
                Speed = 0;
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
        while (true)
        {

            if (Timer > LevelTime)
            {
                if (LevelNum > 21)
                {
                    LevelNum = 22;
                }
                else
                {
                    LevelNum += 1;
                }
                Timer = 0;
                isZombieBoss = true;
                LeveluI.SetPercent(0);
                LevelUInum = Random.Range(5,10) * 0.1f;
                LeveluI.SetFlagPercent(LevelUInum);
            }
            else
            {
                yield return new WaitForSeconds(createZombieTime);
                // 僵尸生成位置优化
                if (Timer / LevelTime > LevelUInum)
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
                }
                else
                {
                    GameObject zombie = Instantiate(zombiePrefab[Random.Range(0, LevelNum)]); //获取僵尸对象并且重置属性 并且随机生成僵尸种类
                    int index = Random.Range(0, 5);
                    Transform zombieLine = bornParent.transform.Find("bom" + index.ToString());
                    zombie.transform.parent = zombieLine;
                    zombie.transform.localPosition = Vector3.zero;
                }

                // 0.6进度放旗帜生成旗帜僵尸
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);  // 返回开始界面
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Zombie" && collision.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            StartCoroutine(GameOver());
        }
    }
}
