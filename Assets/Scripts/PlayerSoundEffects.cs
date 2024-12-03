using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffects : MonoBehaviour
{
    private PlayerController playerController;
    private CharacterController charControl;
    private JumpBoost jumpBoost;

    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip jumpBoostSound;
    public AudioClip[] walkSounds;

    private int walkIndex = 0;
    private bool isJumping = false;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
        charControl = GetComponent<CharacterController>();
        jumpBoost = GetComponent<JumpBoost>();
    }

    void Update() {
        HandleWalkingSounds();
        HandleJumpLogic();
    }

    private void HandleWalkingSounds() {
        if (isJumping) {
            return;
        }

        if (charControl.isGrounded && playerController._isMoving) {
            if(!audioSource.isPlaying) {
                NextWalkSound();
            }
        } else if (audioSource.isPlaying && audioSource.clip == walkSounds[walkIndex]) {
            audioSource.Stop();
        }
    }

    private void HandleJumpLogic() {
        if (Input.GetButtonDown("Jump") && charControl.isGrounded && !jumpBoost.isJumpBoosted) {
            JumpSound();
        } else if (Input.GetButtonDown("Jump") && charControl.isGrounded && jumpBoost.isJumpBoosted) {
            JumpBoostSound();
        }
    }

    private void JumpSound() {
            isJumping = true;
            audioSource.PlayOneShot(jumpSound);
            StartCoroutine(ResetJumping(jumpSound.length));
    }

    private void NextWalkSound() {
        audioSource.clip = walkSounds[walkIndex];
        audioSource.Play();

        walkIndex = (walkIndex + 1) % walkSounds.Length;
    }

    private IEnumerator ResetJumping(float delay) {
        yield return new WaitForSeconds(delay);
        isJumping = false;
    }

    private void JumpBoostSound() {
        isJumping = true;
        audioSource.PlayOneShot(jumpBoostSound);
        StartCoroutine(ResetJumping(jumpBoostSound.length));
    }
}