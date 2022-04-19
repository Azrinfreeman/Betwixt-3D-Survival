using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Animator anim;
    public CharacterController controller;
    public Transform cam;

    public float speed = 6;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIController.instance.toggle = !UIController.instance.toggle;
            if (UIController.instance.toggle)
            {

                UIController.instance.showPause();
            }
            else
            {

                UIController.instance.hidePause();
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded && !anim.GetCurrentAnimatorStateInfo(0).IsTag("isWalking"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            anim.SetTrigger("isJump");
            //Debug.Log(!anim.GetCurrentAnimatorStateInfo(0).IsTag("isWalking"));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
            speed = 24;
            Debug.Log("asfasfaf");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", false);
            speed = 6;
        }
        
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            anim.SetFloat("speed", moveDir.magnitude);


        }else
        {
            anim.SetFloat("speed", 0f);

        }
    }


}


