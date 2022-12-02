using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBullet : MonoBehaviour
{
    private float timeStamp;
    private float coolDownSeconds = 0.2f;
    Transform instantiateBullet;
    
    private void Awake() 
    {
        instantiateBullet = transform.Find("InstantiateBullet");
    }
    void Start()
    {
        timeStamp = Time.time + coolDownSeconds;
    }
    void Update()
    {
        
        if(timeStamp<=Time.time)
        {
            timeStamp = Time.time + coolDownSeconds;
            Fire();
        }

    }

    private void Fire()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = instantiateBullet.position;
            bullet.transform.rotation = instantiateBullet.rotation;
            bullet.SetActive(true);
        }
    }

}
