using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject[] Cameras;

    int currentCam;
    static bool started;

    // Start is called before the first frame update
    void Start()
    {
        currentCam = 0;
        setCam(currentCam);
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            toggleCam();
            started = true;
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
        if (!started)
        {
            currentCam++;
            if (currentCam > Cameras.Length - 1)
                currentCam = 0;
            setCam(currentCam);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}