using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Body : MonoBehaviour
{
    public List<Transform> _attachmentPoints;
    public Transform _accPoint;
}
