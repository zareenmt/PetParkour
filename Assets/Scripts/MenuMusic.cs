using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private bool musicPaused = false;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        if (audioSource != null) {
            audioSource.loop = true;
            audioSource.Play();
            audioSource.volume = 0.5f;
        }
    }

    public void SetVolume(float volume) {
        if (audioSource != null) {
            audioSource.volume = Mathf.Clamp01(volume);
        }
    }

    public void StopMusic() {
        if (audioSource != null && audioSource.isPlaying) {
            audioSource.Stop();
            musicPaused = false;
        }
    }

    public void PauseMusic() {
        if (audioSource != null && audioSource.isPlaying) {
            audioSource.Pause();
            musicPaused = true;
        }
    }

    public void ResumeMusic() {
        if (audioSource != null && musicPaused) {
            audioSource.Play();
            musicPaused = false;
        }
    }
}
