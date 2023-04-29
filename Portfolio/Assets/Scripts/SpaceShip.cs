using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    Vector3 mousePos;
    [Header("Shooting")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed;
    [SerializeField] KeyCode shootingKey = KeyCode.Mouse0;

    //animaton
    [SerializeField]Animator anim;

    //sfx
    PlayerSFX playerSFX;
    void Start()
    {
        HideMouse();
        playerSFX  = GetComponent<PlayerSFX>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }
    private void HideMouse()
    {
        Cursor.visible = false;
    }   

    private void Movement()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.x = Mathf.Clamp(mousePos.x, -8.1f, 8.3f);
        transform.position = mousePos;
    }
    private void Shoot()
    {
       if(Input.GetKeyDown(shootingKey))
        {
            anim.SetTrigger("Shoot");
            GameObject bulletObj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            Destroy(bulletObj, 1f);
            playerSFX.PlayLaser();
        }
    }

}
