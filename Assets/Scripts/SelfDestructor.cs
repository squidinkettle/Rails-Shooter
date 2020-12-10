using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField]float destroyTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SelfDestruct() {


        Destroy(gameObject);
       
         }
}
