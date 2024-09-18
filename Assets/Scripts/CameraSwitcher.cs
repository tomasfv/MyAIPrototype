using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras; 
    private int currentCameraIndex = 0;

    void Start()
    {
        
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].gameObject.SetActive(i == currentCameraIndex);
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        if (virtualCameras.Length > 0)
        {
           
            virtualCameras[currentCameraIndex].gameObject.SetActive(false);

            // Index Update. 
            currentCameraIndex = (currentCameraIndex + 1) % virtualCameras.Length;

            
            virtualCameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }
}
