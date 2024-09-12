using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float time;
    public float spawnTime;
    public GameObject[] enemies;
    public GameObject spawnPoint;

    public int timeBetweenWave = 20;
    public int waveCount = 2;

    private int currentNumber = 0;
    private float waveTime = 0;

    private int lastNumber = 0;

    private void Awake()
    {
        spawnTime = 0;
        waveTime = 0;
        currentNumber = 0;
    }
    void Update()
    {

        waveTime += Time.deltaTime;

        if (waveTime >= timeBetweenWave)
        {
            waveTime = 0;
            currentNumber += waveCount;
            if (waveCount <= 20)
                waveCount += 3;
        }

        if (currentNumber > 0)
        {
            spawnTime += Time.deltaTime;

            if (spawnTime >= 0.7)
                spawnEnemy();
        }
    }

    public void spawnEnemy()
    {
        int randomNumber = lastNumber;
        while (randomNumber == lastNumber)
        {
            randomNumber = UnityEngine.Random.Range(1, 6);
        }
        lastNumber = randomNumber;
        currentNumber--;
        Slime slime = Instantiate(enemies[0], spawnPoint.transform.position, Quaternion.identity).GetComponent<Slime>();
        slime.row = randomNumber;
        spawnTime = 0;
        
    }
}
