using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundTool : MonoBehaviour
{
    public static ZombieSoundTool instance;

    public AudioSource audioSource;
    public AudioSource audioSourceGameOver;
    public AudioSource audioSourceZombieTm;
    public AudioSource audioSourceCC;
    public AudioSource audioSourcePlantSun;
    [SerializeField]
    private AudioClip AttackClip, ZombieClip,OverClip,ZombieTmClip,CCClip,SunClip;

    private void Awake()
    {
        instance = this;
    }

    public void PlantsAttackBGM()
    {
        audioSource.clip = AttackClip;
        audioSource.Play();
    }

    public void StartZombieBGM()
    {
        audioSource.clip = ZombieClip;
        audioSource.Play();
    }
    public void GameOverBGM()
    {
        audioSourceGameOver.clip = OverClip;
        audioSourceGameOver.Play();
    }

    public void ZombieTmBGM()
    {
        audioSourceZombieTm.clip = ZombieTmClip;
        audioSourceZombieTm.Play();
    }

    public void PlantCCBGM()
    {
        audioSourceCC.clip = CCClip;
        audioSourceCC.Play();
    }

    public void PlantSunClipBGM()
    {
        audioSourcePlantSun.clip = SunClip;
        audioSourcePlantSun.Play();
    }
}
