using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    [Header("General")]
    [Tooltip("In ms per second")] [SerializeField] float speed = 20f;
    [Tooltip("In m")][Range(1,40)] [SerializeField] float xClamp;
    [Tooltip("In m")] [Range(1, 40)] [SerializeField] float yClamp;


    [Header("ScreenPosition Based")]
    [SerializeField] float pitchFactor= -5f;
    [SerializeField] float yawFactor = 5f;


    [Header("Control-Based")]
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float controlRollFactor = -20f;

    [Header("Flags")]
    bool restrictMovement = false;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

 

    // Update is called once per frame
    void Update()
    {
        PlayerMovementHandler(restrictMovement);



    }

    void PlayerMovementHandler(bool restricted)
    {
        restrictMovement = restricted;
        if (!restricted) {

            PlayerMovemment();
            PlayerRotation();

        }

    }

    private void PlayerRotation()
    {
        float pitch=transform.localPosition.y* pitchFactor+yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x* yawFactor;
        float roll=xThrow*controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    private void PlayerMovemment()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float posX = Mathf.Clamp(rawXPos, -xClamp, xClamp);


        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float posY = Mathf.Clamp(rawYPos, -yClamp, yClamp);

        transform.localPosition = new Vector3(posX, posY, transform.localPosition.z);
    }

   
}
