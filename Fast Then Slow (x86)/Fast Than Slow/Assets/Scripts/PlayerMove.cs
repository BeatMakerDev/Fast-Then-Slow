using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public KeyCode SprintKey;

    public Rigidbody rb;
    public Transform _camera;

    public float moveSpeed = 6f;
    public float jumpForce = 10f;

    public LayerMask Ground;

    bool isGrounded = true;

    void Start()
    {

    }

    void Update()
    {
        //Sprint
        //if (Input.GetKeyDown(SprintKey))
        //{
        //    moveSpeed = moveSpeed + 15f;
        //}
        // (Input.GetKeyUp(SprintKey))
        //{
        //    moveSpeed = moveSpeed - 15f;
        //}
        //grounding
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 0.4f, Ground);

        //facing direction
        Debug.DrawLine(_camera.position, transform.forward * 2.5f);

        //moving
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        //setting movement
            Vector3 move = transform.right * x + transform.forward * y;

            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

    }

    public void FastBoi()
    {
        Debug.Log("speed");
        moveSpeed = 25f;
    }

    public void SlowBoi()
    {
        Debug.Log("Slow");
        moveSpeed = 5f;
    }

    public void NormSpeedBoi()
    {
        Debug.Log("Norm");
        moveSpeed = 10f;
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().DieUI();
            FindObjectOfType<EnemyAI>().destoyEnemys();
        }
    }
}
