using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;
    public float speed,sprintSpeed, jumpForce, raycast, hp, gold;
    public bool grounded, isJumping;
    public float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hp = 50;
        gold = 100;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Soltqt"))
        {
            grounded = true;
            isJumping = false;
            Debug.Log("grounded");
        }
    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 currentVelocity = rb.linearVelocity;
        float newSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        Vector3 newVelocity = new Vector3(moveInput.x * newSpeed, currentVelocity.y, moveInput.z * newSpeed);
        rb.linearVelocity = newVelocity;
        if (moveInput.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);
            float rotationSpeed = 15f;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }

        if (jumpBufferCounter > 0 && grounded)
        {
            Vector3 velocity = rb.linearVelocity;
            velocity.y = jumpForce;
            rb.linearVelocity = velocity;

            grounded = false;
            isJumping = true;

            jumpBufferCounter = 0;
        }
    }
}
