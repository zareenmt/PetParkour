using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public Animator playerAnim;
    public int movingHash;
    public int velocityHash;
    public CharacterController charControl;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        movingHash = Animator.StringToHash("isMoving");
        velocityHash = Animator.StringToHash("velocity");
        charControl = GetComponent<CharacterController>();
    }
}