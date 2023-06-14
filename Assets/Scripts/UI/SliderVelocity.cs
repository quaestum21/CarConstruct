using UnityEngine;
using UnityEngine.UI;

public class SliderVelocity : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private Car _car;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    public void OnMoved()
    {
        _car.Engine.Velocity = (int)_slider.value;
    }
}
