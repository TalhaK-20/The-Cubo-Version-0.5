using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float maxSpeed = 10f;
    public float minX = -5f;
    public float maxX = 5f;
    public AudioClip collisionSound; // Reference to the collision sound clip

    private AudioSource audioSource;

    void Start()
    {
        // Get AudioSource component from the player object
        audioSource = GetComponent<AudioSource>();
        // Set the audio clip for the AudioSource
        audioSource.clip = collisionSound;
    }

    void FixedUpdate()
    {
        // Add forward force continuously
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);       

        // Move sideways when "d" key is pressed
        if (Input.GetKey("d") || Input.touchCount > 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x > Screen.width / 2)
                {
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else
                {
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
            }
            else
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);           
            }
        }
        // Move sideways when "a" key is pressed
        else if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);           
        }

        // Limit maximum speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        // Restrict movement within specified range
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        // Play collision sound if the player collides with an obstacle
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(collisionSound);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}