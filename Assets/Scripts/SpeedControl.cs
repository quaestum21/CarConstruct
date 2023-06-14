using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SpeedControl : MonoBehaviour
{
    [SerializeField]
    private Car _car;

    private float _speed;
    private Text _text;
    private void Start()
    {
        _text = gameObject.GetComponent<Text>();
    }
    void FixedUpdate()
    {
        _speed = _car.GetSpeed() *2F;
        _text.text =_speed.ToString() + " κμ/χ";
    }
}
