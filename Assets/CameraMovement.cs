using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float CameraDistance = 10;
    [SerializeField] private float CameraHeight = 3;
    [SerializeField] private float CameraMovementSpeed = 2;

    const float Radian = 180 / Mathf.PI;

    private float x;
    private float y;
    private Vector3 rotateValue;
    private GameObject Sphere;
    private Vector3 CameraPositionOffset;
    private float CameraAngle = 0;
    private float CurrentAngleRad;
    

    private void Start()
    {
        Sphere = GameObject.Find("Sphere");
    }

    private void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0) * CameraMovementSpeed;
        transform.eulerAngles = transform.eulerAngles - rotateValue;
   
        
        var rot = transform.eulerAngles.x;
        if (rot > 180)
            rot -= 360;
        rot = Mathf.Clamp(rot, -45, 45);
        transform.eulerAngles = new Vector3(rot, transform.eulerAngles.y, 0);
        Debug.Log(transform.eulerAngles.x);

        CameraAngle += y;
        CurrentAngleRad = CameraAngle % 180 / Radian * CameraMovementSpeed;
        CameraPositionOffset = new Vector3(CameraDistance * Mathf.Sin(CurrentAngleRad), CameraHeight * -1, CameraDistance * Mathf.Cos(CurrentAngleRad));
        transform.position = Sphere.transform.position - CameraPositionOffset;
    }
}