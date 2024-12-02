using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{

    private static BackgroundMusicManager instance;
    private AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start() {
        if (audioSource != null) {
            audioSource.volume = PlayerPrefs.GetFloat("Volume", 1f);
        }
    }

    public void SetVolume(float volume) {
        if (audioSource != null) {
            audioSource.volume = Mathf.Clamp01(volume);
            PlayerPrefs.SetFloat("Volume", volume);
            PlayerPrefs.Save();
        }
    }

    public float GetVolume() {
        return audioSource != null ? audioSource.volume : 0f;
    }
}
