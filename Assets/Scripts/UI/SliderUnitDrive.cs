using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderUnitDrive : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private Car _car;
    private void Awake()
    {
        _slider= GetComponent<Slider>();
    }
    public void OnMoved()
    {
        if(_slider.value == 1)
        {
            _car.UnitDrive = 1;
        }
        else if(_slider.value == 2) 
        {
            _car.UnitDrive = 2;
        }
        else
        {
            _car.UnitDrive = 3;
        }
    }
}
