using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeSect : MonoBehaviour, IPointerDownHandler {

    public int currentLevel;
    public Slider slider;

    public Button button;

    public void OnPointerDown(PointerEventData eventData) {
        incrementDisplay();
    }

    public void incrementDisplay() {
        ++currentLevel;
        slider.value = currentLevel;
    }
}