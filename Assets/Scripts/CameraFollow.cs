using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public GameObject _object; //An object camera will follow
    
    [SerializeField] private Vector3 _distanceFromObject; // Camera's distance from the object
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private float smoothTime = 2f; 
    private void LateUpdate() //Works after all update functions called
    {
        Vector3 positionToGo = _object.transform.position + _distanceFromObject; //Target position of the camera
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, positionToGo, ref velocity, smoothTime);
        transform.position = smoothPosition;
        transform.LookAt(_object.transform.position); //Camera will look(returns) to the object
    }
}
