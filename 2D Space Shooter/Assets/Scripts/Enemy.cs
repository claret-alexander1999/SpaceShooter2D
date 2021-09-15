using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public bool canShoot;
    public bool canMove;

    public Transform attack_point;
    public GameObject bullet_prefab;

    public Animator anim;
    private AudioSource explosionSound;

    public float bound_X = -11f;



    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }
    void Update()
    {
        Move();

    }

    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.x < bound_X)
                gameObject.SetActive(false);

            
        }
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(bullet_prefab,attack_point.position,Quaternion.identity);
        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player" || target.tag == "PlayerBullet")
        {
            
            canMove = false;
            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }

            Invoke("TurnOffGameObject",0.25f);
            anim.Play("EnemyExplosion");
            explosionSound.Play();
        }
    }



}
