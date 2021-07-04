using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject panel;
    public bool displayPanel;

    void Start() {
        displayPanel = true;
        panel.SetActive(true);
    }

    public void toggleMenu() {
        displayPanel = !displayPanel;
        panel.SetActive(displayPanel);
    }

}