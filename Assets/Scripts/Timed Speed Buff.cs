using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpeedBuff : MonoBehaviour {

    public PlayerController Character;

    public float duration = 5f;
    public float buffedSpeed = 5f;
    private float defaultSpeed;

    private bool isBuffed = false;
    private float originalSpeed;

    void Start() {
        defaultSpeed = Character.getSpeed();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && !isBuffed) {
            StartCoroutine(ApplySpeedBuff(buffedSpeed));
        }
    }


    IEnumerator ApplySpeedBuff(float buffedSpeed) {
        isBuffed = true;
        Character.setSpeed(buffedSpeed);

        yield return new WaitForSeconds(duration)   ;

        Character.setSpeed(defaultSpeed);
        isBuffed = false;     
    }
}