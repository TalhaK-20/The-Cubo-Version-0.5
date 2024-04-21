using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AudioSource.PlayClipAtPoint(collisionSound, collision.contacts[2].point);
        }
    }
}