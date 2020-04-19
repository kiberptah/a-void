﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatesManager : MonoBehaviour
{
    public GameObject gameSystems;
    public GameObject startButton;
    public GameObject ScorePanel;

    public GameObject Player;

    public int gameScore;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginGame()
    {
        gameObject.GetComponent<SoundManager>().eventMusic_1.start();
        Player.transform.position = new Vector3(0,0,0);


        gameSystems.SetActive(true);
        startButton.SetActive(false);

        ScorePanel.SetActive(false);
        gameScore = 0;

        //Player.GetComponent<ShootLaser>().ammo = Player.GetComponent<ShootLaser>().defaultAmmo;
        Player.GetComponent<PlayerStats>().ResetPlayerState();
    }

    public void Lose()
    {
        gameObject.GetComponent<SoundManager>().eventPlayerDeath.start();
        gameObject.GetComponent<SoundManager>().eventMusic_1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        DestroyObjects();

        gameSystems.SetActive(false);
        startButton.SetActive(true);

        ScorePanel.SetActive(true);
        ScorePanel.GetComponent<Text>().text = "Last Score: " + gameScore;

        
    }

    void DestroyObjects()
    {
        List<GameObject> missileInstances = new List<GameObject>();
        missileInstances.AddRange(GameObject.FindGameObjectsWithTag("Missile"));
        foreach (GameObject missile in missileInstances)
        {
            Destroy(missile);
        }

        GameObject scanWave;
        scanWave = GameObject.FindGameObjectWithTag("Scanwave");
        Destroy(scanWave);

    }

    public void IncreaseScore(int points)
    {
        gameScore += points;
    }
}
