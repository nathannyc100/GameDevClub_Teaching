using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    private InputController inputController;
    [SerializeField]
    private GameObject[] cameras = new GameObject[3];
    private int currentCam;

    private void OnEnable(){
        inputController = FindObjectOfType<InputController>();

        inputController.OnCameraChanged += When_OnCameraChanged;

        currentCam = 0;
        cameras[1].SetActive(false);
        cameras[2].SetActive(false);
    }

    private void When_OnCameraChanged(object sender, EventArgs e){
        currentCam ++;
        if (currentCam >= 3){
            currentCam = 0;
        }

        for (int i = 0; i < cameras.Length; i ++){
            cameras[i].SetActive(false);
        }
        
        cameras[currentCam].SetActive(true);
    }
}
