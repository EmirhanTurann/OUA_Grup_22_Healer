using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationController : MonoBehaviour
{
    public Animator animator;
    private playerMovementController _movementController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _movementController = GetComponent<playerMovementController>();
    }

    void Update()
    {
        float horizontalInput = _movementController.GetHorizontalInput();
        float verticalInput = _movementController.GetVerticalInput();
        bool isJumping = _movementController.IsJumping();

        UpdateAnimation(horizontalInput, verticalInput, isJumping);

    }

    private void UpdateAnimation(float horizontalInput, float verticalInput, bool isJumping)
    {
        float speed = Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
        animator.SetFloat("isRunning", speed);

        if (isJumping)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
