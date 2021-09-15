using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float min_Y, max_Y, min_X, max_X;

    [SerializeField]
    private GameObject player_Bullet;

    [SerializeField]
    private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_attack_timer;
    private bool can_Attack;

    private AudioSource shootingSound;

    void Awake()
    {
        shootingSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        current_attack_timer = attack_Timer;
    }

    void Update()
    {
        MovePlayer();
        Attack();

    }

    void MovePlayer()
    {
        if (Input.GetAxisRaw("Vertical")>0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > max_Y)
                temp.y = max_Y;

            transform.position = temp;

        } 
        
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < min_Y)
                temp.y = min_Y;

            transform.position = temp;

        }

        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x < min_X)
                temp.x = min_X;

            transform.position = temp;

        }

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > max_X)
                temp.x = max_X;

            transform.position = temp;

        }


    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer>current_attack_timer)
        {
            can_Attack = true;

        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (can_Attack)
            {
                can_Attack = false;
                attack_Timer = 0f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
                shootingSound.Play();

            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy" || target.tag == "EnemyBullet")
        {
            GameControlScript.health -= 1;
            Vector2 temp = transform.position;
            temp.x = -7.98f;
            temp.y = 0f;
            transform.position = temp;
        }
    }

    void OnTriggerEnter(Collider target)
    {
        
    }



}
