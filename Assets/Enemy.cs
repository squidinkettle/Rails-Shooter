using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] float deathDelay = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    void OnParticleCollision(GameObject other) {
        Instantiate(deathFX, transform.position,Quaternion.identity);


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
