using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Xbox360Controller : MonoBehaviour
{
    private GameObject xButton, yButton, aButton, bButton;
    private GameObject startButton, backButton, lbButton, ltButton, rbButton, rtButton, rbButtonLow, lbButtonLow, leftStick, rightStick, leftStickPress, rightStickPress;
    private GameObject dpadLeft, dpadRight, dpadUp, dpadDown, dpadNE, dpadNW, dpadSW, dpadSE;
    private Vector3 lStick, rStick;
    
    // Start is called before the first frame update
    void Start()
    {
        xButton = GameObject.Find("X Button");
        yButton = GameObject.Find("Y Button");
        bButton = GameObject.Find("B Button");
        aButton = GameObject.Find("A Button");
        startButton = GameObject.Find("Start Button");
        backButton = GameObject.Find("Back Button");

        lbButton = GameObject.Find("Left Bumper Button Top");
        lbButtonLow = GameObject.Find("Left Bumper Button Bottom");

        rbButton = GameObject.Find("Right Bumper Button Top");
        rbButtonLow = GameObject.Find("Right Bumper Button Bottom");

        ltButton = GameObject.Find("Left Trigger Button");
        rtButton = GameObject.Find("Right Trigger Button");

        leftStick = GameObject.Find("Left Stick");
        rightStick = GameObject.Find("Right Stick");

        leftStickPress = GameObject.Find("Left Stick Press");
        rightStickPress = GameObject.Find("Right Stick Press");

        dpadLeft = GameObject.Find("Dpad Left");
        dpadRight= GameObject.Find("Dpad Right");
        dpadUp = GameObject.Find("Dpad Up");
        dpadDown = GameObject.Find("Dpad Down");

        dpadNE = GameObject.Find("Dpad NE");
        dpadNW = GameObject.Find("Dpad NW");
        dpadSW = GameObject.Find("Dpad SW");
        dpadSE = GameObject.Find("Dpad SE");


       
    }

    // Update is called once per frame
    void Update()
    {
        var gp = Gamepad.current;

        Buttons(gp);
        MiddleButtons(gp);
        TriggersAndBumpers(gp);
        StickMovements(gp);
        StickPresses(gp);
        Dpad(gp);
    }

    void Buttons(Gamepad gp)
    {
        if (gp.buttonWest.wasPressedThisFrame)
        {
            xButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.buttonWest.wasReleasedThisFrame)
        {
            xButton.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (gp.buttonNorth.wasPressedThisFrame)
        {
            yButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.buttonNorth.wasReleasedThisFrame)
        {
            yButton.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (gp.buttonSouth.wasPressedThisFrame)
        {
            aButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.buttonSouth.wasReleasedThisFrame)
        {
            aButton.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (gp.buttonEast.wasPressedThisFrame)
        {
            bButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.buttonEast.wasReleasedThisFrame)
        {
            bButton.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void MiddleButtons(Gamepad gp)
    {
        if (gp.startButton.wasPressedThisFrame)
        {
            startButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.startButton.wasReleasedThisFrame)
        {
            startButton.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (gp.selectButton.wasPressedThisFrame)
        {
            backButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.selectButton.wasReleasedThisFrame)
        {
            backButton.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void TriggersAndBumpers(Gamepad gp)
    {
        if (gp.rightShoulder.wasPressedThisFrame)
        {
            rbButton.GetComponent<SpriteRenderer>().color = Color.green;
            rbButtonLow.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.rightShoulder.wasReleasedThisFrame)
        {
            rbButton.GetComponent<SpriteRenderer>().color = Color.white;
            rbButtonLow.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (gp.leftShoulder.wasPressedThisFrame)
        {
            lbButton.GetComponent<SpriteRenderer>().color = Color.green;
            lbButtonLow.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.leftShoulder.wasReleasedThisFrame)
        {
            lbButton.GetComponent<SpriteRenderer>().color = Color.white;
            lbButtonLow.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (gp.leftTrigger.wasPressedThisFrame)
        {
            ltButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.leftTrigger.wasReleasedThisFrame)
        {
            ltButton.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (gp.rightTrigger.wasPressedThisFrame)
        {
            rtButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.rightTrigger.wasReleasedThisFrame)
        {
            rtButton.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void StickMovements(Gamepad gp)
    {
        if (Mathf.Abs(gp.leftStick.ReadValue().y) > 0.05 || Mathf.Abs(gp.leftStick.ReadValue().x) > 0.05)
        {
            leftStick.GetComponent<SpriteRenderer>().color = Color.green;
            lStick = leftStick.transform.position; 

            lStick.x = Mathf.Clamp(gp.leftStick.ReadValue().x * 0.3f -2.225f, -2.525f , -1.928f);
            lStick.y = Mathf.Clamp(gp.leftStick.ReadValue().y * 0.3f -0.833f, -1.133f, -0.533f);

            leftStick.transform.position = new Vector3(lStick.x, lStick.y, 0.0f);
            
        }
        else
        {
            leftStick.GetComponent<SpriteRenderer>().color = Color.white;
            leftStick.transform.position = new Vector3(-2.225f, -0.833f, 0.0f);
        }

        if (Mathf.Abs(gp.rightStick.ReadValue().y) > 0.05 || Mathf.Abs(gp.rightStick.ReadValue().x) > 0.05)
        {
            rightStick.GetComponent<SpriteRenderer>().color = Color.green;
            rStick = rightStick.transform.position; 

            rStick.x = Mathf.Clamp(gp.rightStick.ReadValue().x * 0.3f + 0.859f, 0.559f , 1.159f);
            rStick.y = Mathf.Clamp(gp.rightStick.ReadValue().y * 0.3f -2.105f, -2.405f, -1.805f);

            rightStick.transform.position = new Vector3(rStick.x, rStick.y, 0.0f);
        }
        else
        {

            rightStick.GetComponent<SpriteRenderer>().color = Color.white;
            rightStick.transform.position = new Vector3(0.859f, -2.105f, 0.0f);
        }
    }

    void StickPresses(Gamepad gp)
    {
        if (gp.leftStickButton.wasPressedThisFrame)
        {
            leftStickPress.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.leftStickButton.wasReleasedThisFrame)
        {
            leftStickPress.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        if (gp.rightStickButton.wasPressedThisFrame)
        {
            rightStickPress.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (gp.rightStickButton.wasReleasedThisFrame)
        {
            rightStickPress.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void Dpad(Gamepad gp)
    {
        if (gp.dpad.ReadValue().x > 0.8f)
        {
            dpadRight.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (gp.dpad.ReadValue().x <  -0.8f)
        {
            dpadLeft.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (gp.dpad.ReadValue().y > 0.8)
        {
            dpadUp.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (gp.dpad.ReadValue().y < -0.8)
        {
            dpadDown.GetComponent<SpriteRenderer>().color = Color.green;
        }


        if(gp.dpad.ReadValue().x > 0.5f && gp.dpad.ReadValue().x <= 0.8f && gp.dpad.ReadValue().y > 0.5 && gp.dpad.ReadValue().y <= 0.8)
        {
            dpadNE.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if(gp.dpad.ReadValue().x < -0.5f && gp.dpad.ReadValue().x >= -0.8f && gp.dpad.ReadValue().y < -0.5 && gp.dpad.ReadValue().y >= -0.8)
        {
            dpadSW.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if(gp.dpad.ReadValue().x < -0.5f && gp.dpad.ReadValue().x >= -0.8f && gp.dpad.ReadValue().y > 0.5 && gp.dpad.ReadValue().y <= 0.8)
        {
            dpadNW.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if(gp.dpad.ReadValue().x > 0.5f && gp.dpad.ReadValue().x <= 0.8f && gp.dpad.ReadValue().y < -0.5 && gp.dpad.ReadValue().y >= -0.8)
        {
            dpadSE.GetComponent<SpriteRenderer>().color = Color.green;
        }


        if (Mathf.Abs(gp.dpad.ReadValue().x) < 0.5f)
        {
            dpadRight.GetComponent<SpriteRenderer>().color = Color.white;
            dpadLeft.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Mathf.Abs(gp.dpad.ReadValue().y) < 0.5f)
        {
            dpadUp.GetComponent<SpriteRenderer>().color = Color.white;
            dpadDown.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if(gp.dpad.ReadValue().x < 0.5f || gp.dpad.ReadValue().y < 0.5f)
        {
            dpadNE.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if(gp.dpad.ReadValue().x < 0.5f || gp.dpad.ReadValue().y > -0.5f)
        {
            dpadSE.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if(gp.dpad.ReadValue().x > -0.5f || gp.dpad.ReadValue().y > -0.5f)
        {
            dpadSW.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if(gp.dpad.ReadValue().x > -0.5f || gp.dpad.ReadValue().y < 0.5f)
        {
            dpadNW.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
