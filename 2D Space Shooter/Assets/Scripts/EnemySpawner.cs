using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_Y= -4.33f, max_Y= 3.16f;
    public GameObject Enemy_prefab;
    public float timer = 2f;


    void Start()
    {
        Invoke("SpawnEnemies", timer);

    }

    void SpawnEnemies()
    {
        float pos_Y = Random.Range(min_Y,max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

        Instantiate(Enemy_prefab,temp,Quaternion.identity);
        Invoke("SpawnEnemies",timer);
    }
}
