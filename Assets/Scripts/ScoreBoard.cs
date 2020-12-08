using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{


    int score;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

   

    // Update is called once per frame
    public void ScoreHit(int scorePerHit) {

        for(int x = 0; x < scorePerHit; x++)
        {
            Invoke("ScoreAnimation", 0.5f);

        }
      


    }


    void ScoreAnimation()
    {


        score += 1;
        scoreText.text = score.ToString();

    }
}
