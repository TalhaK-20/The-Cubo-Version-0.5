using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public PlayerController move;
    public AudioClip collisionSound; // Reference to the collision sound clip

    public AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component from the same GameObject
        audioSource = GetComponent<AudioSource>();
        // Set the audio clip for the AudioSource
        audioSource.clip = collisionSound;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Collision detected!");
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            // Disable player movement
            move.enabled = false;
            audioSource.Play();
          
            // Trigger game over
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
