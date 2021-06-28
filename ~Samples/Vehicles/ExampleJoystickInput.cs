using e23.VehicleController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleJoystickInput : MonoBehaviour
{
	[SerializeField] private VehicleBehaviour vehicleBehaviour;

	public JoystickInputManager inputManager;

	bool lastTriggerValue;

	public VehicleBehaviour VehicleBehaviour
	{
		get { return vehicleBehaviour; }
		set { vehicleBehaviour = value; }
	}

    private void Update()
    {
        if (inputManager.mainAxis.y > 0)
        {
			vehicleBehaviour.ControlAcceleration();
        } else if (inputManager.mainAxis.y < 0)
        {
			vehicleBehaviour.ControlBrake();
        }

		vehicleBehaviour.ControlTurning(inputManager.twistAxis);
		vehicleBehaviour.ControlStrafing(inputManager.mainAxis.x);

		if (inputManager.triggerDown != lastTriggerValue)
        {
			if (inputManager.triggerDown)
            {
                vehicleBehaviour.Boost();
            } else
            {
                vehicleBehaviour.StopBoost();
            }
        }
    }
}
