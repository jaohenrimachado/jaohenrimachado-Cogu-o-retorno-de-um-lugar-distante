using UnityEngine;
using UnityEngine.InputSystem;

public class playermove : MonoBehaviour
{
    public InputAction playerControls;

    public float playerSpeed = 8f;

    Vector2 playerDirection;

    public Rigidbody2D playerPhysics;

    public bool canJump;

    public InputAction playerJump;

    public float playerJumpHight = 10f;

    private void OnEnable()
    {
        playerControls.Enable();
        playerJump.Enable();
        playerJump.performed += DoJump;
    }
    private void OnDisable()
    {
        playerControls.Disable();
        playerJump.Disable();
    }

    void Update()
    {
        playerDirection = playerControls.ReadValue<Vector2>();
        playerPhysics.linearVelocity = new Vector2(playerDirection.x * playerSpeed, playerPhysics.linearVelocity.y);
    }
    public void DoJump(InputAction.CallbackContext context)
    {
        if (!canJump)
        {
            return;
        }

        playerPhysics.linearVelocity = new Vector2(playerPhysics.linearVelocity.x, playerJumpHight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("chao"))
        {
            canJump = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            canJump = false;
        }
    }
}