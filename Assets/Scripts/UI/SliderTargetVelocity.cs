using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderTargetVelocity : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private Car _car;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    public void OnMoved()
    {
        _car.Engine.TargetVelocity = (int)_slider.value;
    }
}