using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool nextRound = false;
    public GameObject Enemy;
    public int killed;
    public int killedCount = 0;
    public int Wave = 1;
    public int noOfEnemys = 1;
    public int Enemys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextRound)
        {
            if(Wave % 2 == 0)
            {
                noOfEnemys++;
            }
            if(Wave % 2 != 0)
            {
                Enemy.GetComponent<Rigidbody2D>().mass = Wave;
            }
            for (int i = 0; i < noOfEnemys; i++)
            {
                Instantiate(Enemy, new Vector3(Random.Range(-8.5f, -3),Random.Range(-8.5f, 8.5f), 0), Quaternion.identity);
                Enemys++;
            }
            if(Enemys == noOfEnemys)
            {
                nextRound = false;
                Enemys = 0;
                killedCount += killed;
                killed = 0;
            }
            noOfEnemys = 1;
        }
    }
}
