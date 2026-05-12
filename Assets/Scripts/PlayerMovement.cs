using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 7f;

    public bool canMove = true;

    public AudioClip jumpSound;

    private AudioSource audioSource;
    private Rigidbody rb;

    private bool isGrounded;

    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();

        // Prevent unwanted rotations
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!canMove)
            return;

        // Input
        float moveX = Input.GetAxis("Vertical");
        float moveZ = Input.GetAxis("Horizontal");

        movement = new Vector3(moveX, 0f, moveZ).normalized;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce,
                        ForceMode.Impulse);

            audioSource.PlayOneShot(jumpSound);

            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        // Smooth Rigidbody movement
        Vector3 newPosition =
            rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}