using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float CameraDistance            = 10;
    [SerializeField] private float CameraHeight              = 3;
    [SerializeField] private float CameraMovementSpeed       = 2;
    [SerializeField] private bool Scrolling                  = true;
    [SerializeField] private float AngleUpperLimit           = 45;
    [SerializeField] private float AngleLowerLimit           = 45;
    [System.Serializable]
    class Dumping
    {
        [SerializeField] internal float HorizontalRotation = 3;
        [SerializeField] internal float VerticalRotation = 3;
        [SerializeField] internal float Scroll = 3;
    }
    [SerializeField] private Dumping dumping = new Dumping();

    private float spit;

    const float Radian = 180 / Mathf.PI;

    private float x;
    private float y;
    private Vector2 Scroll;
    private float CurrentDistance;
    private float CurrentHeight;
    private Vector3 rotateValue;
    private Vector3 CameraPositionOffset;
    private float CameraAngle = 0;
    private float CurrentAngleRad;
    private float CurrentAngleX;
    private float CurrentAngleY;
    private bool MiddleButton = false;

    private void Start()
    {
        CurrentHeight = CameraHeight;
        CurrentDistance = CameraDistance;
    }

    private void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        MiddleButton = Input.GetButton("Fire3");
        Scroll = Input.mouseScrollDelta;
    }

    private void LateUpdate()
    {
        if(Scrolling == true)
        {
            if (MiddleButton == false)
            {
                CameraDistance = Mathf.Clamp(CameraDistance - Scroll.y, 2, 20);
                CurrentDistance = Mathf.Lerp(CurrentDistance, CameraDistance, Time.deltaTime * dumping.Scroll);
            }
            else
            {
                CameraHeight = Mathf.Clamp(CameraHeight + Scroll.y, 1, 20);
                CurrentHeight = Mathf.Lerp(CurrentHeight, CameraHeight, Time.deltaTime * dumping.Scroll);
            }
        }

        CurrentAngleY = Mathf.Lerp(CurrentAngleY, y, Time.deltaTime * dumping.HorizontalRotation);
        CurrentAngleX = Mathf.Lerp(CurrentAngleX, x, Time.deltaTime * dumping.VerticalRotation);
   
        rotateValue = new Vector3(CurrentAngleX, CurrentAngleY * -1, 0) * CameraMovementSpeed;
        transform.eulerAngles = transform.eulerAngles - rotateValue;
        
        float rot = transform.eulerAngles.x;
        if (rot > 180)
            rot -= 360;
        rot = Mathf.Clamp(rot, -AngleUpperLimit, AngleLowerLimit);
        transform.eulerAngles = new Vector3(rot, transform.eulerAngles.y, 0);
        
        CameraAngle += CurrentAngleY;
        CurrentAngleRad = (CameraAngle % 360) / Radian * CameraMovementSpeed;
        CameraPositionOffset = new Vector3(CurrentDistance * Mathf.Sin(CurrentAngleRad), CurrentHeight * -1, CurrentDistance * Mathf.Cos(CurrentAngleRad));
        transform.position = Target.position - CameraPositionOffset;
    }
}