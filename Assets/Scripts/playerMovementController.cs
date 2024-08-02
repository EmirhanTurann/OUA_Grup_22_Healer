using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovementController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private float moveSpeed = 300f;
    [SerializeField] private Button jumpButton;
    [SerializeField] private float jumpForce = 5f;

    private float _horizontal;
    private float _vertical;
    private bool isGrounded = true;
    private bool isJumping = false;

    private void Start()
    {
       // jumpButton.onClick.AddListener(Jump);
    }

    private void Update()
    {
        GetMovementInputs();
        SetRotation();
    }

    private void FixedUpdate()
    {
        SetMovement();
        
    }

    private void SetMovement()
    {
        Vector3 newVelocity = new Vector3(_horizontal, playerRb.velocity.y, _vertical) * moveSpeed * Time.fixedDeltaTime;
        newVelocity.y = playerRb.velocity.y;
        playerRb.velocity = newVelocity;
        //Debug.Log(_horizontal);
    }


    /*private Vector3 GetNewVelocity()
    {
        return new Vector3(_horizontal, playerRb.velocity.y, _vertical) * moveSpeed * Time.fixedDeltaTime;
    }*/

    private void GetMovementInputs()
    {
        _horizontal = _fixedJoystick.Horizontal;
    }

    private void SetRotation()
    {
        if (_horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 80, 0);
        }
        else if (_horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 260, 0);
        }
    }

    public void Jump()
    {
       
        if (isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    public float GetHorizontalInput()
    {
        return _horizontal;
    }

    public float GetVerticalInput()
    {
        return _vertical;
    }

    public bool IsJumping()
    {
        return isJumping;
    }
}
