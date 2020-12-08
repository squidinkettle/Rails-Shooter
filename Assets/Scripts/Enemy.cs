using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] Transform parent;
    [SerializeField] int maxHealth;
    int health;

    [Header("Death control")]
    [SerializeField] GameObject deathFX;
    [SerializeField] float deathDelay = 0.5f;

    [Header("Score")]
    [SerializeField] int scorePerHit = 10;

    ScoreBoard scoreBoard;



    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        health = maxHealth;

    }

    void OnParticleCollision(GameObject other)
    {
        health--;
        scoreBoard.ScoreHit(scorePerHit);
        if (health <= 0)
        {
            KillEnemy();
        }


    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        Invoke("StartDeathProcess", deathDelay);
    }

    private void StartDeathProcess()
    {

        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void AddNonTriggerBoxCollider() {


        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
       

          }


}
