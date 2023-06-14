using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField]
    private int _targetVelocity;
    [SerializeField]
    private int _velocity;

    public int TargetVelocity
    {
        get { return _targetVelocity; }
        set { _targetVelocity = value; }
    }
    public int Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }
}
