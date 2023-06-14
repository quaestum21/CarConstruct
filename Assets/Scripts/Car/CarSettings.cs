using System;
using UnityEngine;

public class CarSettings : MonoBehaviour
{
    [SerializeField]
    Car _car;
    [HideInInspector]
    public bool _isBodyCreated, _isResoraCreated, _isWheelsCreated, _isBoostCreated;

    private void Start()
    {
        _isBodyCreated = _isResoraCreated = _isWheelsCreated = _isBoostCreated = false;
        ChangeBody(_car.Body);
    }
    public void ChangeBody(Body body)
    {
        if (_isBodyCreated)
            Destroy(_car.Body.gameObject);
        
        _car.Body= Instantiate(body, gameObject.transform.position, Quaternion.identity);
        _car.Body.GetComponent<Rigidbody>().isKinematic = true;
        _car._rb = _car.Body.GetComponent<Rigidbody>();
        ChangeResoras(_car.Resora);
        ChangeWheels(_car.Wheel);
        if(_car.Accelerator !=null)
             ChangeAccelerator(_car.Accelerator);

        _isBodyCreated = true;
    }
    public void ChangeAccelerator(Accelerator accelerator)
    {
        if (_isBoostCreated)
        {
            Destroy(_car.Accelerator.gameObject);
        }
        _car.Accelerator = accelerator;
        _car.Accelerator = Instantiate(_car.Accelerator, _car.Body._accPoint.position,Quaternion.identity);
        _car.Accelerator.transform.parent = _car.Body.transform;
        _isBoostCreated = true;
    }

    public void ChangeResoras(Resora resora)
    {
        _car.Resora = resora;
        if (_isResoraCreated)
            DestroyResoras();
        for (int i = 0; i < 4; i++)
        {
            _car.Resoras.Add(Instantiate(_car.Resora, _car.Body._attachmentPoints[i].position, Quaternion.identity));
            if (i == 0 || i == 2)
            {
                _car.Resoras[i].transform.Rotate(0, 180, 0);
            }
            _car.Resoras[i].GetComponent<ConfigurableJoint>().connectedBody = _car.Body.GetComponent<Rigidbody>();
        }
        _isResoraCreated = true;
        ChangeWheels(_car.Wheel);
    }
    public void ChangeWheels(Wheel wheel)
    {
        if (_isWheelsCreated)
            DestroyWheels();
        _car.Wheel = wheel;
        for (int i = 0; i < 4; i++)
        {
            _car.Wheels.Add(Instantiate(wheel, _car.Resoras[i].attachmentPoint.transform.position, Quaternion.identity));
            _car.Wheels[i].GetComponent<HingeJoint>().connectedBody = _car.Resoras[i].GetComponent<Rigidbody>();
        }
        _isWheelsCreated = true;
    }
    public void DestroyWheels()
    {
        for (int i = 0; i < _car.Wheels.Count; i++)
        {
            Destroy(_car.Wheels[i].gameObject);
        }
        _car.Wheels.Clear();

    }
    public void DestroyResoras()
    {
        for (int i = 0; i < _car.Resoras.Count; i++)
        {
            Destroy(_car.Resoras[i].gameObject);
        }
        _car.Resoras.Clear();
    }
    public void DestroyAcceleration()
    {
        if(_isBoostCreated)
              Destroy(_car.Accelerator.gameObject);
        _isBoostCreated = false;
    }
}
