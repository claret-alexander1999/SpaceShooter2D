using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
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
        temp.x += speed * Time.deltaTime;
        transform.position = temp;

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy" || target.tag == "EnemyBullet")
        {
            gameObject.SetActive(false);
            if (target.tag == "Enemy")
            {
                ScoreScript.ScoreValue += 10;

            }

        }
    }

    



    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }


}
