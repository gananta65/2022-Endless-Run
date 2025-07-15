using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;
    public float Runspeed;
    public float horizontalSpeed;
    public Rigidbody rb;
    float horizontalInput;
    public float jumpForce;
    public LayerMask groundMask;
    public int maxSpeed = 35;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            Vector3 forwardMovement = transform.forward * Runspeed * Time.fixedDeltaTime;
            Vector3 horizontalMovement = transform.right * horizontalInput * horizontalSpeed * Time.fixedDeltaTime;

            // Hitung posisi baru
            Vector3 targetPosition = rb.position + forwardMovement + horizontalMovement;

            // Batasi gerakan X agar tetap di antara -5 dan 5
            targetPosition.x = Mathf.Clamp(targetPosition.x, -5f, 5f);

            rb.MovePosition(targetPosition);
        }
        // setiap bebrapa detik, tambahkan kecepatan speed
        if (Runspeed < maxSpeed)
        {
            Runspeed += Time.fixedDeltaTime * 0.4f; // Tambahkan kecepatan secara bertahap
        }
        else
        {
            Runspeed = maxSpeed; // Pastikan tidak melebihi maxSpeed
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float playerHeight = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isAlive && isGrounded == true)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Dead();
        }
    }

    public void Dead()
    {
        isAlive = false;
        rb.velocity = Vector3.zero; // Stop the player
        Debug.Log("Game Over");
        GameManager.MyInstance.GameOverPanel.SetActive(true);
        GameManager.MyInstance.ScorePanel.SetActive(false);
    }
}
