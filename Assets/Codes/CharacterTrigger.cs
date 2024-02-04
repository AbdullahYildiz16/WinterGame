using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
    [SerializeField] private SpawnEnvironment spawnEnvironment;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private ScoreController scoreController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BgSpawnPoint"))
        {
            spawnEnvironment.SpawnBg(other.transform.parent.transform.position);
            Debug.Log("Spawning new background!!");
        }
        else if (other.CompareTag("BgDestroyPoint"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Debug.Log("Destroying previous background!!");
        }
        else if (other.CompareTag("Obstacle"))
        {
            characterMovement.enabled = false;
            scoreController.SetGameEnd();
        }
    }
}
