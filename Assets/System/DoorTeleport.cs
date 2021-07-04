using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorTeleport : MonoBehaviour{

    public Text text;

    void Start() {
        text.text = "";
    }

    private void OnTriggerEnter(Collider other) {
        text.text = "Press 'E' to enter";
    }

    private void OnTriggerStay(Collider other) {
        if (Input.GetKey(KeyCode.E)) {
            SceneManager.LoadScene (sceneBuildIndex: 1);
        }
    }

    private void OnTriggerExit(Collider other) {
        text.text = "";
    }
}