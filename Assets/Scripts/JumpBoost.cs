using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public PlayerController plr;

    private float defaultHeight;
    public float heightIncreased = 40f;


    void Start(){
        defaultHeight = plr.getInitialJump();
    }

    private void OnTriggerEnter(Collider area) {
        if (area.CompareTag("JumpBoost")) {
            plr.setInitialJump(heightIncreased);
        }
    }

    private void OnTriggerExit(Collider area) {
        if (area.CompareTag("JumpBoost")) {
            plr.setInitialJump(defaultHeight);
        }
    }
}
