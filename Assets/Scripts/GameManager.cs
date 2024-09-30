
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] waypoints;
    public static GameManager Instance;
    public Transform[] enemyspawners;
    public Enemy enemies;
    public float enemyammount = 0;
    public float maxenemya;
    float timer;
    public float Maxtimer;
    void Start()
    {
        Instance = this;
        enemyammount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyammount <= maxenemya)
        {
            timer += Time.deltaTime;
            if(timer >= Maxtimer)
            {
                timer = 0;
                Instantiate(enemies, enemyspawners[Random.Range(0, enemyspawners.Length)].position, transform.rotation);
                enemyammount++;
            }
        }
        
    }
}
