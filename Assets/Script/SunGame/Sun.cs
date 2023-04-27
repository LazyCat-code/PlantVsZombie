using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sun : MonoBehaviour, IPointerDownHandler
{
    public float duration;
    private float timer;
    public float Speed;

    private bool isSunMove;

    private Transform SunPos;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        SunPos = GameObject.FindGameObjectWithTag("SunPos").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isSunMove)
        {

            transform.position = Vector3.MoveTowards(transform.position, SunPos.position, Speed * Time.deltaTime);
            if (transform.position.x == SunPos.position.x)
            {
                isSunMove = false;
                SunUI.CurrentSuning += 25;
                Destroy(gameObject);
            }
        }
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            Destroy(gameObject);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isSunMove = true;
        timer = 0;
        ZombieSoundTool.instance.PlantSunClipBGM();
    }

}
