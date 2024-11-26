using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public int movingHash;
    public int jumpingHash;
    public CharacterController charControl;
    private Vector3 _movementInput;
    private float speed = 3f;
    private bool _isMoving;
    private float rotationFactorPerFrame =10.0f;
    private bool _isJumpPressed = false;
    private float initalJumpVelocity;
    private float maxJumpHeight = 6.0f;
    private float maxJumpTime = 0.75f;
    private bool isJumping = false;
    private float gravity = -9.8f;
    private float groundedGravity = -1.3f;
    private bool isJumpAnimating;
    private Vector3 _direction;
    private Vector3 cameraRelativeMove;
    private bool isFalling;
    [SerializeField] private Transform cam;
    public void Awake()
    {
        playerAnim = GetComponent<Animator>();
        movingHash = Animator.StringToHash("isMoving");
        jumpingHash = Animator.StringToHash("isJump");
        charControl = GetComponent<CharacterController>();
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initalJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }
    
    public void Update()
    {
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.z = Input.GetAxis("Vertical");
        _movementInput.x *= speed;
        _movementInput.z *= speed;
        HandleAnimation();
        cameraRelativeMove = ConvertToCamSpace(_movementInput);
        charControl.Move(cameraRelativeMove*Time.deltaTime);
        HandleRotation();
        HandleGravity();
        HandleJump();



    }

    private void HandleRotation()
    {
        Vector3 posToLookAt;
        posToLookAt.x = cameraRelativeMove.x;
        posToLookAt.y = 0.0f;
        posToLookAt.z = cameraRelativeMove.z;
        Quaternion currentRotation = transform.rotation;
        if(posToLookAt != Vector3.zero) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(posToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame*Time.deltaTime);
        }
        
    }

    private void HandleAnimation()
    {
        if (_movementInput.x != 0 || _movementInput.z!=0)
        {
            _isMoving = true;
            playerAnim.SetBool(movingHash,_isMoving);
        }
        else
        {
            _isMoving = false;
            playerAnim.SetBool(movingHash,_isMoving);
        }
        
    }

    private void HandleGravity()
    {
        isFalling = _movementInput.y <= 0.0f;
        float fallMultiplier = 2.0f;
        if (charControl.isGrounded)
        {
            isJumping = false;
            if (isJumpAnimating)
            {
                playerAnim.SetBool(jumpingHash,false);
                isJumpAnimating = false;
            }
            _movementInput.y = groundedGravity;
        }
        else if (isFalling)
        {
            float previousYVelocity = _movementInput.y;
            float newYVelocity = _movementInput.y + (gravity *fallMultiplier* Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * 0.5f;
            _movementInput.y = nextYVelocity;
        }
        else
        {
            float previousYVelocity = _movementInput.y;
            float newYVelocity = _movementInput.y + (gravity * Time.deltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * 0.5f;
            _movementInput.y = nextYVelocity;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping && charControl.isGrounded)
            {
                _isJumpPressed = true;
                isJumping = true;
                isJumpAnimating = true;
                playerAnim.SetBool(jumpingHash,true);
                _movementInput.y = initalJumpVelocity*0.5f;
            }
        }
    }

    public void setSpeed(float updateSpeed) {
        speed = updateSpeed;
    }
    public float getSpeed() {
        return speed;
    }

    private Vector3 ConvertToCamSpace(Vector3 movement)
    {
        float currY = movement.y;
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;
        Vector3 forwardRelativeVInput = movement.z * forward;
        Vector3 rightRelativeHInput = movement.x * right;
        Vector3 camRelativeMove = (forwardRelativeVInput + rightRelativeHInput);
        camRelativeMove.y = currY;
        return camRelativeMove;
    }
}
