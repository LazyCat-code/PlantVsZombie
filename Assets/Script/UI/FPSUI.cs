using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSUI : MonoBehaviour
{
    private float m_lastUpdateShowTime = 0f;
    private readonly float m_updateTime = 0.5f;
    private int m_frames = 0;
    private float m_FPS = 0;
    public Text FPSNum;
    public GameObject[] FPSObjects;

    void Start()
    {
        m_lastUpdateShowTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        m_frames++;
        if (Time.realtimeSinceStartup - m_lastUpdateShowTime >= m_updateTime)
        {
            m_FPS = (int)(m_frames / (Time.realtimeSinceStartup - m_lastUpdateShowTime));
            m_frames = 0;
            m_lastUpdateShowTime = Time.realtimeSinceStartup;
            FPSNum.text = m_FPS.ToString();
        }
    }


    public void Button120()
    {
        FPSObjects[0].SetActive(true);
        FPSObjects[1].SetActive(false);
        FPSObjects[2].SetActive(false);
        FPSObjects[3].SetActive(false);
    }
    public void Button90()
    {
        FPSObjects[0].SetActive(false);
        FPSObjects[1].SetActive(true);
        FPSObjects[2].SetActive(false);
        FPSObjects[3].SetActive(false);
    }
    public void Button60()
    {
        FPSObjects[0].SetActive(false);
        FPSObjects[1].SetActive(false);
        FPSObjects[2].SetActive(true);
        FPSObjects[3].SetActive(false);
    }
    public void Button30()
    {
        FPSObjects[0].SetActive(false);
        FPSObjects[1].SetActive(false);
        FPSObjects[2].SetActive(false);
        FPSObjects[3].SetActive(true);
    }

}
