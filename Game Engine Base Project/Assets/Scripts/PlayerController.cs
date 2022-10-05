using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    //Player Movement
    public PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    public float walkSpeed = 0.8f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    //Player Jump
    Rigidbody rb;
    private float distanceToGround;
    private bool isGrounded = true;
    public float jump = 5f;

    //Player Animation
    Animator playerAnimator;
    private bool isWalking = false;

    //Projectiles
    public GameObject bullet;
    public Transform projectilePos;

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }


    // Start is called before the first frame update
    void Awake()
    {

        if (!instance)
        {
            instance = this;
        }

        inputAction = new PlayerAction();

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();

        inputAction.Player.Shoot.performed += cntxt => Shoot();

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

    }

    public void Jump() 
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }

    public void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Respawn" || other.collider.tag == "Enemy")
        {
            transform.position = new Vector3(-0.17f, 1.003f, -0.313f);
            rb.velocity = new Vector2(0f, 0f);
        }
    }

}
