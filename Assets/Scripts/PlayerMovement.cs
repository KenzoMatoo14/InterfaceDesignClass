using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public float jumpForce = 10f;
    public Transform groundcheck;
    private bool isGrounded;
    public LayerMask groundLayer;
    public GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, 0.2f, groundLayer);

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        bool isJumping = Input.GetKeyDown(KeyCode.Space) && isGrounded;


        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector3(horizontalInput, 0, verticalInput) * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("POINT"))
        {
            gameManager.Addpoint();
            collision.gameObject.SetActive(false);
        }
    }
}
