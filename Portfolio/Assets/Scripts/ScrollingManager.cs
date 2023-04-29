using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingManager : MonoBehaviour
{
    [SerializeField] float minLimit = 34.1f;
    [SerializeField] float maxLimit = 100f;
    [SerializeField] float scrollSpeed = 10f;
    [SerializeField] PlayerSFX playerSfx;
    bool enginePlaying;
    //[SerializeField] SpriteRenderer spriteRenderer;
    // [SerializeField] Transform bulletSpawner;
    Vector3 newPos;
    void Update()
    {
        Scroll();
        HideCursor();
    }
    private void Scroll()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y > maxLimit)
            {
                transform.position -= transform.up * scrollSpeed * Time.deltaTime;
                // spriteRenderer.flipY = false;
                //if (!enginePlaying)
                //{
                //    enginePlaying = true;
                //    playerSfx.PlayEngine();
                //}
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y < minLimit)
            {
                transform.position += transform.up * scrollSpeed * Time.deltaTime;
                //spriteRenderer.flipY = true;
                //if (!enginePlaying)
                //{
                //    enginePlaying = true;
                //    playerSfx.PlayEngine();
                //}
            }
        }
        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        //{
        //    enginePlaying = false;
        //    playerSfx.StopAudio();
        //}
    }

    private void HideCursor()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
