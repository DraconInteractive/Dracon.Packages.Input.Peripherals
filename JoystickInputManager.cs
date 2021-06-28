using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class JoystickInputManager : MonoBehaviour
{
    public Vector2 mainAxis;
    public float twistAxis;
    public Vector2 hatSwitch;
    public bool triggerDown;
    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Joystick joy = Joystick.current;
        mainAxis = joy.stick.ReadValue();
        triggerDown = joy.trigger.isPressed;
        twistAxis = joy.twist.ReadValue();
        hatSwitch = ((DpadControl)joy.GetChildControl("hat")).ReadValue();
        thrust = ((AxisControl)joy.GetChildControl("slider")).ReadValue();
    }


}
