using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Car : MonoBehaviour
{
    [SerializeField]
    private Body _body;
    [SerializeField]
    private Wheel _wheel;
    [SerializeField]
    private Resora _resora;
    [SerializeField]
    private Engine _engine;
    [SerializeField]
    private Accelerator _accel;

    [SerializeField]
    private int _unitDrive;//привод(1-передний 2-задний 3-полный)

    public Rigidbody _rb;
    public Body Body {
        get { return _body;}
        set { _body = value;
            _rb = Body.GetComponent<Rigidbody>();
        }
    }
    public Resora Resora {
        get { return _resora;}
        set { _resora = value; }
    }
    public Wheel Wheel { 
        get { return _wheel;} 
        set { _wheel = value; }
    }
    public Engine Engine {
        get { return _engine; }
        set { _engine = value; }
    }
    public int UnitDrive
    {
        get { return _unitDrive; }
        set
        {
            _unitDrive= value;
        }
    }
    public Accelerator Accelerator
    {
        get { return _accel; }  
        set { _accel = value; } 
    }

    public List<Resora> Resoras= new List<Resora>();
    public List<Wheel>  Wheels = new List<Wheel>();

    public int GetSpeed()
    {
        return Convert.ToInt32(_rb.velocity.magnitude * 3.6f);
    }
    
}
