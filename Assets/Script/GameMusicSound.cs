using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicSound : MonoBehaviour
{
    public static GameMusicSound instance;

    public AudioSource audioSource;
    [SerializeField]
    private AudioClip AttackClip, ZombieTMClip;

    private void Awake()
    {
        instance = this;
    }

    public void PlantsAttackBGM()
    {
        audioSource.clip = AttackClip;
        audioSource.Play();
    }

    public void PlantsZzBGM()
    {
        audioSource.clip = ZombieTMClip;
        audioSource.Play();
    }
}
