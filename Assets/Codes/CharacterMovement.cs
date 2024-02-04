using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY = 0.5f;
    [SerializeField] private float rotationMin = -50f;
    [SerializeField] private float rotationMax = 50f;
    [SerializeField] private float positionYMax = 3f;
    [SerializeField] private float positionYMin = -3.5f;
    [SerializeField] private Camera mainCam;
    private Vector3 dir;
    private float rotationAngel;

    void Update()
    {
        FollowMousePos();
    }

    void FollowMousePos()
    {
        dir = Input.mousePosition - mainCam.WorldToScreenPoint(transform.position);
        transform.position += Vector3.right*speedX*Time.deltaTime;
        if (dir.x < 5) return;
        rotationAngel = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotationAngel = Mathf.Clamp(rotationAngel, rotationMin, rotationMax);
        transform.rotation = Quaternion.AngleAxis(rotationAngel, Vector3.forward);
        
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(transform.position.x, Mathf.Clamp(dir.y,positionYMin , positionYMax), transform.position.z),
            speedY * Time.deltaTime);
        
    }

    
}
