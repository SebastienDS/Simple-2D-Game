using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D collider2D;

    // Start is called before the first frame update
    private void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) {
            playerMovement.isClimbing = true;
            collider2D.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isInRange = false;
            playerMovement.isClimbing = false;
            collider2D.isTrigger = false;
        }
    }
}
