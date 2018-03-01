﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {

    [Tooltip("What object does the camera reference for its transform.")]
    public GameObject target;
    private Camera currentCamera;

    //Late update looks much more smooth because it lets all other transforms to finish first.

    private void Awake() {
        currentCamera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        transform.position = target.transform.position;
        // var rot = transform.rotation;
        // rot.y = player.transform.rotation.y;
        transform.rotation = target.transform.rotation;
    }


    //All playerControllers can set their viewports by calling this
    //Player number starts from 1.
    public void SetViewport(int playerAmount, int player) 
    {

        var rect = currentCamera.rect;
        var fov = currentCamera.fieldOfView;
        
        switch(playerAmount)
        {
            case 1: {
                fov = 65f;
                rect.height = 1f;
                rect.width = 1f;
                rect.x = 0;
                rect.y = 0;
                currentCamera.rect = rect;
                currentCamera.fieldOfView = fov;
                break;

            }
            case 2: 
            {      
                fov = 80f; //Half screen looks better with higher fov.
                rect.height = 1f;
                rect.width = 0.5f;       

                if(player == 1) {
                    //viewport half screen left
                    rect.x = 0;
                    rect.y = 0;
                }
                else if (player == 2) {
                    //viewport half screen right
                    rect.x = 0.5f;
                    rect.y = 0;
                } else {
                    Debug.LogError("If two active players, there must be player 1 and player 2 defined.");
                }
                
                currentCamera.rect = rect;
                currentCamera.fieldOfView = fov;

                break;
            }
            case 3: 
            {
                fov = 60f;
                rect.height = 0.5f;
                rect.width = 0.5f;

                if(player == 1) {
                    //Set viewport 1/4 upper left

                    rect.x = 0;
                    rect.y = 0.5f;
                }
                else if (player == 2) {
                    //Set viewport 1/4 upper right
                    rect.x = 0.5f;
                    rect.y = 0.5f;
                }
                else if (player == 3) {
                    //Set viewport 1/4 lower left
                    rect.x = 0;
                    rect.y = 0;
                }
                else {
                    Debug.LogError("If three active players, there must be player 1, player 2 and player 3 defined.");                    
                }

                currentCamera.rect = rect;
                currentCamera.fieldOfView = fov;
                
                break;

            }
            case 4: 
            {
                fov = 60f;
                rect.height = 0.5f;
                rect.width = 0.5f;

                if(player == 1) {
                    //Set viewport 1/4 upper left
                    rect.x = 0;
                    rect.y = 0.5f;
                }
                else if (player == 2) {
                    //Set viewport 1/4 upper right
                    rect.x = 0.5f;
                    rect.y = 0.5f;
                }
                else if (player == 3) {
                    //Set viewport 1/4 lower left
                    rect.x = 0;
                    rect.y = 0;
                }
                else if (player == 4) {
                    //Set viewport 1/4 lower right
                    rect.x = 0.5f;
                    rect.y = 0;
                }
                else {
                    Debug.LogError("If four active players, there must be player 1-4 defined");          
                }

                currentCamera.rect = rect;
                currentCamera.fieldOfView = fov;
                
                break;
            }
        }
    }

}
