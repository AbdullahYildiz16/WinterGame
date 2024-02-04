using UnityEngine;

public class SnowAnim : MonoBehaviour
{
    [SerializeField] private Vector2 startPos;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        transform.position += Vector3.down * speed;
        if (transform.position.y < -10f) transform.position = new Vector2(transform.position.x, startPos.y);
    }
    
}
