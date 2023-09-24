using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public GameObject Player;
    public EnemySpawner Spawner;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Spawner = GameObject.Find("Main Camera").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 nextpos = Vector3.MoveTowards(transform.position, Player.transform.position, 0.009f);
        Vector2 direction = nextpos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion slerp = Quaternion.Slerp(transform.rotation, rotation, 1f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, slerp, 5);
        transform.position = nextpos;
    }
    void Update()
    {
        if (transform.position.y >= 5.5 || transform.position.y <= -5.5)
        {
            Spawner.killed++;
            if (Spawner.killed == Spawner.noOfEnemys)
            {
                Spawner.nextRound = true;
                Spawner.Wave++;
            }
            Destroy(gameObject);
        }
        else if (transform.position.x >= 9.5 || transform.position.x <= -9.5)
        {
            Spawner.Wave++;
            Spawner.nextRound = true;
            Destroy(gameObject);

        }
    }
}
