using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sun2 : MonoBehaviour, IPointerDownHandler
{
    private Rigidbody2D Sunrigidbody2D;
    public Transform[] StartSunPos;
    private Transform SunPos;
    private bool isSunMove;
    public float Speed;
    private float timer = 0;
    // Start is called before the first frame update
    void Awake()
    {
        StartSunPos = GameObject.Find("SunPosYX").GetComponentsInChildren<Transform>();
        SunPos = GameObject.FindGameObjectWithTag("SunPos").GetComponent<Transform>();
    }
    void Start()
    {
        Sunrigidbody2D = GetComponent<Rigidbody2D>();
        transform.position = StartSunPos[Random.Range(1,10)].position;
        Invoke("ExitTime", Random.Range(3,6));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
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
        if (timer >=15)
        {
            Destroy(gameObject);
        }

    }

    // µã»÷Ê±
    public void OnPointerDown(PointerEventData eventData)
    {
        isSunMove = true;
        timer = 0;
        ZombieSoundTool.instance.PlantSunClipBGM();
    }


    void ExitTime()
    {
        Sunrigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        
    }

}
