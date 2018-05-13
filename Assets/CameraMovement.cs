using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float CameraDistance            = 10;
    [SerializeField] private float CameraHeight              = 3;
    [SerializeField] private float CameraMovementSpeed       = 2;
    [SerializeField] private float HorizontalRotationDamping = 3;
    [SerializeField] private float VerticalRotationDamping   = 3;
    [SerializeField] private float AngleUpperLimit           = 45;
    [SerializeField] private float AngleLowerLimit           = 45;

    const float Radian = 180 / Mathf.PI;

    private float x;
    private float y;
    private Vector3 rotateValue;
    private Vector3 CameraPositionOffset;
    private float CameraAngle;
    private float CurrentAngleRad;
    private float CurrentAngleX;
    private float CurrentAngleY;

    private void Start()
    {
        CameraAngle = 0;
    }

    private void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");

        CurrentAngleY = Mathf.Lerp(CurrentAngleY, y, Time.deltaTime * HorizontalRotationDamping);
        CurrentAngleX = Mathf.Lerp(CurrentAngleX, x, Time.deltaTime * VerticalRotationDamping);

        rotateValue = new Vector3(CurrentAngleX, CurrentAngleY * -1, 0) * CameraMovementSpeed;
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        
        float rot = transform.eulerAngles.x;
        if (rot > 180)
            rot -= 360;
        rot = Mathf.Clamp(rot, -AngleUpperLimit, AngleLowerLimit);
        transform.eulerAngles = new Vector3(rot, transform.eulerAngles.y, 0);
        
        CameraAngle += CurrentAngleY;
        CurrentAngleRad = (CameraAngle % 360) / Radian * CameraMovementSpeed;
        CameraPositionOffset = new Vector3(CameraDistance * Mathf.Sin(CurrentAngleRad), CameraHeight * -1, CameraDistance * Mathf.Cos(CurrentAngleRad));
        transform.position = Target.position - CameraPositionOffset;
    }
}