using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject PanelToolGameUI;
    public GameObject GameMenuTool;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //����Ϸ�޸Ĺ���
    public void SwitchRoot()
    {
        PanelToolGameUI.SetActive(true);
    }

    public void ExitSwitchRoot()
    {
        PanelToolGameUI.SetActive(false);
    }

    public void AnewGmae() // ���¼��س���
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGmae() //�˳���Ϸ
    {
        Application.Quit();
    }

    // ��ʼ��Ϸ��һ��
    public void LevelOneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitLevelOneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // ������ؿ�
    public void LevelMiniGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void ExitLevelMiniGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    // �޾�ģʽ
    public void ExitGameUIBullet()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void LevelGameUIBullet()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +3);
    }

    // ��Ϸ����
    public void OnToolGame()
    {
        if (GameMenuTool != null)
        {
            GameMenuTool.SetActive(true);
        }
    }
    public void ExitOnToolGame()
    {
        if (GameMenuTool != null)
        {
            GameMenuTool.SetActive(false);
        }
    }

    public void OnFPS120Tool()
    {
        Application.targetFrameRate = 120;
    }
    public void OnFPS90Tool()
    {
        Application.targetFrameRate = 90;
    }
    public void OnFPS60Tool()
    {
        Application.targetFrameRate = 60;
    }
    public void OnFPS30Tool()
    {
        Application.targetFrameRate = 30;
    }

}
