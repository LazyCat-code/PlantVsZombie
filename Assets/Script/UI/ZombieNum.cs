using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZombieNum : MonoBehaviour
{
    public Text TextZombie;
    public int TextZombieNum;
    // Start is called before the first frame update
    void Start()
    {
        TextZombieNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextZombie.text = TextZombieNum.ToString();
    }
}
