using UnityEngine;

public class CarControl : MonoBehaviour
{
    [SerializeField]
    private Car _car;
    private void Update()
    {
        if (GameProcess.IsCanStart)
        {
            Drive();
            BrakePressKey();
            SteeringWheel();
            ChangeTransmission();
            EnableAccelerator();
        }
    }

    private void EnableAccelerator()
    {
        if (_car.Accelerator != null)
        {
            if (Input.GetKey(KeyCode.Q))
            {

                _car._rb.AddForce(_car.Body.transform.forward * _car.Accelerator.ValueBoost, ForceMode.Impulse);
                _car.Accelerator.EnableEffect();

            }
            else
            {
                _car.Accelerator.DisableEffect();
            }
        }
    }

    private bool _isDrive = true;
    private float _angleWheel = 20f;
    private int _stateAngle = 0; //-1left 1right
    private void ControlEngine(Wheel wheel, float targetVelociy, float force)
    {
        JointMotor motor = wheel.GetComponent<HingeJoint>().motor;
        motor.targetVelocity = targetVelociy;
        motor.force = force;
        wheel.GetComponent<HingeJoint>().motor = motor;

    }
    private void Drive()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _isDrive = true;
            if (_stateAngle == 0)
            {
                if(_car.UnitDrive == 1)
                {
                    ControlEngine(_car.Wheels[0], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[1], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[2], 0, 0);
                    ControlEngine(_car.Wheels[3], 0, 0);
                }
                if(_car.UnitDrive == 2)
                {
                    ControlEngine(_car.Wheels[3], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[2], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[1], 0, 0);
                    ControlEngine(_car.Wheels[0], 0, 0);
                }
                if(_car.UnitDrive == 3)
                {
                    ControlEngine(_car.Wheels[3], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[2], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[1], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[0], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                }
            }

            else
            {
                if(_car.UnitDrive == 3 || _car.UnitDrive == 1)
                {
                    ControlEngine(_car.Wheels[0], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[1], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[2], 0, 0);
                    ControlEngine(_car.Wheels[3], 0, 0);
                }
                if(_car.UnitDrive == 2)
                {
                    ControlEngine(_car.Wheels[3], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[2], _car.Engine.TargetVelocity, _car.Engine.Velocity);
                    ControlEngine(_car.Wheels[1], 0, 0);
                    ControlEngine(_car.Wheels[0], 0, 0);
                }
            }
        }
        else
        {
            _isDrive = false;
            foreach (var i in _car.Wheels)
            {
                ControlEngine(i, 0, 0);
            }
        }
    }
    private void BrakePressed(Wheel wheel)
    {
        wheel.GetComponent<HingeJoint>().useMotor = false;
        wheel.GetComponent<HingeJoint>().useSpring = true;
        JointSpring wheelSpring = wheel.GetComponent<HingeJoint>().spring;
        wheelSpring.spring = 6000f;
        wheel.GetComponent<HingeJoint>().spring = wheelSpring;
    }
    private void BrakeUnPressed(Wheel wheel)
    {
        wheel.GetComponent<HingeJoint>().useSpring = false;
        wheel.GetComponent<HingeJoint>().useMotor = true;
        ControlEngine(wheel, 0, 0);
    }
    private void BrakePressKey()
    {
        if (_isDrive) return;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            foreach (var i in _car.Wheels)
            {
                BrakePressed(i);
            }
        }
        else
        {
            foreach (var i in _car.Wheels)
            {
                BrakeUnPressed(i);
            }
        }
    }

    private void SteeringWheel()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (_stateAngle == 0)
            {
                _car.Resoras[0].GetComponent<ConfigurableJoint>().targetRotation *= Quaternion.Euler(0f, _angleWheel, 0f);
                _car.Resoras[1].GetComponent<ConfigurableJoint>().targetRotation *= Quaternion.Euler(0f, _angleWheel, 0f);
                _stateAngle = -1;
            }
        }
        if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            if (_stateAngle == 0)
            {
                _car.Resoras[0].GetComponent<ConfigurableJoint>().targetRotation *= Quaternion.Euler(0f, -_angleWheel, 0f);
                _car.Resoras[1].GetComponent<ConfigurableJoint>().targetRotation *= Quaternion.Euler(0f, -_angleWheel, 0f);
                _stateAngle = 1;
            }
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (_stateAngle  == 1)
            {
                _car.Resoras[0].GetComponent<ConfigurableJoint>().targetRotation *= Quaternion.Euler(0f, _angleWheel, 0f);
                _car.Resoras[1].GetComponent<ConfigurableJoint>().targetRotation *= Quaternion.Euler(0f, _angleWheel, 0f);
                _stateAngle = 0;
            }
            if (_stateAngle == -1)
            {
                _car.Resoras[0].GetComponent<ConfigurableJoint>().targetRotation *= Quaternion.Euler(0f, -_angleWheel, 0f);
                _car.Resoras[1].GetComponent<ConfigurableJoint>().targetRotation *= Quaternion.Euler(0f, -_angleWheel, 0f);
                _stateAngle = 0;
            }
        }
    }
    public void ChangeTransmission()
    {
        if (!_isDrive && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            HingeJoint xyz = _car.Wheels[0].GetComponent<HingeJoint>();
            float x_1 = xyz.axis.x;
            x_1 *= -1;
            xyz.axis = new Vector3(x_1, 0, 0);
            for (int i = 0; i < 4; i++)
            {
                _car.Wheels[i].GetComponent<HingeJoint>().axis = xyz.axis;
            }
        }
    }
}
