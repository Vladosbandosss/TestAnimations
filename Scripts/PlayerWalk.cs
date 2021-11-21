using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float rotationSpeed = 3f;
    private float rotateY;//вращ

    public Transform groundCheckPosition;
    public float JumpPower = 200f;
    public float radius = 0.3f;
    public LayerMask groundLayer;//прыжок
    private bool isGrounded, hasJumped;

    private PlayerAnimation playerAnim;
    private Rigidbody rb;

    private float h, v;

    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnimation>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        AnimatePlayer();
        CheckAttack();
        CheckGroundCollisionAndJumped();
    }

    void CheckGroundCollisionAndJumped()
    {
        isGrounded = Physics.OverlapSphere(groundCheckPosition.position, radius, groundLayer).Length > 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector3(0, JumpPower, 0));
                hasJumped = true;
                playerAnim.Jumped(true);
            }
        }
    }

    void CheckMovement()
    {
        h = Input.GetAxis("Horizontal");

        v = Input.GetAxisRaw("Vertical");//
        rotateY += h * rotationSpeed;//
        transform.localRotation = Quaternion.AngleAxis(rotateY, Vector3.up);//3 строки для вращения
        //transform.rotation = Quaternion.AngleAxis(rotateY, Vector3.up);//3 строки для вращения

    }

    void CheckAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.Attack1();
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerAnim.Attack2();
        }
    }

    void AnimatePlayer()
    {
        if (v != 0)
        {
            playerAnim.PlayerWalk(true);
        }
        else
        {
            playerAnim.PlayerWalk(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (hasJumped)
            {
                hasJumped = false;
                playerAnim.Jumped(false);
            }
           
        }
    }
}
