using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 6f;
    public float deactivate_timer = 4f;



    void Update()
    {

        Move();
        Invoke("DeactivateGameObject", deactivate_timer);

    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag=="Player"||target.tag=="PlayerBullet")
        {
            gameObject.SetActive(false);

        }
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

}
