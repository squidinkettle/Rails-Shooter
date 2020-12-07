using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayer > 1) {

            Destroy(gameObject);
        }
        else {

            DontDestroyOnLoad(this.gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextLevel", 2f);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void NextLevel() {
        SceneManager.LoadScene(1);
        
      
       
         }


}
