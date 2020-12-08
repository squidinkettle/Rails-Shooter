using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Header("General")]
    [SerializeField] int maxPlayerHealth = 100;
    [SerializeField]int playerHealth;

    [Header("Particle Control")]
    [Tooltip("Particle FX prefab on player")][SerializeField] GameObject deathFX;
    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxPlayerHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        playerHealth -= 20;
        if(playerHealth<=0)
            StartDeathSequence();
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void StartDeathSequence()
    {
        deathFX.SetActive(true);
        deathFX.GetComponent<ParticleSystem>().Play();
        gameObject.SendMessage("PlayerMovementHandler");
        Invoke("RestartLevel", levelLoadDelay);

    }

    void RestartLevel() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
      
       
         }


}
