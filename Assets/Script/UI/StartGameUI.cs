using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameUI : MonoBehaviour
{
    public GameObject rootUI;
    public GameObject TextUI;
    private DateSaveManager saveManager;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = GameObject.Find("Root").GetComponent<DateSaveManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (saveManager.PeashooterToos.PlantisRoot)
        {
            rootUI.SetActive(true);
            TextUI.SetActive(false);

        }
        if (!saveManager.PeashooterToos.PlantisRoot)
        {
            rootUI.SetActive(false);
            TextUI.SetActive(true);

        }
    }


}
