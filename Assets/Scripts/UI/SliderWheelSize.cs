using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderWheelSize : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private Car _car;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    public void OnMoved()
    {
        if (_car.Wheels.Count > 0)
        {
            foreach (var i in _car.Wheels)
            {
                i.transform.localScale = new Vector3(_slider.value, _slider.value, _slider.value);
            }
        }
    }
}
