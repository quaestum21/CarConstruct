using UnityEngine;

public class GameProcess : MonoBehaviour
{
    [SerializeField]
    Car _car;
    [SerializeField]
    CarSettings _carSettings;
    public static bool IsCanStart = false;
    public void StartGameProcess()
    {
        
        Camera cam = Camera.main;
        cam.GetComponent<CameraFollow>().enabled = true;
        cam.GetComponent<CameraFollow>()._object = _car.Body.gameObject;
        _car.Body.GetComponent<Rigidbody>().isKinematic = false;
        IsCanStart = true;
    }
    public void EndGameProcess()
    {
        _car.Body.transform.position = _car.gameObject.transform.position;
        _car.Body.GetComponent<Rigidbody>().isKinematic = true;
        _car.Body.transform.rotation = Quaternion.identity;
        IsCanStart = false;
        Camera cam = Camera.main;
        cam.GetComponent<CameraFollow>().enabled = false;
        cam.transform.position = new Vector3(7.6f, -33.1f, 9.4f);
        cam.transform.rotation = Quaternion.identity;
        cam.transform.rotation = Quaternion.Euler(0, 90, 0);
        _carSettings.ChangeResoras(_car.Resora);
    }
}
