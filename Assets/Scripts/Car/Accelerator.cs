using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    [SerializeField]
    private float _valueBoost;
    [SerializeField]
    private GameObject _effect;

    public float ValueBoost
    {
        get { return _valueBoost; }
        set { _valueBoost = value; }
    }
    public void EnableEffect()
    {
        _effect.SetActive(true);  
    }
    public void DisableEffect()
    {
        _effect.SetActive(false);
    }

}
