using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject[] Cameras;

    int currentCam;

    bool onMenuCam;

    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        currentCam = 0;
        setCam(currentCam);
        onMenuCam = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (onMenuCam && Input.anyKey) {
            toggleCam();
        }
    }

    public void setCam(int idx)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == idx)
            {
                Cameras[i].SetActive(true);
            }
            else
            {
                Cameras[i].SetActive(false);
            }
        }
    }

    public void toggleCam()
    {
        currentCam++;
        if (currentCam > Cameras.Length - 1)
            currentCam = 0;
        setCam(currentCam);
        toggleCursorLock();
        onMenuCam = false;
        menuPanel.SetActive(false);
    }

    public void toggleCursorLock() {
        if (Cursor.lockState == CursorLockMode.Locked) {
            Cursor.lockState = CursorLockMode.None;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}