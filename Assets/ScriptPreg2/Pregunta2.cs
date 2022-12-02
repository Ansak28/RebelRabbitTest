using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta2 : MonoBehaviour
{
    float posX;
    float posY;
    float velX;
    float velY;
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3 ( posX,posY,0);
        Debug.Log(transform.position);
        posX += velX * Time.deltaTime;
        posY  +=  velY *Time.deltaTime;
        if(Input.GetKeyDown("space"))
        {
            Caer();
            Debug.Log(velX);
            Debug.Log(velY);
        }
    }
    void Caer()
    {
        velX += 10 * Mathf.Cos(Mathf.Deg2Rad * -45);
        velY += 10 * Mathf.Sin(Mathf.Deg2Rad * -45);
    }
}
