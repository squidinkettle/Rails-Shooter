﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("nextLevel", 2f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void nextLevel() {
        SceneManager.LoadScene(1);
        
      
       
         }


}
