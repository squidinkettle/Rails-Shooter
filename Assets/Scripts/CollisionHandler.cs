using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    [Header("General")]
    [SerializeField] int maxPlayerHealth = 100;
    [SerializeField]int playerHealth;
    [SerializeField] Text playerHealthText;

    [Header("Particle Control")]
    [Tooltip("Particle FX prefab on player")][SerializeField] GameObject deathFX;
    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthText.text = "Health: " + maxPlayerHealth.ToString();
        playerHealth = maxPlayerHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        playerHealth -= 20;
        playerHealthText.text = "Health: " + playerHealth.ToString();
        if (playerHealth<=0)
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
