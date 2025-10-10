using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        }
    }

    private void FixedUpdate()
    {
        // OPTION 1
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        // OPTION 2
        // if (movement.x != 0 || movement.y != 0)
        // {
        //     rb.velocity = movement * speed;
        // }
        
        //rb.AddForce(movement * speed);
    }
}
