using UnityEngine;

public class GiftCode : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] ColorType colorType;
    [HideInInspector]public SpawnGift spawnGift;
    [HideInInspector] public ScoreController ScoreController;
    private float startGravity;
    private bool isDestroyed = false;
    
    private void OnEnable()
    {
        startGravity = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0;
        isDestroyed = false;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        transform.SetParent(null);
        Jump();
        rigidbody2D.gravityScale = startGravity;
    }
    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        ScoreController.audioController.PlayThrowingGiftSound();
        ScoreController.IncreaseGiftAmount();
        ScoreController.PlayHandAnimation();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed || !other.CompareTag("Obstacle")) return;
        if (other.TryGetComponent<ColorType>(out ColorType otherColorType))
        {
            if (otherColorType.color == colorType.color)
            {
                ScoreController.IncreaseScore();
                Debug.Log("Earned 1 point");
            }
            else
            {
                ScoreController.DecreaseScore();
                Debug.Log("Lost 1 point"); 
            }
        }
        else
        {
            ScoreController.DecreaseScore();
            Debug.Log("Lost 1 point"); 
        }
        isDestroyed = true;
        spawnGift.SpawnRandomGift();
        gameObject.SetActive(false);
    }
}
