using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;
    float timeStart = 25.45f;
    // Start is called before the first frame update
    void Start()
    {
        cameras[1].SetActive(true);
        cameras[0].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeStart)
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);


        }
    }
}
