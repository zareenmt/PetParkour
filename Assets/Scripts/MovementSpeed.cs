using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeed : MonoBehaviour {

    public PlayerController Character;

    private float defaultSpeed;
    private float increasedSpeed = 10f;

    void Start() {
        defaultSpeed = Character.getSpeed();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BuffedArea")) {
            Character.setSpeed(increasedSpeed);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("BuffedArea")) {
            Character.setSpeed(defaultSpeed);
        }
    }
}