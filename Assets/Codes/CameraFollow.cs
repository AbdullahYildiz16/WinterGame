using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] float offsetX;
    
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x + offsetX,
                transform.position.y, transform.position.z), Time.deltaTime*2);
    }
}
